﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel
{
    public class YearTerm
    {
        [Key]
        public int YearTermId { get; set; }

        public int Year { get; set; }

        public int Term { get; set; }

        public Boolean IsDefault { get; set; }

        public List<Choice> Choices { get; set; }
    }
}
