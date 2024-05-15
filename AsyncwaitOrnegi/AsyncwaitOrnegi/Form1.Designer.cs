namespace AsyncwaitOrnegi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstRSSItems = new System.Windows.Forms.ListBox();
            this.txtRSSUrl = new System.Windows.Forms.TextBox();
            this.btnGetURL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRSSItems
            // 
            this.lstRSSItems.FormattingEnabled = true;
            this.lstRSSItems.Location = new System.Drawing.Point(172, 12);
            this.lstRSSItems.Name = "lstRSSItems";
            this.lstRSSItems.Size = new System.Drawing.Size(957, 238);
            this.lstRSSItems.TabIndex = 0;
            // 
            // txtRSSUrl
            // 
            this.txtRSSUrl.Location = new System.Drawing.Point(172, 284);
            this.txtRSSUrl.Name = "txtRSSUrl";
            this.txtRSSUrl.Size = new System.Drawing.Size(957, 20);
            this.txtRSSUrl.TabIndex = 1;
            // 
            // btnGetURL
            // 
            this.btnGetURL.Location = new System.Drawing.Point(616, 322);
            this.btnGetURL.Name = "btnGetURL";
            this.btnGetURL.Size = new System.Drawing.Size(75, 23);
            this.btnGetURL.TabIndex = 2;
            this.btnGetURL.Text = "RSS FETCH";
            this.btnGetURL.UseVisualStyleBackColor = true;
            this.btnGetURL.Click += new System.EventHandler(this.btnGetFeed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 450);
            this.Controls.Add(this.btnGetURL);
            this.Controls.Add(this.txtRSSUrl);
            this.Controls.Add(this.lstRSSItems);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstRSSItems;
        private System.Windows.Forms.TextBox txtRSSUrl;
        private System.Windows.Forms.Button btnGetURL;
    }
}

