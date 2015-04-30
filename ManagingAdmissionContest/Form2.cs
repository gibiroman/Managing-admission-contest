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
            
            decimal result = 0;

            if (Decimal.TryParse(budgetFinanced.Text, out result))
            {
                if (result < 5)
                {
                    MessageBox.Show("Inferior limit for rejected applicants!");

                    if (budgetFinanced.Text.Length >= 1)
                    {
                        budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                    }
                }
                else if (result > 10)
                {
                    MessageBox.Show("Grade is to high!");

                    if (budgetFinanced.Text.Length >= 1)
                    {
                        budgetFinanced.Text = budgetFinanced.Text.Remove(budgetFinanced.Text.Length - 1);
                    }
                }
            }
            else
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
            decimal result = 0, resultsBudget = 0;

            if (Decimal.TryParse(feePayer.Text, out result))
            {
                if (result < 5)
                {
                    MessageBox.Show("Inferior limit for rejected applicants");

                    if (feePayer.Text.Length >= 1)
                    {
                        feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                    }
                }
                else if (result > 10)
                {
                    MessageBox.Show("Grade is to high!");

                    if (feePayer.Text.Length >= 1)
                    {
                        feePayer.Text = feePayer.Text.Remove(budgetFinanced.Text.Length - 1);
                    }
                }
                else if (Decimal.TryParse(budgetFinanced.Text, out resultsBudget))
                {
                    if (resultsBudget < result)
                    {
                        MessageBox.Show("Limit for fee payer must be lower than budget financed.");

                        if (feePayer.Text.Length >= 1)
                        {
                            feePayer.Text = feePayer.Text.Remove(feePayer.Text.Length - 1);
                        }
                    }
                }
            }
            else
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
            dg.ColumnCount = 3;
            dg.Columns[0].HeaderText = "Name";
            dg.Columns[1].HeaderText = "Grade";
            dg.Columns[2].HeaderText = "Status";
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            for (int iApp = getSortedList().Count - 1; iApp >= 0; iApp--)
            {
                Applicant applicant = getSortedList().GetByIndex(iApp) as Applicant;

                double avgGrade = (double)getSortedList().GetKey(iApp);

                avgGrade = Math.Round(avgGrade, 2);
                string typeCandidate = "";
                if (avgGrade >= Double.Parse(budgetFinanced.Text))
                {
                    typeCandidate = "budget-financed";
                }
                else if (avgGrade < Double.Parse(budgetFinanced.Text) && avgGrade >= Double.Parse(feePayer.Text))
                {
                    typeCandidate = "fee payer";


                }
                else
                {
                    typeCandidate = "rejected";


                }
              dg.Rows.Add(applicant.Name+" "+applicant.Surname, avgGrade, typeCandidate);
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

        private SortedList getSortedList()
        {
            List<Applicant> listApplicants = appDatabase.SelectAllRecords();

            SortedList listApplicantsSortedByGrade = new SortedList();

            for (int iApp = 0; iApp < listApplicants.Count; iApp++)
            {
                Applicant applicant = listApplicants[iApp];

                double avgPonderateGrade = (applicant.BacGrade + applicant.InfoGrade + applicant.MathGrade) / 3;

                listApplicantsSortedByGrade.Add(avgPonderateGrade, applicant);
            }
            return listApplicantsSortedByGrade;
        }

        private void WriteResultsToPdfFile(SortedList listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
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

            for (int iApp = listApplicantsSortedByGrade.Count - 1; iApp >= 0; iApp--)
            {
                Applicant applicant = listApplicantsSortedByGrade.GetByIndex(iApp) as Applicant;

                double avgGrade = (double)listApplicantsSortedByGrade.GetKey(iApp);

                avgGrade = Math.Round(avgGrade, 2);
                XSolidBrush brush;
                string typeCandidate = "";
                if (avgGrade >= limitBudget)
                {
                    typeCandidate = "budget-financed";

                    brush = XBrushes.Green;
                }
                else if (avgGrade < limitBudget && avgGrade >= limitFeePayer)
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

                graph.DrawString(avgGrade.ToString(), fontEntries, XBrushes.Black, new XRect(280, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

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



        private void WriteResultsToHTML(SortedList listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
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
                for (int iApp = listApplicantsSortedByGrade.Count - 1; iApp >= 0; iApp--)
                {
                    Applicant applicant = listApplicantsSortedByGrade.GetByIndex(iApp) as Applicant;

                    double avgGrade = (double)listApplicantsSortedByGrade.GetKey(iApp);

                    avgGrade = Math.Round(avgGrade, 2);
                    string typeCandidate = "";
                    if (avgGrade >= limitBudget)
                    {
                        typeCandidate = "budget-financed";
                    }
                    else if (avgGrade < limitBudget && avgGrade >= limitFeePayer)
                    {
                        typeCandidate = "fee payer";


                    }
                    else
                    {
                        typeCandidate = "rejected";


                    }
                    sw.WriteLine("<td>" + applicant.Surname + " " + applicant.Name + "<td>");
                    sw.WriteLine("<td>" + avgGrade + "</td>");
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
    }
}