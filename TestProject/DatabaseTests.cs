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
        public void CreateDatabaseTest()
        {
            //Arrange

            //Act
            Database.CreateDatabase("myfolder");

            //Assert
            Assert.IsTrue(Directory.Exists("myfolder"));
        }
        [TestMethod]
        public void DeleteDatabaseTest()
        {
            //Arrange

            //Act
            Database.CreateDatabase("myfolder");
            Database.DeleteDatabase("myfolder");

            //Assert
            Assert.IsFalse(Directory.Exists("myfolder"));
        }
        [TestMethod]
        public void CreateTableTest()
        {
            //Arrange

            //Act
            Database.CreateTable("myfile.txt");

            //Assert
            Assert.IsTrue(File.Exists("myfile.txt"));
        }
        [TestMethod]
        public void DeleteTableTest()
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
