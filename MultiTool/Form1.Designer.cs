using System.Drawing;
using System.Windows.Forms;

namespace MultiTool
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
        /*private void InitializeComponent()
        {
            this.SuspendLayout();
            // Ana Form Ayarları
            this.Text = "Çok Yönlü Hesaplama Motoru";
            this.Size = new Size(400, 600);
            this.MinimumSize = new Size(400, 600);
            this.BackColor = bgColor;
            this.ForeColor = textColor;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Navigasyon (Üst Menü)
            navPanel = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = panelColor };

            btnCalcTab = CreateFlatButton("Hesap Makinesi", accentColor);
            btnCalcTab.Bounds = new Rectangle(0, 0, 200, 50);
            btnCalcTab.Click += (s, e) => SwitchTab(true);

            btnConvTab = CreateFlatButton("Birim Dönüştürücü", panelColor);
            btnConvTab.Bounds = new Rectangle(200, 0, 200, 50);
            btnConvTab.Click += (s, e) => SwitchTab(false);

            navPanel.Controls.Add(btnCalcTab);
            navPanel.Controls.Add(btnConvTab);
            this.Controls.Add(navPanel);

            // Panelleri Oluştur
            CreateCalculatorPanel();
            CreateConverterPanel();

            this.ResumeLayout(false);
        }*/

        #endregion
    }
}

