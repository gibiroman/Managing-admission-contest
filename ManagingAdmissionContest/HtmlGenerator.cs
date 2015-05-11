using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PdfSharp.Drawing;

namespace ManagingAdmissionContest
{
    public class HtmlGenerator
    {
        public static bool WriteResultsToHTML(List<Applicant> listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
        {
            bool retVal = true;

            if (listApplicantsSortedByGrade.Count <= 0)
                return false;

            if (limitFeePayer < limitBudget)
                return false;

            if (limitBudget <= 0 || limitFeePayer <= 0)
                return false;

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

                    }
                    else if (index < limitTotalAdmitted)
                    {
                        typeCandidate = "fee payer";

                    }
                    else
                    {
                        typeCandidate = "rejected";

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

            return retVal;
        }
    }
}
