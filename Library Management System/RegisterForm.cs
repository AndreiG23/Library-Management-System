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
    
    public partial class RegisterForm : Form
    {string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Projects\Library Management System\Library Management System\Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Utilizatori(Nume,Prenume,Email,Adresa,Parola) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                cmd.ExecuteNonQuery();
                LoginForm w = new LoginForm();
                this.Hide();
                w.ShowDialog();

            }
            else MessageBox.Show("Completati toate casutele!!");
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
