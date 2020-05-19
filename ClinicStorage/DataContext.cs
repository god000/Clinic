using ClinicStorage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ClinicStorage
{
    public class DataContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        public Doctor Doctor
        {
            get => default;
            set
            {
            }
        }

        public Position Position
        {
            get => default;
            set
            {
            }
        }

        public TimeTable TimeTable1
        {
            get => default;
            set
            {
            }
        }

        public Visitor Visitor
        {
            get => default;
            set
            {
            }
        }
    }
}
