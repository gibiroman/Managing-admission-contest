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
    public partial class Form1 : Form
    {
        IApplicantDatabase appDatabase = ApplicantDatabase.InitializeDatabase("applicantTable.txt");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            decimal myDec;
            if (string.IsNullOrWhiteSpace(firstname.Text) ||
                string.IsNullOrWhiteSpace(lastname.Text) ||
                string.IsNullOrWhiteSpace(badgeNo.Text) ||
                string.IsNullOrWhiteSpace(bacGrade.Text) ||
                string.IsNullOrWhiteSpace(csGrade.Text) ||
                string.IsNullOrWhiteSpace(mathGrade.Text)
                )
            {
                MessageBox.Show("All fields must be field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(bacGrade.Text, out myDec))
            {
                MessageBox.Show("Baccalaureat grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(csGrade.Text, out myDec))
            {
                MessageBox.Show("Computer Science grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(mathGrade.Text, out myDec))
            {
                MessageBox.Show("Mathematics grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             else
            {
                string surname = firstname.Text;
                string name = lastname.Text;
                string cnp = badgeNo.Text;
                string notaBac = bacGrade.Text;
                string notaInfo = csGrade.Text;
                string notaMate = mathGrade.Text;
                string notaTest = testGrade.Text;
                Debug.Assert(Convert.ToInt32(bacGrade) <= 10,"Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(bacGrade) > 5, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(csGrade) <= 10, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(csGrade) > 5, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(mathGrade) <= 10, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(mathGrade) > 5, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(testGrade) <= 10, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Convert.ToInt32(testGrade) > 5, "Nota trebuie sa fie intre 5 si 10");
                Debug.Assert(Regex.IsMatch(firstname.Text, @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere");
                Debug.Assert(Regex.IsMatch(lastname.Text, @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere");
                Debug.Assert(Regex.IsMatch(firstname.Text, @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere");
                Debug.Assert(Regex.IsMatch(badgeNo.Text, @"^[a-zA-Z0-9]+$"), "Acest camp trebuie sa contina doar litere si cifre");
                this.Hide();
                Applicant applicant = new Applicant(cnp, surname, name, Double.Parse(notaTest), Double.Parse(notaBac), Double.Parse(notaInfo), Double.Parse(notaMate),0.0);
                Debug.Assert(applicant != null);
                appDatabase.InsertRecord(applicant);
                MessageBox.Show("Success!");
            }
            

        }

        public string getName
        {
            get { return "Nume: " + lastname.Text; }
        }
        public string getFirstname
        {
            get { return "Prenume: " + firstname.Text; }
        }
        public string getNo
        {
            get { return "Nr. legitimatie: " + badgeNo.Text; }
        }

        public string getNotaBac
        {
            get { return "Nota Bacalaureat: " + bacGrade.Text; }
        }

        public string getNotaMate
        {
            get { return "Nota Matematica: " +mathGrade.Text; }
        }

        public string getNotaInfo
        {
            get { return "Nota Informatica " + csGrade.Text; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
