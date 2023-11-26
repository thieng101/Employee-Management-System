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
    public partial class Employees : Form
    {
        Functions Con;
        
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();

        }

        private void ShowEmp()
        {
            string Query = "Select * from EmployeeTbl";
            EmployeeList.DataSource = Con.GetData(Query);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void GetDepartment()
        {
            string Query = "select * from DepartmentTbl";
            DepCh.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCh.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCh.DataSource = Con.GetData(Query);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Display the date as "MM-DD-YYYY".  
            //DOBTb.Format = DateTimePickerFormat.Custom;
            //DOBTb.CustomFormat = "yyyy-MM-dd";

            //JDateTb.Format = DateTimePickerFormat.Custom;
            //JDateTb.CustomFormat = "yyyy-MM-dd";

            try
            {
                if (EmpNameTb.Text == "" || GenCh.SelectedIndex == -1 || DepCh.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data at Department!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCh.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCh.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString("yyyy-MM-dd");
                    string JDate = JDateTb.Value.Date.ToString("yyyy-MM-dd");
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "Insert into EmployeeTbl values('{0}','{1}',{2},'{3}','{4}',{5})";
                    Query = string.Format(Query,Name,Gender,Dep,DOB,JDate,Salary);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added!!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCh.SelectedIndex = -1;  
                    DepCh.SelectedIndex = -1;   


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DOBTb_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
