using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicStorage.Models
{
    interface IPosition
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
