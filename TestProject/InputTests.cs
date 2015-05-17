using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagingAdmissionContest;
using ManagingAdmissionContest.Fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace TestProject
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void OnButton1Click_WithCorrectData_ShouldInsertApplicantInDb()
        {
            //Arrange
            Form1 form = new Form1();
            form.firstname.Text = "123";
            form.lastname.Text = "123";
            form.badgeNo.Text = "123";
            form.bacGrade.Text = "123";
            form.csGrade.Text = "123";
            form.mathGrade.Text = "123";
            form.testGrade.Text = "123";

            StubIApplicantDatabase shimIApplicantDatabase = new StubIApplicantDatabase();
          //  shim
            using (ShimsContext.Create())
            {
             //   shimIApplicantDatabase.initial
            }

            //Act

            //Assert
        }
    }
}
