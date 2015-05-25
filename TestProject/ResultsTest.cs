using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagingAdmissionContest;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class ResultsTest
    {
        [TestMethod]
        public void WriteResultsToPdfFile_ShouldReturnTrue()
        {
            //Arrange
            List<Applicant> listA = new List<Applicant>();
            Applicant a = new Applicant("123456", "Ion", "Pop", 9.0, 9.50, 9.0, 9.0, 0.0);
            bool actual;
            bool expected = true;

            //Act
            actual = PDFGenerator.WriteResultsToPdfFile(listA, 6, 8);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WriteResultsToHTML_ShoulReturnTrue()
        {
            //Arrange
            List<Applicant> listApp = new List<Applicant>();
            Applicant applicant1 = new Applicant("1910541231783", "Adrian", "Botez", 8, 8.75, 6, 7.75, 5.0);
            listApp.Add(applicant1);
            bool actual = false;
            bool expected = true;

            //Act
            actual = HtmlGenerator.WriteResultsToHTML(listApp, 9, 8);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_WriteResultsToHTML_ListEmpty()
        {
            //Arrange
            List<Applicant> listApp = new List<Applicant>();
            bool actual = false;
            bool expected = false;

            //Act
            actual = HtmlGenerator.WriteResultsToHTML(listApp, 6, 8);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
