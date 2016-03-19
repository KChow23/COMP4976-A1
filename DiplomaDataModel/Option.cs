﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Display(Name = "Is Active: ")]
        public Boolean IsActive { get; set; }

        public List<Choice> Choices { get; set; }
    }
}
