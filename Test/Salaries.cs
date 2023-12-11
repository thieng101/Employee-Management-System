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
    public partial class Salaries : Form
    {
        Functions Con;
        public Salaries()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalary();
            GetEmployees();
        }

        private void GetEmployees()
        {
            string Query = "select * from EmployeeTbl";
            EmpTb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpTb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpTb.DataSource = Con.GetData(Query);
        }

        int DSal = 0;
        string Period = "";
        private void GetSalary()
        {
            string Query = "select EmpSal from EmployeeTbl where EmpId = {0}";
            Query = string.Format(Query,EmpTb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }
            //MessageBox.Show("" + DSal);
            
            if(DaysTb.Text == "")
            {
                AmountTb.Text = "$" +  DSal; //NOTE:Use convert integer here
            }else if(Convert.ToInt32(DaysTb.Text) > 31)
            {
                MessageBox.Show("Days Can not Be Greater Than 31");
            }
            else
            {
                d = Convert.ToInt32(DaysTb.Text);
                AmountTb.Text = "$" + (d * DSal);
            }

        }

        private void ShowSalary()
        {
            string Query = "Select * from SalaryTbl";
            SalaryList.DataSource = Con.GetData(Query);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int Key = 0;
        private void SalaryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpTb.SelectedValue = SalaryList.SelectedRows[0].Cells[1].Value.ToString();
            DaysTb.Text = SalaryList.SelectedRows[0].Cells[2].Value.ToString();
            PeriodTb.Text = SalaryList.SelectedRows[0].Cells[3].Value.ToString();
            AmountTb.Text = SalaryList.SelectedRows[0].Cells[4].Value.ToString();

            if (EmpTb.SelectedIndex == -1)
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SalaryList.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void EmpTb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }

        int d = 1;
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(EmpTb.SelectedIndex == -1 || DaysTb.Text == "" || PeriodTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    Period = PeriodTb.Value.ToString("MM-yyyy");
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);

                    int Days = Convert.ToInt32(DaysTb.Text);

                    string Query = "Insert into SalaryTbl values({0},{1},'{2}',{3},'{4}')";
                    Query = string.Format(Query, EmpTb.SelectedValue.ToString(), Days, Period, Amount, DateTime.Today.Date);
                    Con.SetData(Query);
                    ShowSalary();
                    MessageBox.Show("Salary Paid!!!");
                    DaysTb.Text = "";
                    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void DepLbl_Click(object sender, EventArgs e)
        {
            Department Obj = new Department();
            Obj.Show();
            this.Hide();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpTb.SelectedIndex == -1 || DaysTb.Text == "" || PeriodTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!");
                }
                else
                {
                    GetSalary();
                    Period = PeriodTb.Value.ToString("MM-yyyy");
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int Days = Convert.ToInt32(DaysTb.Text);

                    string Query = "Update SalaryTbl set Attendance = {0}, Period = '{1}', Amount = {2}, PayDate = '{3}' where Employee = {4}";
                    Query = string.Format(Query,Days, Period, Amount, DateTime.Today.Date, Key);
                    Con.SetData(Query);
                    ShowSalary();
                    MessageBox.Show("Salary Updated!!!");
                    DaysTb.Text = "";
                    AmountTb.Text = "";
                    EmpTb.SelectedIndex = -1;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PeriodTb_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
