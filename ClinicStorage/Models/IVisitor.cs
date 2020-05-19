using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicStorage.Models
{
    interface IVisitor
    {
        int Id { get; set; }
        string Name { get; set; }
        Doctor Doctor { get; set; }
        string Date { get; set; }
        string Time { get; set; }
        string Comment { get; set; }
    }
}
