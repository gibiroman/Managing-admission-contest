using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagingAdmissionContest;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test_ApplicantNotNull()
        {
            Applicant testApplicant = new Applicant("1910541231783", "Adrian", "Botez", 8, 8.75, 6, 7.75, 5.0);

            Assert.IsNotNull(testApplicant);
        }

        [TestMethod]
        public void Test_WriteResultsToPdfFile()
        {
            List<Applicant> listA = new List<Applicant>();
            Applicant a = new Applicant("123456", "Ion", "Pop", 9.0, 9.50, 9.0, 9.0, 0.0);

            bool actual = false;

            actual = PDFGenerator.WriteResultsToPdfFile(listA, 6, 8);

            bool expected = true;


            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_WriteResultsToHTML()
        {
            List<Applicant> listApp = new List<Applicant>();

            Applicant applicant1 = new Applicant("1910541231783", "Adrian", "Botez", 8, 8.75, 6, 7.75, 5.0);

            listApp.Add(applicant1);

            bool actual = false;

            actual = HtmlGenerator.WriteResultsToHTML(listApp, 6, 8);

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getSortedList()
        {
            List<Applicant> testNullList = null;

            testNullList = AdmissionManager.getSortedList();

            Assert.IsNotNull(testNullList);
        }

    }
}
