using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm w = new LoginForm();
            this.Hide();
            w.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm w = new RegisterForm();
            this.Hide();
            w.ShowDialog();
        }
    }
}
