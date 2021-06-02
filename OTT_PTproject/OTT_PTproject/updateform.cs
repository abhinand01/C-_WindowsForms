using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace OTT_PTproject
{
    public partial class updateform : Form
    {
        public updateform()
        {
            InitializeComponent();
        }
        int newotp { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\Ott.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "select * from [Table] where email = '" + textBox2.Text + "'" ;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                try
                {
                    Random otp = new Random();
                    newotp = otp.Next(10000, 99999);
                    string to, from, pass, mail;
                    to = (textBox2.Text).ToString();
                    from = "ottplatform.gui@gmail.com";
                    mail = "your One time password for email verification  :" + newotp;
                    pass = "CS1001&19";
                    MailMessage message = new MailMessage();
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = mail;
                    message.Subject = "OTP for forgot Password  ";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.Send(message);
                    MessageBox.Show("OTP send succesful");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Incorrect email", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int abc = Int32.Parse(textBox1.Text);
            if (abc == newotp)
            {
                try
                {
                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\Ott.mdf;Integrated Security=True;Connect Timeout=30");

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("update [TABLE] set username= '" + textBox3.Text.Trim() + "', password = '" +textBox4.Text.Trim() +"' where email= '"+textBox2.Text.Trim()+"' ", Con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    Con.Close();
                    Form1 f = new Form1();
                    f.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("wrong!!!!!");
                }
            }
            else
            {
                MessageBox.Show("Wrong OTP");
                Form1 f = new Form1();
                f.Show();
                this.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
}
