using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordKeeping.DAL;
using Moq;


namespace RecordKeeping.Tests.DAL
{
    [TestClass]
    public class SchoolRepositoryTest
    {


        private SchoolContext db = new SchoolContext();

        [TestMethod]
        public void EvenEnsureICanCreateInstance()
        {
            SchoolRepository my_school = new SchoolRepository();
            Assert.IsNotNull(my_school);
        }

        [TestMethod]
        public void SearchStudents()
        {
            //Arrange
            SchoolRepository search = new SchoolRepository();

            //Act
            string actual = search.SearchBox("sharif");
            //var expected = db.Students.
            string expected = "sharif";
            //Assert
            Assert.AreEqual(actual, expected);
           
        }

        [TestMethod]
        public void CheckIfStudentIsFailing()
        {
            
        }
    }
}
