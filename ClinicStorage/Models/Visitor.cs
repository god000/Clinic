using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ClinicStorage.Models
{
    public class Visitor : IVisitor
    {
        public int Id { get; set ; }
        public string Name { get; set; }
        public Doctor Doctor { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Comment { get; set; }
    }
}
