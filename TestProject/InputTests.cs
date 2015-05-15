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
            form.textBox1.Text = "123";
            form.textBox2.Text = "123";
            form.textBox3.Text = "123";
            form.textBox4.Text = "123";
            form.textBox5.Text = "123";
            form.textBox6.Text = "123";
            form.textBox7.Text = "123";

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
