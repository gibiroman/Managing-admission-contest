﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ManagingAdmissionContest
{
    public partial class MainForm : Form
    {
        IApplicantDatabase appDatabase = ApplicantDatabase.InitializeDatabase("applicantDatabase\\applicantTable.txt");
        public MainForm()
        {   
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            m.Show();
            //this.Hide();
        }


        private void publishResults_Click(object sender, EventArgs e)
        {
           
            Form2 form = new Form2();
            //this.Hide();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "txt files (*.txt)|*.txt";
            Stream myStream = null;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = fd.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(myStream))
                        {
                            String line = sr.ReadLine();
                            char[] delimiterChars = { ',' };
                            string[] words = line.Split(delimiterChars);
                            Console.Write(words.Length);
                            Debug.Assert(words.Length != 7, "numarul de atribute trebuie sa fie = 7");
                            if (words.Length == 7)
                            {
                                Debug.Assert(Convert.ToInt32(words[3]) <= 10, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[3]) > 5, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[4]) <= 10, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[4]) > 5, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[5]) <= 10, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[5]) > 5, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[6]) <= 10, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Convert.ToInt32(words[6]) > 5, "Nota trebuie sa fie intre 5 si 10");
                                Debug.Assert(Regex.IsMatch(words[0], @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere");
                                Debug.Assert(Regex.IsMatch(words[1], @"^[a-zA-Z]+$"), "Acest camp trebuie sa contina doar litere");
  
                                Debug.Assert(Regex.IsMatch(words[2], @"^[a-zA-Z0-9]+$"), "Acest camp trebuie sa contina doar litere si cifre");
                                Applicant app = new Applicant(words[0], words[1], words[2], Double.Parse(words[3]), Double.Parse(words[4]), Double.Parse(words[5]), Double.Parse(words[6]),0.0);
                                appDatabase.InsertRecord(app);
                                MessageBox.Show("Success!");
                            }
                            else MessageBox.Show("Bad file format");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }




    }
}
