using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace fitness
{
    public partial class Auth : Form
    {
        private bool passwordVisible = false;
        private string captchaText;
        public Auth()
        {
            InitializeComponent();
            сaptcha();
        }
        private void сaptcha()
        {
            Bitmap captchaImage = CaptchaGenerator.GenerateCaptcha(out captchaText);
            pictureBox1.Image = captchaImage;
        }
        public class CaptchaGenerator
        {
            private static Random random = new Random();

            public static Bitmap GenerateCaptcha(out string captchaText)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                captchaText = new string(Enumerable.Range(0, 4).Select(x => chars[random.Next(chars.Length)]).ToArray());
                int width = 199; 
                int height = 69; 
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    Font font = new Font("Arial", 22, FontStyle.Bold); 
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    for (int i = 0; i < captchaText.Length; i++)
                    {
                        int x = random.Next(width / captchaText.Length * i, width / captchaText.Length * (i + 1) - 10); 
                        int y = random.Next(15, height - 15);
                        int rotationAngle = random.Next(-20, 20);
                        Matrix matrix = new Matrix();
                        matrix.RotateAt(rotationAngle, new PointF(x + (float)width / captchaText.Length / 2, y + (float)height / 2)); 
                        g.Transform = matrix;
                        g.DrawString(captchaText[i].ToString(), font, Brushes.Black, new PointF(x, y), stringFormat);
                        g.ResetTransform();
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        int startX = random.Next(0, width / 4);
                        int startY = random.Next(10, height - 10);
                        int endX = random.Next(width / 4 * 3, width);
                        g.DrawLine(new Pen(Color.Black, 2), endX, startX, startY, startY);
                    }
                }
                return bmp;
            }
        }
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
