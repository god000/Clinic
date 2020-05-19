using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ClinicStorage.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public string TimeOfVisit { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
    }
}
