using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }
        private bool passwordVisible = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "user" && textBox2.Text == "user")
            {
                Main m = new Main();
                this.Hide();
                m.Show();
            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                MessageBox.Show("Неверные данные!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            if (passwordVisible)
            {
                textBox2.PasswordChar = '\0'; 
            }
            else
            {
                textBox2.PasswordChar = '*'; 
            }
        }
    }
}
