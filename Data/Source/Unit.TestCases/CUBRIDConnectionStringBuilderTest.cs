﻿using CUBRID.Data.CUBRIDClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit.TestCases
{
    
    
    /// <summary>
    ///This is a test class for CUBRIDConnectionStringBuilderTest and is intended
    ///to contain all CUBRIDConnectionStringBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CUBRIDConnectionStringBuilderTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CUBRIDConnectionStringBuilder Constructor
        ///</summary>
        [TestMethod()]
        public void CUBRIDConnectionStringBuilderConstructorTest()
        {
            string server = "10.34.64.122";
            int port = 33690;
            string database = "demodb";
            string user = "public";
            string password = "";
            string encoding = "utf-8";
            CUBRIDConnectionStringBuilder target = new CUBRIDConnectionStringBuilder(server, port, database, user, password, encoding, true);
            using (CUBRIDConnection conn = new CUBRIDConnection(target.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        ///A test for CUBRIDConnectionStringBuilder Constructor
        ///</summary>
        [TestMethod()]
        public void CUBRIDConnectionStringBuilderConstructorTest1()
        {
            string connString = "server=10.34.64.122;database=demodb;port=33690;user=public;password=";
            CUBRIDConnectionStringBuilder target = new CUBRIDConnectionStringBuilder(connString);
            using (CUBRIDConnection conn = new CUBRIDConnection(target.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }
        }

        /// <summary>
        ///A test for GetConnectionString
        ///</summary>
        [TestMethod()]
        public void GetConnectionStringTest()
        {
            string server = "10.34.64.122";
            int port = 33690;
            string database = "demodb";
            string user = "public";
            string password = "";
            string encoding = "utf-8";
            CUBRIDConnectionStringBuilder target = new CUBRIDConnectionStringBuilder(server, port, database, user, password, encoding, true);
            string expected = "server=10.34.64.122;port=33690;database=demodb;user=public;password=;charset=utf-8;autocommit=1";
            string actual = string.Empty;
            actual = target.GetConnectionString();
            Assert.AreEqual(expected, actual);

            Assert.AreEqual(target.Database, "demodb");
            Assert.AreEqual(target.Encoding, "utf-8");
            Assert.AreEqual(target.Password, "");
            Assert.AreEqual(target.Port, "33690");
            Assert.AreEqual(target.Server, "10.34.64.122");
            Assert.AreEqual(target.User, "public");
            Assert.AreEqual(target.AutoCommit, "1");

            target.Server = "localhost";
            Assert.AreEqual(target.Server, "localhost");
        }

        [TestMethod()]
        public void GetConnectionStringTest2()
        {
            string server = "10.34.64.122";
            string database = "demodb";
            string user = "public";
            string password = "";
            string encoding = "utf-8";
            CUBRIDConnectionStringBuilder target = new CUBRIDConnectionStringBuilder(server, database, user, password, encoding, true);
            string expected = "server=10.34.64.122;port=33000;database=demodb;user=public;password=;charset=utf-8;autocommit=1";
            string actual = string.Empty;
            actual = target.GetConnectionString();
            Assert.AreEqual(expected, actual);
        }
    }
}