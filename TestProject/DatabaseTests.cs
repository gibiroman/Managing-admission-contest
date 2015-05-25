using System;
using System.IO;
using ManagingAdmissionContest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void OnCreateDatabase_ShouldCreateTheContainingFolder()
        {
            //Arrange

            //Act
            Database.CreateDatabase("myfolder");

            //Assert
            Assert.IsTrue(Directory.Exists("myfolder"));
        }
        [TestMethod]
        public void OnDeleteDatabase_ShouldDeleteTheContainingFolder()
        {
            //Arrange

            //Act
            Database.CreateDatabase("myfolder");
            Database.DeleteDatabase("myfolder");

            //Assert
            Assert.IsFalse(Directory.Exists("myfolder"));
        }
        [TestMethod]
        public void OnCreateTable_ShouldCreateTheContainingFile()
        {
            //Arrange

            //Act
            Database.CreateTable("myfile.txt");

            //Assert
            Assert.IsTrue(File.Exists("myfile.txt"));
        }
        [TestMethod]
        public void OnDeleteTable_ShouldDeleteTheContainingFile()
        {
            //Arrange

            //Act
            Database.CreateTable("myfile.txt");
            Database.DeleteTable("myfile.txt");

            //Assert
            Assert.IsFalse(File.Exists("myfile.txt"));
        }
    }
}
