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
        char[] spec_chars = new char[] {'%', '(','$','&','#',')','~' };
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
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
        }
    }
}
