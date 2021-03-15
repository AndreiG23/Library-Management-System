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
    public partial class MeniuAdmin : Form
    {
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Projects\Library Management System\Library Management System\Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        public MeniuAdmin()
        {
            InitializeComponent();
        }

        private void MeniuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MeniuAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bibliotecaDataSet.Carti' table. You can move, or remove it, as needed.
            this.cartiTableAdapter.Fill(this.bibliotecaDataSet.Carti);
            Sterge.Text = "Sterge";
            Sterge.UseColumnTextForButtonValue = true;
                
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==5)
            {
               
                
                SqlConnection con = new SqlConnection(constr);
               
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete FROM Carti WHERE Id='" +dataGridView1[0,e.RowIndex].Value + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                cmd.Dispose();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
               SqlConnection con = new SqlConnection(constr);
                con.Open();
               SqlDataAdapter adapt = new SqlDataAdapter("select * from Carti where Titlu like '" + textBox1.Text + "%'", con);
               DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
        }
        void refresh()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Carti where Titlu like '" + "" + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("select * from Carti where Titlu like '" + textBox1.Text + "%'", con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Carti (Titlu,Autor,Editura) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
                cmd.ExecuteNonQuery();
                //dataGridView1.Rows.Add(textBox2.Text, textBox3.Text, textBox4.Text, "");
                this.cartiTableAdapter.Fill(this.bibliotecaDataSet.Carti);
                refresh();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Carte adaugata!!");
            }
            else MessageBox.Show("Completeaza toate casutele!!");
        }
    }
}
