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
            Database.CreateDatabase("myfolder");
            Assert.IsTrue(Directory.Exists("myfolder"));
        }
        [TestMethod]
        public void DeleteDatabaseTest()
        {
            Database.CreateDatabase("myfolder");
            Database.DeleteDatabase("myfolder");
            Assert.IsFalse(Directory.Exists("myfolder"));
        }
        [TestMethod]
        public void CreateTableTest()
        {
            Database.CreateTable("myfile.txt");
            Assert.IsTrue(File.Exists("myfile.txt"));
        }
        [TestMethod]
        public void DeleteTableTest()
        {
            Database.CreateTable("myfile.txt");
            Database.DeleteTable("myfile.txt");
            Assert.IsFalse(File.Exists("myfile.txt"));
        }
    }
}
