using System;
using ManagingAdmissionContest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class ApplicantTests
    {
        [TestMethod]
        public void Applicant_ConstructorTest1()
        {
            //Arrange

            //Act
            Applicant person = new Applicant();

            //Assert
            Assert.IsNotNull(person);
            Assert.IsInstanceOfType(person, typeof(Applicant));
            Assert.IsNull(person.Id);
            Assert.IsNull(person.Surname);
            Assert.IsNull(person.Name);
            Assert.Equals(person.TestGrade, 0.0);
            Assert.Equals(person.BacGrade, 0.0);
            Assert.Equals(person.InfoGrade, 0.0);
            Assert.Equals(person.MathGrade, 0.0);
            Assert.Equals(person.AdmissionGrade, 0.0);
        }
        [TestMethod]
        public void Applicant_ConstructorTest2()
        {
            //Arrange

            //Act
            Applicant person = new Applicant("2890613284397", "Ionescu", "Alexandra", 7, 6, 8, 9, 0);

            //Assert
            Assert.IsNotNull(person);
            Assert.IsInstanceOfType(person, typeof(Applicant));
            Assert.Equals(person.Id, "2890613284397");
            Assert.Equals(person.Surname, "Ionescu");
            Assert.Equals(person.Name, "Alexandra");
            Assert.Equals(person.TestGrade, 7);
            Assert.Equals(person.BacGrade, 6);
            Assert.Equals(person.InfoGrade, 8);
            Assert.Equals(person.MathGrade, 9);
            Assert.Equals(person.AdmissionGrade, 0);
        }
        [TestMethod]
        public void Applicant_ConstructorTest3()
        {
            //Arrange

            //Act
            Applicant person = new Applicant("2890613284397,Ionescu,Alexandra,7,6,8,9,0");

            //Assert
            Assert.IsNotNull(person);
            Assert.IsInstanceOfType(person, typeof(Applicant));
            Assert.Equals(person.Id, "2890613284397");
            Assert.Equals(person.Surname, "Ionescu");
            Assert.Equals(person.Name, "Alexandra");
            Assert.Equals(person.TestGrade, 7);
            Assert.Equals(person.BacGrade, 6);
            Assert.Equals(person.InfoGrade, 8);
            Assert.Equals(person.MathGrade, 9);
            Assert.Equals(person.AdmissionGrade, 0);
        }
        [TestMethod]
        public void ApplicantEqualsTest_True()
        {
            //Arrange

            //Act
            Applicant a = new Applicant("2890613284397,Ionescu,Alexandra,7,6,8,9,0");
            Applicant b = new Applicant("2890613284397,Ionescu,Alexandra,7,6,8,9,0");

            //Assert
            Assert.Equals(Assert.Equals(a,b),a.Equals(b));
        }
        [TestMethod]
        public void ApplicantEqualsTest_False()
        {
            //Arrange

            //Act
            Applicant a = new Applicant("2890613284397,Ionescu,Alexandra,7,6,8,9,0");
            Applicant b = new Applicant("2990613284365,Popescu,Alexandra,7,6,8,9,0");

            //Assert
            Assert.Equals(Assert.Equals(a, b), a.Equals(b));
        }
        [TestMethod]
        public void GetHashCodeTest()
        {
            //Arrange

            //Act
            Applicant a = new Applicant("2890613284397,Ionescu,Alexandra,7,6,8,9,0");
            Applicant b = new Applicant("2990613284365,Popescu,Alexandra,7,6,8,9,0");

            //Assert
            Assert.Equals(a.Id, a.GetHashCode());
            Assert.AreNotEqual(a.GetHashCode(),b.GetHashCode());
        }
    }
}
