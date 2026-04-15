using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace MultiTool
{
    public partial class Form1 : Form
    {
        // Renk Paleti (Modern Koyu Tema)
        private Color bgColor = Color.FromArgb(32, 34, 37);
        private Color panelColor = Color.FromArgb(47, 49, 54);
        private Color buttonColor = Color.FromArgb(64, 68, 75);
        private Color accentColor = Color.FromArgb(114, 137, 218); // Discord Mavisi
        private Color textColor = Color.White;

        // UI Elemanları
        private Panel navPanel;
        private Button btnCalcTab, btnConvTab;
        private Panel calcPanel, convPanel;

        // Hesap Makinesi Elemanları
        private TextBox txtDisplay;
        private bool isCalculated = false; // Eşittire basılıp basılmadığını takip eder
        private bool isOperatorEntered = false; // Ardışık operatörleri engeller

        // Dönüştürücü Elemanları
        private ComboBox cbCategory, cbFrom, cbTo;
        private TextBox txtConvInput, txtConvOutput;
        private Button btnConvert;

        public Form1()
        {
            InitializeComponent();
            SetupModernDesign();
        }

        private void InitializeComponent()
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
        }

        private void SetupModernDesign()
        {
            calcPanel.BringToFront(); // İlk hesap makinesi açılsın
        }

        // --- HESAP MAKİNESİ MODÜLÜ ---
        private void CreateCalculatorPanel()
        {
            calcPanel = new Panel { Dock = DockStyle.Fill, BackColor = bgColor };

            txtDisplay = new TextBox
            {
                Location = new Point(20, 20),
                Width = 345,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                BackColor = panelColor,
                ForeColor = textColor,
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                Text = "0"
            };
            calcPanel.Controls.Add(txtDisplay);

            TableLayoutPanel grid = new TableLayoutPanel
            {
                Location = new Point(20, 90),
                Size = new Size(345, 420),
                ColumnCount = 4,
                RowCount = 5
            };

            for (int i = 0; i < 4; i++) grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 5; i++) grid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            string[] buttons = {
                "C", "(", ")", "/",
                "7", "8", "9", "*",
                "4", "5", "6", "-",
                "1", "2", "3", "+",
                "0", ".", "=", ""
            };

            int index = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (buttons[index] != "")
                    {
                        Button b = CreateFlatButton(buttons[index], buttonColor);
                        b.Margin = new Padding(5);
                        b.Dock = DockStyle.Fill;
                        b.Font = new Font("Segoe UI", 16F, FontStyle.Bold);

                        if (buttons[index] == "=") b.BackColor = accentColor;
                        else if (buttons[index] == "C") b.BackColor = Color.IndianRed;

                        b.Click += CalcButton_Click;
                        grid.Controls.Add(b, col, row);
                    }
                    index++;
                }
            }

            calcPanel.Controls.Add(grid);
            this.Controls.Add(calcPanel);
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string text = btn.Text;
            bool isOperator = (text == "+" || text == "-" || text == "*" || text == "/");

            if (text == "C")
            {
                txtDisplay.Text = "0";
                isOperatorEntered = false;
                isCalculated = false;
            }
            else if (text == "=")
            {
                try
                {
                    // Türkçe ve İngilizce ondalık sistem çakışmasını engellemek için nokta değişimi yapılıyor
                    string expression = txtDisplay.Text.Replace(",", ".");
                    var result = new DataTable().Compute(expression, null);

                    // Sonucu InvariantCulture (Nokta formatı) ile yazdırıyoruz ki ardışık işlemlerde çökmesin
                    double numericResult = Convert.ToDouble(result, CultureInfo.InvariantCulture);
                    txtDisplay.Text = numericResult.ToString(CultureInfo.InvariantCulture);

                    isCalculated = true;
                    isOperatorEntered = false;
                }
                catch { txtDisplay.Text = "Hata"; }
            }
            else
            {
                // Eğer daha yeni "=" yapıldıysa ve yeni basılan şey bir sayıysa ekranı sıfırla.
                // Ama operatörse, eski sonucun yanına eklemeye devam et.
                if (isCalculated)
                {
                    if (!isOperator) txtDisplay.Text = "0";
                    isCalculated = false;
                }

                if (txtDisplay.Text == "0" || txtDisplay.Text == "Hata")
                {
                    if (isOperator)
                    {
                        if (text == "-") txtDisplay.Text = "-"; // Eksi ile başlayabilme izni
                        return; // 0 varken * veya / yapılmasına izin verme
                    }

                    if (text == ".") txtDisplay.Text = "0.";
                    else txtDisplay.Text = text;
                }
                else
                {
                    if (isOperator)
                    {
                        if (isOperatorEntered)
                        {
                            // Üst üste operatöre basılırsa sondakini yeni basılanla değiştir (Örn: 5+ iken -'ye basarsan 5- olur)
                            txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1) + text;
                            return;
                        }
                        isOperatorEntered = true;
                    }
                    else
                    {
                        isOperatorEntered = false;
                    }

                    txtDisplay.Text += text;
                }
            }
        }

        // --- BİRİM DÖNÜŞTÜRÜCÜ MODÜLÜ ---
        private void CreateConverterPanel()
        {
            convPanel = new Panel { Dock = DockStyle.Fill, BackColor = bgColor };

            Label lblCat = new Label { Text = "Kategori:", Location = new Point(40, 40), ForeColor = accentColor, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            cbCategory = new ComboBox { Location = new Point(40, 70), Width = 300, DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = panelColor, ForeColor = textColor };
            cbCategory.Items.AddRange(new string[] { "Uzunluk", "Ağırlık" });
            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;

            Label lblFrom = new Label { Text = "Buradan:", Location = new Point(40, 120), ForeColor = accentColor, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            txtConvInput = new TextBox { Location = new Point(40, 150), Width = 140, Font = new Font("Segoe UI", 14F), BackColor = panelColor, ForeColor = textColor, BorderStyle = BorderStyle.FixedSingle };
            cbFrom = new ComboBox { Location = new Point(190, 150), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = panelColor, ForeColor = textColor, Font = new Font("Segoe UI", 12F) };

            Label lblTo = new Label { Text = "Buraya:", Location = new Point(40, 210), ForeColor = accentColor, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            txtConvOutput = new TextBox { Location = new Point(40, 240), Width = 140, Font = new Font("Segoe UI", 14F), BackColor = panelColor, ForeColor = textColor, BorderStyle = BorderStyle.FixedSingle, ReadOnly = true };
            cbTo = new ComboBox { Location = new Point(190, 240), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, BackColor = panelColor, ForeColor = textColor, Font = new Font("Segoe UI", 12F) };

            // Canlı Dönüştürme Olayları (Eventleri)
            txtConvInput.TextChanged += (s, e) => ConvertValues();
            cbFrom.SelectedIndexChanged += (s, e) => ConvertValues();
            cbTo.SelectedIndexChanged += (s, e) => ConvertValues();

            btnConvert = CreateFlatButton("Dönüştür", accentColor);
            btnConvert.Bounds = new Rectangle(40, 310, 300, 50);
            btnConvert.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnConvert.Click += (s, e) => ConvertValues(); // Artık opsiyonel, zaten canlı dönüştürüyor

            convPanel.Controls.AddRange(new Control[] { lblCat, cbCategory, lblFrom, txtConvInput, cbFrom, lblTo, txtConvOutput, cbTo, btnConvert });

            cbCategory.SelectedIndex = 0; // Varsayılan seçim
            this.Controls.Add(convPanel);
        }

        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'ları temizlerken geçici çökme yaşanmaması için:
            cbFrom.Items.Clear();
            cbTo.Items.Clear();

            if (cbCategory.SelectedItem.ToString() == "Uzunluk")
            {
                string[] units = { "Metre", "Kilometre", "Santimetre", "Mil" };
                cbFrom.Items.AddRange(units); cbTo.Items.AddRange(units);
            }
            else if (cbCategory.SelectedItem.ToString() == "Ağırlık")
            {
                string[] units = { "Kilogram", "Gram", "Ton", "Pound" };
                cbFrom.Items.AddRange(units); cbTo.Items.AddRange(units);
            }

            cbFrom.SelectedIndex = 0;
            cbTo.SelectedIndex = 1;

            ConvertValues();
        }

        private void ConvertValues()
        {
            // Eğer comboboxlar henüz dolmadıysa işlem yapma (Crash engelleme)
            if (cbFrom.SelectedItem == null || cbTo.SelectedItem == null) return;

            // Virgül ve nokta karmaşasını önlemek için gelen stringi standardize et
            string inputStr = txtConvInput.Text.Replace(".", ",");

            if (double.TryParse(inputStr, out double input))
            {
                double baseValue = 0;
                string from = cbFrom.SelectedItem.ToString();
                string to = cbTo.SelectedItem.ToString();

                // 1. Adım: Referans birime çevir
                if (from == "Metre") baseValue = input;
                else if (from == "Kilometre") baseValue = input * 1000;
                else if (from == "Santimetre") baseValue = input / 100;
                else if (from == "Mil") baseValue = input * 1609.34;

                else if (from == "Kilogram") baseValue = input;
                else if (from == "Gram") baseValue = input / 1000;
                else if (from == "Ton") baseValue = input * 1000;
                else if (from == "Pound") baseValue = input * 0.453592;

                // 2. Adım: Hedef birime çevir
                double result = 0;
                if (to == "Metre") result = baseValue;
                else if (to == "Kilometre") result = baseValue / 1000;
                else if (to == "Santimetre") result = baseValue * 100;
                else if (to == "Mil") result = baseValue / 1609.34;

                else if (to == "Kilogram") result = baseValue;
                else if (to == "Gram") result = baseValue * 1000;
                else if (to == "Ton") result = baseValue / 1000;
                else if (to == "Pound") result = baseValue / 0.453592;

                txtConvOutput.Text = Math.Round(result, 4).ToString();
            }
            else
            {
                // Geçersiz giriş varsa hata mesajı gösterme, sadece çıktıyı temizle (Daha iyi UX)
                txtConvOutput.Text = "";
            }
        }

        // --- YARDIMCI FONKSİYONLAR ---
        private void SwitchTab(bool isCalculator)
        {
            if (isCalculator)
            {
                btnCalcTab.BackColor = accentColor;
                btnConvTab.BackColor = panelColor;
                calcPanel.BringToFront();
            }
            else
            {
                btnCalcTab.BackColor = panelColor;
                btnConvTab.BackColor = accentColor;
                convPanel.BringToFront();
            }
        }

        private Button CreateFlatButton(string text, Color bg)
        {
            return new Button
            {
                Text = text,
                BackColor = bg,
                ForeColor = textColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = ControlPaint.Light(bg) }
            };
        }
    }
}