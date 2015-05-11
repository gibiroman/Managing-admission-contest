using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagingAdmissionContest
{
    public partial class Form2 : Form
    {
        IApplicantDatabase appDatabase = ApplicantDatabase.InitializeDatabase("applicantTable.txt");
        HtmlGenerator hg = new HtmlGenerator();
        PDFGenerator pg = new PDFGenerator();
        AdmissionManager am = new AdmissionManager();
        public Form2()
        {
            InitializeComponent();
            Utils u = new Utils();
            u.TestPopulateDatabase(appDatabase);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.MaximizeBox = false;
        }
        private void budgetFinanced_TextChanged(object sender, EventArgs e)
        {  
            
            int result = 0;
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text))
                MessageBox.Show("Field cannot be empty");
            
            if (!Int32.TryParse(budgetFinanced.Text, out result))
            {
                MessageBox.Show("Please enter only numbers.");

                if (budgetFinanced.Text.Length >= 1)
                {
                    budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                }
            }
        }


        private void feePayer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(feePayer.Text))
                MessageBox.Show("Field cannot be empty");
            int result = 0;

            if (!Int32.TryParse(feePayer.Text, out result))
            {
                MessageBox.Show("Please enter only numbers.");

                if (feePayer.Text.Length >= 1)
                {
                    feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text) || string.IsNullOrWhiteSpace(feePayer.Text))
            {
                MessageBox.Show("Field cannot be empty");
                return;
            }
          
            Form3 fm = new Form3();
            DataGridView dg = new DataGridView();
            dg.Name = "dataResults";
            dg.ColumnCount = 3;
            dg.Columns[0].HeaderText = "Name";
            dg.Columns[1].HeaderText = "Grade";
            dg.Columns[2].HeaderText = "Status";
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            var listApplicantsSortedByGrade = am.getSortedList();
            foreach (Applicant applicant in listApplicantsSortedByGrade)
            {
                var index = listApplicantsSortedByGrade.IndexOf(applicant);
                var limitTotalAdmitted = Double.Parse(budgetFinanced.Text) + Double.Parse(feePayer.Text);

                XSolidBrush brush;
                string typeCandidate = am.getStudentStatus(index);
                dg.Rows.Add(applicant.Name + " " + applicant.Surname, applicant.AdmissionGrade, typeCandidate);
            }

            fm.Controls.Add(dg);
            fm.Show();
            this.Hide();

            
        }
       
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text) || string.IsNullOrWhiteSpace(feePayer.Text))
            {
                MessageBox.Show("Field cannot be empty");
                return;
            }
          
            pg.WriteResultsToPdfFile(am.getSortedList(), Double.Parse(budgetFinanced.Text), Double.Parse(feePayer.Text));
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text) || string.IsNullOrWhiteSpace(feePayer.Text))
            {
                MessageBox.Show("Field cannot be empty");
                return;
            }
          
           hg.WriteResultsToHTML(am.getSortedList(), Double.Parse(budgetFinanced.Text), Double.Parse(feePayer.Text));
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }
    }
}