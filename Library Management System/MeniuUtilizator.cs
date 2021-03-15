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
    public partial class MeniuUtilizator : Form
    {
        string Email, Pass,nume,prenume;            
        string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Projects\Library Management System\Library Management System\Biblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        public MeniuUtilizator()
        {
            InitializeComponent();
            Email = LoginForm.email;
            Pass = LoginForm.pass;
            
            SqlConnection con = new SqlConnection(constr);
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Select Nume,Prenume from Utilizatori where Email='"+Email+"' AND Parola='"+Pass+"' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            nume = dr.GetValue(0).ToString();
            prenume = dr.GetValue(1).ToString();

            fill();
            con.Close();
            Imprumuta.Text = "Imprumuta";
            Imprumuta.UseColumnTextForButtonValue = true;
            Returneaza.Text = "Returneaza";
            Returneaza.UseColumnTextForButtonValue = true;
            
            
        }

        private void MeniuUtilizator_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        void fill()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("Select Id,Titlu,Autor,Editura from Carti where Detinator ='"+nume+" "+prenume+"' ", con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            
            adapt.Fill(this.bibliotecaDataSet3.Carti);
            
        }
        void refresh()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("Select Id,Titlu,Autor,Editura from Carti where Detinator IS NULL ", con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(this.bibliotecaDataSet.Carti);
        }
        private void MeniuUtilizator_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bibliotecaDataSet3.Carti' table. You can move, or remove it, as needed.
            
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select Id,Titlu,Autor,Editura from Carti where Detinator IS NULL ", con);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(this.bibliotecaDataSet.Carti);
            Imprumuta.Text = "Imprumuta";
            Imprumuta.UseColumnTextForButtonValue = true;
            Returneaza.Text = "Returneaza";
            Returneaza.UseColumnTextForButtonValue = true;


        }

       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                


                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand("Update Carti set Detinator='" + nume+" "+prenume + "' where Id='" + Convert.ToInt32(dataGridView1[0, e.RowIndex].Value) + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                fill();
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                cmd.Dispose();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {


                SqlConnection con = new SqlConnection(constr);

                con.Open();
                SqlCommand cmd = new SqlCommand("Update Carti set Detinator=NULL where Id='" + Convert.ToInt32(dataGridView2[0, e.RowIndex].Value) + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                refresh();
                dataGridView2.Rows.RemoveAt(e.RowIndex);
                cmd.Dispose();
            }
        }
    }
}
