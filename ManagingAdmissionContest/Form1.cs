using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text)
                )
            {
                MessageBox.Show("All fields must be field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(textBox4.Text, out myDec))
            {
                MessageBox.Show("Baccalaureat grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(textBox5.Text, out myDec))
            {
                MessageBox.Show("Computer Science grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!decimal.TryParse(textBox6.Text, out myDec))
            {
                MessageBox.Show("Mathematics grade must be a decimal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             else
            {
                string surname = textBox1.Text;
                string name = textBox2.Text;
                string cnp = textBox3.Text;
                string notaBac = textBox4.Text;
                string notaInfo = textBox5.Text;
                string notaMate = textBox6.Text;
                string notaTest = textBox7.Text;
                this.Hide();
                Applicant applicant = new Applicant(cnp, surname, name, Double.Parse(notaTest), Double.Parse(notaBac), Double.Parse(notaInfo), Double.Parse(notaMate),0.0);
                appDatabase.InsertRecord(applicant);
                MessageBox.Show("Success!");
            }
            

        }

        public string getName
        {
            get { return "Nume: " + textBox2.Text; }
        }
        public string getFirstname
        {
            get { return "Prenume: " + textBox1.Text; }
        }
        public string getNo
        {
            get { return "Nr. legitimatie: " + textBox3.Text; }
        }

        public string getNotaBac
        {
            get { return "Nota Bacalaureat: " + textBox4.Text; }
        }

        public string getNotaMate
        {
            get { return "Nota Matematica: " +textBox6.Text; }
        }

        public string getNotaInfo
        {
            get { return "Nota Informatica " + textBox5.Text; }
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
