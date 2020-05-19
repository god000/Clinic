using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ClinicStorage.Models
{
    public class Doctor : IDoctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position   Position { get; set ; }
    }
}
