using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class LoginForm : Form
    {

        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Projects\Library Management System\Library Management System\Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        public LoginForm()
        {
            InitializeComponent();
        }
        public static string email,pass;

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Email,Parola from Utilizatori", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (textBox1.Text==dr.GetValue(0).ToString()   &&  textBox2.Text==dr.GetValue(1).ToString() )
                    {
                        ok = true;
                        if (textBox1.Text == "admin@gmail.com")
                        {
                            MeniuAdmin w = new MeniuAdmin();
                            this.Hide();
                            w.ShowDialog();
                        }
                        else
                        {
                            email = textBox1.Text;
                            pass = textBox2.Text;
                            MeniuUtilizator w = new MeniuUtilizator();
                            this.Hide();
                            w.ShowDialog();
                        }
                    }
                }
                if (ok == false)
                    MessageBox.Show("Email sau Parola gresita!!");
            }
            else MessageBox.Show("Completati toate casutele!!");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
