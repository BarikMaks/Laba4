using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_4._1
{
    public partial class Form1 : Form
    {
        string login, password;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = txtLogin.Text;
            password = txtPassword.Text;
            Hide();
            Form2 a = new Form2(password);
            a.ShowDialog();
            Close();
        }
    }
}
