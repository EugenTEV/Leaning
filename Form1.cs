using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Random rnd;
        Dictionary<string, double> metrica;
        char[] spec_chars = new char[] {'%', '(','$','&','#',')','~' };
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary<string, double>();
            metrica.Add("мм", 1);
            metrica.Add("см", 10);
            metrica.Add("дм", 100);
            metrica.Add("м", 1000);
            metrica.Add("км", 1000000);
            metrica.Add("мили", 1609344);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCreatPassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) 
            {
                return;
            }
            string password = "";
            for (int i = 0; i < nudPassLenght.Value; i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Цифры": password += rnd.Next(10).ToString();
                        break;
                    case "Прописные буквы": password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "Строчные буквы":
                        password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    case "Спецсимволы":
                        password += spec_chars[rnd.Next(spec_chars.Length)];
                        break;                    
                }
                tbPassword.Text = password;
                Clipboard.SetText(password);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clbPassword.SetItemChecked(0, true);
            clbPassword.SetItemChecked(1, true);
            clbPassword.SetItemChecked(2, true);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double m1 = metrica[cbFrom.Text];
            double m2 = metrica[cbTo.Text];
            double n = Convert.ToDouble(tbFrom.Text);
            tbTo.Text = (n * m1 / m2).ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = cbFrom.Text;
            cbFrom.Text = cbTo.Text;
            cbTo.Text = t;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetric.Text  )
            {
                case "Длина":
                    metrica.Clear();
                    metrica.Add("мм", 1);
                    metrica.Add("см", 10);
                    metrica.Add("дм", 100);
                    metrica.Add("м", 1000);
                    metrica.Add("км", 1000000);
                    metrica.Add("мили", 1609344);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("мм");
                    cbFrom.Items.Add("см");
                    cbFrom.Items.Add("дм");
                    cbFrom.Items.Add("м");
                    cbFrom.Items.Add("км");
                    cbFrom.Items.Add("мили");

                    cbTo.Items.Clear();
                    cbTo.Items.Add("мм");
                    cbTo.Items.Add("см");
                    cbTo.Items.Add("дм");
                    cbTo.Items.Add("м");
                    cbTo.Items.Add("км");
                    cbTo.Items.Add("мили");

                    cbFrom.Text = "мм";
                    cbTo.Text = "мм";
                    break;
                case "Вес":
                    metrica.Clear();
                    metrica.Add("г", 1);
                    metrica.Add("кг", 1000);
                    metrica.Add("т", 1000000);
                    metrica.Add("lb", 453.6);
                    metrica.Add("oz", 283);
                    cbFrom.Items.Clear();
                    cbFrom.Items.Add("г");
                    cbFrom.Items.Add("кг");
                    cbFrom.Items.Add("т");
                    cbFrom.Items.Add("lb");
                    cbFrom.Items.Add("oz");

                    cbTo.Items.Clear();
                    cbTo.Items.Add("г");
                    cbTo.Items.Add("кг");
                    cbTo.Items.Add("т");
                    cbTo.Items.Add("lb");
                    cbTo.Items.Add("oz");

                    cbFrom.Text = "г";
                    cbTo.Text = "г";
                    break;
            }
        }
    }
}
