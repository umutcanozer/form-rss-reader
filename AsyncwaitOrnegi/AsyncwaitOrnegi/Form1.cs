using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AsyncwaitOrnegi
{
    public partial class Form1 : Form
    {
        /* 
        RSS (Really Simple Syndication), web sitelerinin içeriğini kullanıcıların takip etmesini sağlayan bir 
        web standartıdır. RSS, web sitelerinin güncel içeriğini yapılandırılmış bir biçimde sunmak için XML
        tabanlı bir formattır.
         */

        /* örnek linkler: 
         https://feeds.bbci.co.uk/turkce/rss.xml
         https://www.cnnturk.com/feed/rss/dunya/news
         https://rss.nytimes.com/services/xml/rss/nyt/World.xml
         */

        //HttpClient sınıfını kullanarak HTTP isteklerini yapmak için bir örnek oluşturuyoruz
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            //Nesne oluşturuyoruz
            _httpClient = new HttpClient();
        }

        //asenkron buton fonksiyonu
        private async void btnGetFeed_Click(object sender, EventArgs e)
        {
            //Kullanıcının girdiği RSS beslemesi URL'sini alıyoruz
            string feedUrl = txtRSSUrl.Text;
            if (string.IsNullOrWhiteSpace(feedUrl))
            {
                //Bu blokta textboss içinin boş olup olmadığını kontrol ediyoruz
                MessageBox.Show("Lütfen RSS feed URL'si giriniz.");
                return;
            }

            try
            {
                //HttpClient sınıfının GetStringAsync metodu ile RSS içeriğini asenkron olarak alıyoruz
                //await, asenkron bir işlemi beklerken iş parçacığının bloklanmasını önler ve programın diğer işlemlerine devam etmesini sağlar
                string rssContent = await _httpClient.GetStringAsync(feedUrl);
                //Alınan RSS içeriğini işlemek üzere ParseRssContent metoduna gönderiyoruz
                List<RssItem> items = ParseRssContent(rssContent);
                //Parse edilen RSS öğelerini kullanıcı arayüzünde göstermek üzere DisplayFeedItems metotuna gönderiyoruz
                DisplayFeedItems(items);
            }
            catch (Exception ex)
            {
                //Herhangi bir hata meydana gelirse hata mesajı göstermesini sağlıyoruz
                MessageBox.Show($"RSS feed çekiminde hata meydana geldi: {ex.Message}");
            }
        }


        //RSS içeriğini parse etmek için kullanılan metot.
        //alınan RSS içeriğinin bir string olarak gelmesi ve bu içeriğin XML belgesi olarak işlenebilir bir yapıya dönüştürülmesi için gerekli bir fonksiyondur
        private List<RssItem> ParseRssContent(string rssContent)
        {
            List<RssItem> items = new List<RssItem>();

            //Alınan RSS içeriğini bir XmlDocument nesnesine yükleyerek parse ediyoruz
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rssContent);

            //XML içerisindeki her bir "item" düğümünü seçiyoruz
            XmlNodeList itemNodes = xmlDoc.SelectNodes("rss/channel/item");
            foreach (XmlNode itemNode in itemNodes)
            {
                //Her bir "item" düğümünden başlık, bağlantı ve açıklama bilgilerini alıyoruz
                string title = itemNode.SelectSingleNode("title")?.InnerText;
                string link = itemNode.SelectSingleNode("link")?.InnerText;
                string description = itemNode.SelectSingleNode("description")?.InnerText;

                //RssItem sınıfı kullanarak bir RSS öğesi oluşturuyoruz ve listeye ekliyoruz
                RssItem item = new RssItem(title, link, description);
                items.Add(item);
            }

            return items;
        }

        //Alınan RSS öğelerini kullanıcı arayüzünde göstermek için kullanılan metot
        private void DisplayFeedItems(List<RssItem> items)
        {
            //Listbox içeriğini temizliyoruz.
            lstRSSItems.Items.Clear();
            //Her bir RSS öğesini Listbox'a ekliyoruz
            foreach (var item in items)
            {
                //yazım format şekli
                lstRSSItems.Items.Add($"{item.Title} - {item.Link}");
            }
        }
    }
    //RSS öğesini temsil eden sınıf
    public class RssItem
    {
        public string Title { get; } //öge başlığı
        public string Link { get; } //öge bağlantısı
        public string Description { get; } //öge açıklaması

        //RSS öğesi oluşturulurken başlık, bağlantı ve açıklama bilgilerini alır
        public RssItem(string title, string link, string description)
        {
            Title = title;
            Link = link;
            Description = description;
        }
    }
}
