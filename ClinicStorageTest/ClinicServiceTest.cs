using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ClinicStorage;
using ClinicStorage.Models;
namespace UnitTestClinic
{
    [TestClass]
    public class ClinicServiceTest
    {
        ClinicService cs = new ClinicService();
        public Visitor CreateVisitor()
        { 
            Visitor defaultVisitor = new Visitor();
            int Id = 515;
            defaultVisitor.Id = Id;
            defaultVisitor.Name = "olller";
            return defaultVisitor;

        }
        public Position CreatePosition()
        {
            Position pos = new Position
            {
                Id = 888777,
                Name = "test"
            };
            return pos;

        }
        public Doctor CreateDoctor(Position pos)
        {
            Doctor d = new Doctor();
            d.Id = 3233;
            d.Name = "testDoc";
            d.Position = pos;
            return d;

        }

        [TestMethod]
        public void AddVisitorIsAddedTest()
        {

            // Arrange
            Visitor defaultVisitor = CreateVisitor();
            Position pos = CreatePosition();
            Doctor d = CreateDoctor(pos);       
            defaultVisitor.Doctor = d;
            // Act
            cs.AddVisitor(defaultVisitor);

            // Assert          
            Visitor dbVisitor = cs.GetVisitor(defaultVisitor.Id);
            Assert.AreEqual(defaultVisitor, dbVisitor, "Visitor correctly added");
        }
        [TestMethod]
        public void GetVisitorTest()
        {
            // Arrange
            Visitor defaultVisitor = CreateVisitor();
            defaultVisitor.Doctor = CreateDoctor(CreatePosition());
            // Act
            cs.AddVisitor(defaultVisitor);
            Visitor getedVisitor = cs.GetVisitor(defaultVisitor.Id);
            // Assert
            Assert.AreEqual(defaultVisitor.Id, getedVisitor.Id, "Visitor correctly getted");
        }
        [TestMethod]
        public void GetDoctorTest()
        {
            // Arrange
            Doctor defaultDoctor = CreateDoctor(CreatePosition());
            // Act
            cs.AddDoctor(defaultDoctor);
            Doctor getedDoctor = cs.GetDoctor(defaultDoctor.Id);
            // Assert
            Assert.AreEqual(defaultDoctor.Id, getedDoctor.Id, "Doctor correctly getted");
        }
        [TestMethod]
        public void AddDoctorTest()
        {
            // Arrange
            Doctor defaultDoctor = CreateDoctor(CreatePosition());
            // Act
            cs.AddDoctor(defaultDoctor);
            Doctor getedDoctor = cs.GetDoctor(defaultDoctor.Id);
            // Assert
            Assert.AreEqual(defaultDoctor.Id, getedDoctor.Id, "Doctor correctly getted");
        }
        [TestMethod]
        public void GetDoctorsMoreZeroTest()
        {
            // Arrange
            int minCount = 0;
            // Act
            List<Doctor> listDoctors = cs.GetDoctors();
            // Assert
            Assert.AreEqual(true, listDoctors.Count > minCount, "Doctor correctly getted");
        }
        //[TestMethod]
        public void GetPositionMoreZeroTest()
        {
            // Arrange
            int minCount = 0;
            // Act
            List<Position> listPositions = cs.GetPositions();
            Console.WriteLine(listPositions.Count);
            // Assert
            Assert.AreEqual(true, listPositions.Count > minCount, "Doctor correctly getted");
        }
        public void GetTimeTableMoreZeroTest()
        {
            // Arrange
            int minCount = 0;
            // Act
            List<TimeTable> listTimeTable = cs.GetTimeTable();
            // Assert
            Assert.AreEqual(true, listTimeTable.Count > minCount, "Doctor correctly getted");
        }
        public void GetVisitorsMoreZeroTest()
        {
            // Arrange
            int minCount = 0;
            // Act
            List<Visitor> listVisitors = cs.GetVisitors();
            // Assert
            Assert.AreEqual(true, listVisitors.Count > minCount, "Doctor correctly getted");
        }



    }

}
