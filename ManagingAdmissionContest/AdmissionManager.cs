using ManagingAdmissionContest;
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
public class AdmissionManager
{
    IApplicantDatabase appDatabase = ApplicantDatabase.InitializeDatabase("applicantTable.txt");
    public int limitBudget { get; set; }
    public double limitTotalAdmitted { get; set; }
	public AdmissionManager(){
       

	}

    public List<Applicant> getSortedList()
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

    public string getStudentStatus(int index){
        string typeCandidate = "";
        if (index < limitBudget)
        {
            typeCandidate = "budget-financed";

        }
        else if (index < limitTotalAdmitted)
        {
            typeCandidate = "fee payer";

        }
        else
        {
            typeCandidate = "rejected";
            
        }
        return typeCandidate;
    }



}
