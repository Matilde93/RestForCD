using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestForCD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RestForCD.Repositories.Tests
{
    [TestClass()]
    public class TeachersRepositoryTests
    {

        TeachersRepository repository;
        Teacher testTeacher;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new TeachersRepository();
            testTeacher = repository.Add(new Teacher { Id = 1, Name = "Andreas", Salary = 10000 });

        }

        [TestMethod()]
        public void TeachersRepositoryTest()
        {
            List<Teacher> teachers = repository.GetAll();
            Assert.AreEqual(5, teachers.Count());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<Teacher> teachers = repository.GetAll();
            Assert.IsInstanceOfType(teachers, typeof(List<Teacher>));
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual("5 Andreas 10000", testTeacher.ToString());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Teacher updatedTeacher = new Teacher { Id = 5, Name = "Kaya", Salary = 32000 };
            Teacher? result = repository.Update(testTeacher.Id, updatedTeacher);
            Assert.AreEqual("5 Kaya 32000", result.ToString());
            Teacher? nullTeacher = repository.Update(7, updatedTeacher);
            Assert.IsNull(nullTeacher);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Teacher? getTeacher = repository.GetById(5);
            Assert.AreEqual(5, getTeacher.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int testId = testTeacher.Id;
            repository.Delete(testId);
            Assert.IsNull(repository.GetById(testId));

            repository.Delete(testId);
            Assert.IsNull(repository.GetById(testId));
        }


    }
}