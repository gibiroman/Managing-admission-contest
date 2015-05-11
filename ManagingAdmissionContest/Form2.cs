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
        public Form2()
        {
            InitializeComponent();

            TestPopulateDatabase(appDatabase);
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

            var listApplicantsSortedByGrade = getSortedList();
            foreach (Applicant applicant in listApplicantsSortedByGrade)
            {
                var index = listApplicantsSortedByGrade.IndexOf(applicant);
                var limitTotalAdmitted = Double.Parse(budgetFinanced.Text) + Double.Parse(feePayer.Text);

                XSolidBrush brush;
                string typeCandidate = "";
                if (index < Double.Parse(budgetFinanced.Text))
                {
                    typeCandidate = "budget-financed";
                    brush = XBrushes.Green;
                }
                else if (index < limitTotalAdmitted)
                {
                    typeCandidate = "fee payer";
                    brush = XBrushes.Black;
                }
                else
                {
                    typeCandidate = "rejected";
                    brush = XBrushes.Red;
                }

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
          
            WriteResultsToPdfFile(getSortedList(), Double.Parse(budgetFinanced.Text), Double.Parse(feePayer.Text));
            this.Hide();
        }

        private List<Applicant> getSortedList()
        {
            List<Applicant> listApplicants = appDatabase.SelectAllRecords();

            foreach (var applicant in listApplicants)
            {
                var index = listApplicants.IndexOf(applicant);
                var grades = new List<double> { applicant.MathGrade, applicant.InfoGrade, applicant.TestGrade };
                double avgPonderateGrade = applicant.TestGrade / 2 + applicant.BacGrade / 4 + grades.Max() / 4;

                applicant.AdmissionGrade = avgPonderateGrade;
            }

            var listApplicantsSortedByGrade = listApplicants.OrderByDescending(s => s.AdmissionGrade).ToList();

            return listApplicantsSortedByGrade;
        }

        private void WriteResultsToPdfFile(List<Applicant> listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
        {
            PdfDocument pdf = new PdfDocument();

            PdfPage pdfPage = pdf.AddPage();

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            XFont fontTitle = new XFont("Verdana", 20, XFontStyle.Regular);

            graph.DrawString("Faculty admission contest",
                            fontTitle,
                            XBrushes.Black,
                            new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point),
                            XStringFormats.TopCenter
                            );

            int yPoint = 40;

            XFont fontEntries = new XFont("Verdana", 16, XFontStyle.Regular);

            foreach (Applicant applicant in listApplicantsSortedByGrade)
            {
                var index = listApplicantsSortedByGrade.IndexOf(applicant);
                var limitTotalAdmitted = limitBudget + limitFeePayer;

                XSolidBrush brush;
                string typeCandidate = "";
                if (index < limitBudget)
                {
                    typeCandidate = "budget-financed";
                    brush = XBrushes.Green;
                }
                else if (index < limitTotalAdmitted)
                {
                    typeCandidate = "fee payer";
                    brush = XBrushes.Black;
                }
                else
                {
                    typeCandidate = "rejected";
                    brush = XBrushes.Red;
                }

                graph.DrawString(applicant.Surname + " " + applicant.Name, fontEntries, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(applicant.AdmissionGrade.ToString(), fontEntries, XBrushes.Black, new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                graph.DrawString(typeCandidate, fontEntries, brush, new XRect(420, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                yPoint = yPoint + 40;
            }
            
            pdf.Save("ResultsPDF.pdf");

            Process.Start("ResultsPDF.pdf");
        }

        private void TestPopulateDatabase(IApplicantDatabase appDatabase)
        {
            Applicant applicant1 = new Applicant("1910541231783", "Adrian", "Botez", 8, 8.75, 6, 7.75, 0.0);

            Applicant applicant2 = new Applicant("2342184593201", "Victor", "Rachieru", 7, 4.75, 4, 4.5, 0.0);

            Applicant applicant3 = new Applicant("1314541890188", "Marius", "Zavincu", 8, 9.75, 10, 6.75, 0.0);

            appDatabase.InsertRecord(applicant1);
            appDatabase.InsertRecord(applicant2);
            appDatabase.InsertRecord(applicant3);
        }

        private void WriteResultsToHTML(List<Applicant> listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
        {
            string path = "results.htm";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("<!DOCTYPE html>");
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<title>Results</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body >");
                sw.WriteLine("<table border = \"1\">");
                sw.WriteLine("<tr>");

                foreach (Applicant applicant in listApplicantsSortedByGrade)
                {
                    var index = listApplicantsSortedByGrade.IndexOf(applicant);
                    var limitTotalAdmitted = limitBudget + limitFeePayer;

                    XSolidBrush brush;
                    string typeCandidate = "";
                    if (index < limitBudget)
                    {
                        typeCandidate = "budget-financed";
                        brush = XBrushes.Green;
                    }
                    else if (index < limitTotalAdmitted)
                    {
                        typeCandidate = "fee payer";
                        brush = XBrushes.Black;
                    }
                    else
                    {
                        typeCandidate = "rejected";
                        brush = XBrushes.Red;
                    }

                    sw.WriteLine("<td>" + applicant.Surname + " " + applicant.Name + "<td>");
                    sw.WriteLine("<td>" + applicant.AdmissionGrade + "</td>");
                    sw.WriteLine("<td>" + typeCandidate + "<td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start("results.htm");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(budgetFinanced.Text) || string.IsNullOrWhiteSpace(feePayer.Text))
            {
                MessageBox.Show("Field cannot be empty");
                return;
            }
          
            WriteResultsToHTML(getSortedList(), Double.Parse(budgetFinanced.Text), Double.Parse(feePayer.Text));
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