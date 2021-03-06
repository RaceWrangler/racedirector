﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace racedirector.Data.Models
{
    public class Season
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public ICollection<Competition> Competitions { get; set; }
    }
}