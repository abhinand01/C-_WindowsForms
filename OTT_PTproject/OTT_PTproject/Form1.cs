using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTT_PTproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void sendusername(string str);
        public sendusername send;

        private void button2_Click(object sender, EventArgs e)
        {
            signup s = new signup();
            s.Show();
            this.Hide();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string Name=null;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\Documents\Ott.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "select * from [Table] where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("LOGIN SUCCESS!!");
                try { 
                using (SqlCommand command = new SqlCommand("SELECT name FROM [Table] where username ='" +textBox1.Text +"' ", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                             Name = reader[0].ToString();
                            
                        }
                    }
                }
                    netflix nx = new netflix();
                    this.send += new sendusername(nx.gettext);
                    send(Name);
                    nx.Show();

                }
            catch (Exception ex)
            {
                //error handling...
            }
               

             
            }
            else
            {
                MessageBox.Show("Incorrect Password or incorrect username", "Error");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateform u = new updateform();
            u.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
