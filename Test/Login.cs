using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else if(UNameTb.Text == "Admin" && PasswordTb.Text == "Password") //how to create an admid?
            {
                Employees obj = new Employees();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password!!!");
                UNameTb.Text = "";
                PasswordTb.Text = "";
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            UNameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void UNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
