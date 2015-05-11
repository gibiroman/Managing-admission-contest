using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ManagingAdmissionContest
{
    class HtmlGenerator
    {
        public void WriteResultsToHTML(List<Applicant> listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
        {
            string path = "results.htm";
            AdmissionManager am = new AdmissionManager();
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

                    string typeCandidate = am.getStudentStatus(index);
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


    }
}
