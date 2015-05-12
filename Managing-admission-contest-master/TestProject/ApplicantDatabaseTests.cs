using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ManagingAdmissionContest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    /// <summary>
    /// Tests the ApplicantDatabase class.
    /// </summary>
    [TestClass]
    public class ApplicantDatabaseTests
    {
        public ApplicantDatabaseTests()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void InitializeDatabaseTest_File1()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Assert.IsTrue(File.Exists("applicantDatabase\\" + file));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_File2()
        {
            string file = "myfolder\\myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Assert.IsTrue(File.Exists("applicantDatabase\\" + file));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_File3()
        {
            string file = "D:\\myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Assert.IsTrue(File.Exists("applicantDatabase\\" + file));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_File4()
        {
            string file = "myfile";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Assert.IsTrue(File.Exists("applicantDatabase\\" + file));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_File5()
        {
            string file = "";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Assert.IsTrue(File.Exists("applicantDatabase\\"+file));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_Folder1()
        {
            string folderName = "myfolder\\myfolder";
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(folderName,file);
            string path = folderName + "\\" + file;
            Assert.IsTrue(File.Exists(path));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_Folder2()
        {
            string folderName = "D:\\";
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(folderName, file);
            string path = folderName + "\\" + file;
            Assert.IsTrue(File.Exists(path));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_Folder3()
        {
            string folderName = "myfile.txt";
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(folderName, file);
            string path = folderName + "\\" + file;
            Assert.IsTrue(File.Exists(path));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_Folder4()
        {
            string folderName = "";
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(folderName, file);
            string path = folderName + "\\" + file;
            Assert.IsTrue(File.Exists(path));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void InitializeDatabaseTest_Folder5()
        {
            string folderName = "myfolder";
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(folderName, file);
            string path = folderName + "\\" + file;
            Assert.IsTrue(File.Exists(path));
            Assert.IsNotNull(ad);
            Assert.IsInstanceOfType(ad, typeof(ApplicantDatabase));
            Assert.IsNotNull(ApplicantDatabase.FileName);
            Assert.IsNotNull(ApplicantDatabase.FolderName);
            Assert.IsNotNull(ApplicantDatabase.Path);
        }
        [TestMethod]
        public void DeleteDatabaseTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            ad.DeleteDatabase();
            Assert.IsNull(ad);
        }
        [TestMethod]
        public void InsertRecordTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            Assert.IsTrue(ad.ApplicantList.Contains(a));
        }
        [TestMethod]
        public void DeleteRecordTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            ad.DeleteRecord(a);
            Assert.IsFalse(ad.ApplicantList.Contains(a));
        }
        [TestMethod]
        public void DeleteRecordsTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            ad.DeleteRecords("Id", "1892184593201");
            Assert.IsFalse(ad.ApplicantList.Contains(a));
        }
        [TestMethod]
        public void GetPropValueTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            Assert.AreEqual(ApplicantDatabase.GetPropValue(a, "Id").ToString(), "1892184593201");
        }
        [TestMethod]
        public void SetPropValueTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            ApplicantDatabase.SetPropValue(a, "Surname", "Andrei");
            Assert.AreEqual(ApplicantDatabase.GetPropValue(a, "Surname").ToString(), "Andrei");
        }
        [TestMethod]
        public void PropHasValueTest_String()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            Assert.IsTrue(ApplicantDatabase.PropHasValue(a, "Surname", "Alex"));
        }
        [TestMethod]
        public void PropHasValueTest_Double()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            Assert.IsTrue(ApplicantDatabase.PropHasValue(a, "TestGrade", "7"));
        }
        [TestMethod]
        public void PropHasValueTest_False()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            Assert.IsFalse(ApplicantDatabase.PropHasValue(a, "TestGrade", "8"));
        }
        [TestMethod]
        public void UpdateRecordsTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            ad.UpdateRecords("Surname", "Alex", "TestGrade", "8");
            Assert.IsTrue(ApplicantDatabase.PropHasValue(a, "TestGrade", "8"));
        }
        [TestMethod]
        public void SelectAllRecordsTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            Assert.Equals(ad.ApplicantList, ad.SelectAllRecords());
        }
        [TestMethod]
        public void SelectRecordsTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            List<Applicant> list = new List<Applicant>();
            list.Add(a);
            Assert.Equals(list, ad.SelectRecords("Id", "1892184593201"));
        }
        [TestMethod]
        public void SaveToFileTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            ad.SaveToFile();
            Assert.Equals(ad, ApplicantDatabase.LoadFromFile(file));
        }
        [TestMethod]
        public void LoadFromFileTest()
        {
            string file = "myfile.txt";
            ApplicantDatabase ad = ApplicantDatabase.InitializeDatabase(file);
            Applicant a = new Applicant("1892184593201,Alex,Radu,7,4.75,4,4.5,0");
            ad.InsertRecord(a);
            ad.SaveToFile();
            ApplicantDatabase ad1 = ApplicantDatabase.LoadFromFile(file);
            Assert.Equals(ad, ad1);
        }
    }
}
