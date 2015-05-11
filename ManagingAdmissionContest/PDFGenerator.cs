using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ManagingAdmissionContest
{
    public class PDFGenerator
    {
        public static bool WriteResultsToPdfFile(List<Applicant> listApplicantsSortedByGrade, double limitBudget, double limitFeePayer)
        {
            bool retVal = true;

            if (listApplicantsSortedByGrade.Count <= 0)
                return false;

            if (limitFeePayer < limitBudget)
                return false;

            if (limitBudget <= 0 || limitFeePayer <= 0)
                return false;

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

            return retVal;
        }
    }
}
