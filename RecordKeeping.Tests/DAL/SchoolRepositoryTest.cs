using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordKeeping.DAL;
using Moq;
using RecordKeeping.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RecordKeeping.Tests.DAL
{
    [TestClass]
    public class SchoolRepositoryTest
    {


        Mock<SchoolContext> mock_context { get; set; }
        SchoolRepository repo { get; set; } // Injects mocked (fake) SchoolContext

        // Student
        List<Student> student_datasource { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; } // Fake student table
        IQueryable<Student> student_data { get; set; }// Turns List<student> into something we can query with LINQ

        // Assignment
        List<Assignment> assignment_datasource { get; set; }
        Mock<DbSet<Assignment>> mock_assignment_table { get; set; } // Fake Assignment table
        IQueryable<Assignment> assignment_data { get; set; }

        // AssignToStud
        List<AssignedToStud> assignToStud_datasource { get; set; }
        Mock<DbSet<AssignedToStud>> mock_assignToStud_table { get; set; } // Fake  AssignToStud table
        IQueryable<AssignedToStud> assignToStud_data { get; set; }

        [TestInitialize]
        public void Initialize()
        {            
            student_datasource = new List<Student>();
            assignment_datasource = new List<Assignment>();
            assignToStud_datasource = new List<AssignedToStud>();


            mock_student_table = new Mock<DbSet<Student>>(); // Fake student table
            mock_assignment_table = new Mock<DbSet<Assignment>>();
            mock_assignToStud_table = new Mock<DbSet<AssignedToStud>>();


            repo = new SchoolRepository();
            mock_context = new Mock<SchoolContext>();

            repo = new SchoolRepository(mock_context.Object); // Injects mocked faked StudnContext
            student_data = student_datasource.AsQueryable(); // Turns List student into something we can query with LINQ
            assignment_data = assignment_datasource.AsQueryable();
            assignment_data = assignment_datasource.AsQueryable();


        }
        [TestCleanup]
        public void Cleanup()
        {
            student_datasource = null;
        }

        void ConnectMocksToDatastore() // Utility method
        {
            // Telling our fake DbSet to use our datasource like something Queryable
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(student_data.GetEnumerator());
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(student_data.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(student_data.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(student_data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<student>)
            mock_context.Setup(m => m.Students).Returns(mock_student_table.Object);


            // Telling our fake DbSet to use our datasource like something Queryable
            mock_assignment_table.As<IQueryable<Assignment>>().Setup(m => m.GetEnumerator()).Returns(assignment_data.GetEnumerator());
            mock_assignment_table.As<IQueryable<Assignment>>().Setup(m => m.ElementType).Returns(assignment_data.ElementType);
            mock_assignment_table.As<IQueryable<Assignment>>().Setup(m => m.Expression).Returns(assignment_data.Expression);
            mock_assignment_table.As<IQueryable<Assignment>>().Setup(m => m.Provider).Returns(assignment_data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<PollTag>)
            mock_context.Setup(m => m.Assignments).Returns(mock_assignment_table.Object);

            // Telling our fake DbSet to use our datasource like something Queryable
            mock_assignToStud_table.As<IQueryable<AssignedToStud>>().Setup(m => m.GetEnumerator()).Returns(assignToStud_data.GetEnumerator());
            mock_assignToStud_table.As<IQueryable<AssignedToStud>>().Setup(m => m.ElementType).Returns(assignToStud_data.ElementType);
            mock_assignToStud_table.As<IQueryable<AssignedToStud>>().Setup(m => m.Expression).Returns(assignToStud_data.Expression);
            mock_assignToStud_table.As<IQueryable<AssignedToStud>>().Setup(m => m.Provider).Returns(assignToStud_data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<Tag>)
            mock_context.Setup(m => m.AssignedToStuds).Returns(mock_assignToStud_table.Object);


            // Hijack the call to the Add methods and put it the list using the List's Add method.
            mock_student_table.Setup(m => m.Add(It.IsAny<Student>())).Callback((Student student) => student_datasource.Add(student));
            mock_assignment_table.Setup(m => m.Add(It.IsAny<Assignment>())).Callback((Assignment assignment) => assignment_datasource.Add(assignment));
            mock_assignToStud_table.Setup(m => m.Add(It.IsAny<AssignedToStud>())).Callback((AssignedToStud assignToStud) => assignToStud_datasource.Add(assignToStud));

        }

        [TestMethod]
        public void RepoEnsureICanCreateInstance()
        {
           // SchoolRepository _school = new SchoolRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIsUsingContext()
        {
            // Arrange 
            //VotrRepository repo = new VotrRepository();

            // Act

            // Assert
            Assert.IsNotNull(repo.context);
        }



        [TestMethod]
        public void Searchstudent()
        {
            //Arrange
            ConnectMocksToDatastore();
          //  SchoolRepository search = new SchoolRepository();

            //Act
           // string actual = repo.SearchBox("sharif");
            //var expected = db.student.
           // string expected = "sharif";
            //Assert
           // Assert.AreEqual(actual, expected);
           
        }

       
    }
}
