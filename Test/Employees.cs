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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Missing Data at Department!!");
                }
                else
                {

                    string Query = "delete from EmployeeTbl where EmpId = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Deleted!!!");
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
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

                    string Query = "Update EmployeeTbl set EmpName = '{0}', EmpGen ='{1}', EmpDep = {2}, EmpDOB = '{3}', EmpJDate = '{4}', EmpSal = {5} where EmpId = {6}";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary, Key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Updated!!!");
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

        int Key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            GenCh.Text = EmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            DepCh.SelectedValue = EmployeeList.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = EmployeeList.SelectedRows[0].Cells[4].Value.ToString();
            JDateTb.Text = EmployeeList.SelectedRows[0].Cells[5].Value.ToString();
            DailySalTb.Text = EmployeeList.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {   
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void DepLbl_Click(object sender, EventArgs e)
        {
            Department Obj = new Department();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Salaries Obj = new Salaries();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EmpNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
