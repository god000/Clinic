using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicStorage.Models
{
    interface IDoctor
    {
         int Id { get; set; }
         string Name { get; set; }
         Position Position { get; set; }
    }
}
