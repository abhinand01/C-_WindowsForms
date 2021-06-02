using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace OTT_PTproject
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }
         int newotp { get; set; }
        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Random otp = new Random();
                 newotp = otp.Next(10000, 99999);
                string to, from, pass, mail;
                to = (email.Text).ToString();
                from = "ottplatform.gui@gmail.com";
                mail = "your One time password for signup  :" + newotp;
                pass = "CS1001&19";
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = mail;
                message.Subject = "OTP for Sign up  ";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                smtp.Send(message);
                MessageBox.Show("OTP send succesful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void button1_Click(object sender, EventArgs e)
        {
            int abc = Int32.Parse(getotp.Text);
          
            if (abc == newotp)
            {


                try
                {
                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\Ott.mdf;Integrated Security=True;Connect Timeout=30");

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into [Table] values('" + name.Text.Trim() + "','" + email.Text.Trim() + "','" + dateTimePicker1.Value.Date.ToString("yyyyMMdd") + "','" + username.Text.Trim() + "','" + password.Text.Trim() + "')", Con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("YOU HAVE SIGNED IN SUCCESSFULLY!!");
                    Con.Close();
                    Form1 f = new Form1();
                    f.Show();

                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Already exsisting E mail Id or username");
                }
            }
            else
            {
                MessageBox.Show("otp wrong");
            }
            
                
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
}
