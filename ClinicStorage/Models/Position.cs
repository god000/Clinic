﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace ClinicStorage.Models
{
    public class Position : IPosition
    {
        public int Id { get ; set; }
        public string Name { get ; set ; }
    }
}
