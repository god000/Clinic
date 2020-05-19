using ClinicStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ClinicStorage
{
    public class ClinicService : DropCreateDatabaseIfModelChanges<DataContext>
    {
        public DataContext db;

        public List<string> times = new List<string>();
        public List<string> visitTimes = new List<string>();

        public ClinicService()
        {
            db = new DataContext();

            times.Add("09.00");
            times.Add("09.30");
            times.Add("10.00");
            times.Add("10.30");
            times.Add("11.00");
            times.Add("11.30");
            times.Add("12.00");
            times.Add("12.30");
            times.Add("13.00");
            times.Add("13.30");
            times.Add("14.00");
            times.Add("14.30");
            times.Add("15.00");
            times.Add("15.30");
            times.Add("16.00");
            times.Add("16.30");
            times.Add("17.00");
            times.Add("17.30");
            times.Add("18.00");

            visitTimes.Add("00.30");
            visitTimes.Add("01.00");
        }

        public DataContext DataContext
        {
            get => default;
            set
            {
            }
        }

        public void AddVisitor(Visitor a)
        {
            a.Doctor = GetDoctor(a.Doctor.Id);
            db.Visitors.Add(a);
            db.SaveChanges();
        }
        public void SetVisitorInfo(Visitor a)
        {
            db.Entry(a).State = EntityState.Modified;
            db.SaveChanges();
        }
        public Visitor GetVisitor(int id)
        {
            return db.Visitors.Include(p => p.Doctor).Where(x => x.Id == id).FirstOrDefault();
        }

        public Doctor GetDoctor(int doctorId)
        {
            return db.Doctors.Include(p => p.Position).Where(x => x.Id == doctorId).FirstOrDefault();
        }
        public void AddDoctor(Doctor doctor)
        {
            doctor.Position = GetPositions().Where(x => x.Id == doctor.Position.Id).FirstOrDefault();
            db.Doctors.Add(doctor);
            TimeTable t = new TimeTable();
            t.Doctor = doctor;
            db.TimeTable.Add(t);
            db.SaveChanges();
        }
        
        public TimeTable GetSheldure(int sheldureId)
        {
            return db.TimeTable.Include(p => p.Doctor).Where(p => p.Id == sheldureId).FirstOrDefault();
        }
        public void ChangeSheldure(TimeTable sheldure)
        {
            db.Entry(sheldure).State = EntityState.Modified;
            db.SaveChanges();
        }
        public TimeTable GetDoctorSheldure(int doctorId)
        {
            return db.TimeTable.Include(p => p.Doctor).Where(p => p.Doctor.Id == doctorId).FirstOrDefault();
        }

        public List<Doctor> GetDoctors()
        {
            return db.Doctors.Include(p => p.Position).ToList(); 
        }
        public List<Position> GetPositions()
        {
            return db.Positions.ToList();
        }
        public List<TimeTable> GetTimeTable()
        {
            return db.TimeTable.Include(p => p.Doctor).ToList();
        }
        public List<Visitor> GetVisitors()
        {
            return db.Visitors.Include(p => p.Doctor).ToList();
        }
    }
}
