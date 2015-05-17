using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ManagingAdmissionContest
{
    public partial class Form4 : Form
    {
        IApplicantDatabase appDatabase = ApplicantDatabase.InitializeDatabase("applicantTable.txt");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            List<Applicant> applicants = appDatabase.SelectAllRecords();
            List<DataGridGroupObject> group = new List<DataGridGroupObject>();
            var blist = new BindingList<Applicant>(applicants);
            dataGridView1.DataSource = blist;
                
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            
            string[,] myGridData = new string[dataGridView1.Rows.Count, 3];
            
            int i = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                myGridData[i,0] = row.Cells[0].Value.ToString();
                myGridData[i,1] = row.Cells[1].Value.ToString();
                myGridData[i,2] = row.Cells[2].Value.ToString();
                myGridData[i, 3] = row.Cells[3].Value.ToString();
                myGridData[i, 4] = row.Cells[4].Value.ToString();
                myGridData[i, 5] = row.Cells[5].Value.ToString();
                myGridData[i, 6] = row.Cells[6].Value.ToString();
                myGridData[i, 7] = row.Cells[7].Value.ToString();
                List<Applicant> listA = appDatabase.SelectRecords("Id", myGridData[i, 0]);
              
                foreach (Applicant a in listA) { 
                    if (!a.Surname.Equals(myGridData[i,1])){
                        Debug.Assert(Regex.IsMatch(myGridData[i,1], @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere"));
                        appDatabase.UpdateRecords("Id",a.Id, "Surname",myGridData[i,1]);
                    }
                    if(!a.Name.Equals(myGridData[i,2])){
                         Debug.Assert(Regex.IsMatch(myGridData[i,2], @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere");
                         appDatabase.UpdateRecords("Id",a.Id, "Name",myGridData[i,2]);
                    }
                    if(a.TestGrade!=Convert.ToDouble(myGridData[i,3])){
                        Debug.Assert(Convert.ToDouble(myGridData[i,3])>=5 && Convert.ToDouble(myGridData[i,3])<=10,"Nota trebuie sa fie intre 5 si 10");
                        appDatabase.UpdateRecords("Id", a.Id, "TestGrade", myGridData[i, 3]);
                    }
                    if (a.BacGrade != Convert.ToDouble(myGridData[i, 4]))
                    {   Debug.Assert(Convert.ToDouble(myGridData[i,3])>=5 && Convert.ToDouble(myGridData[i,4])<=10,"Nota trebuie sa fie intre 5 si 10");
                        appDatabase.UpdateRecords("Id", a.Id, "BacGrade", myGridData[i, 4]);
                    }
                    if (a.InfoGrade!= Convert.ToDouble(myGridData[i, 5]))
                    {   Debug.Assert(Convert.ToDouble(myGridData[i,3])>=5 && Convert.ToDouble(myGridData[i,5])<=10,"Nota trebuie sa fie intre 5 si 10");
                        appDatabase.UpdateRecords("Id", a.Id, "InfoGrade", myGridData[i, 5]);
                    }
                    if (a.MathGrade != Convert.ToDouble(myGridData[i, 6]))
                    {   Debug.Assert(Convert.ToDouble(myGridData[i,3])>=5 && Convert.ToDouble(myGridData[i,6])<=10,"Nota trebuie sa fie intre 5 si 10");
                        appDatabase.UpdateRecords("Id", a.Id, "MathGrade", myGridData[i, 6]);
                    }
                    
                }



                i++;
            }
        }

        private void DataGridView1_CellValueChanged(
           object sender, DataGridViewCellEventArgs e)
        {
            // Update the balance column whenever the value of any cell changes.
            UpdateDB();
        }

        private void UpdateDB() { 
        
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
