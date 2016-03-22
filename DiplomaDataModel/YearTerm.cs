using System;
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

        [Display(Name = "Year: ")]
        public int Year { get; set; }
        
        [RegularExpression("^(10|20|30)$", ErrorMessage = "Must be 10, 20 or 30")]
        [Display(Name = "Term: ")]
        public int Term { get; set; }

        [Display(Name = "Is Default: ")]
        public Boolean IsDefault { get; set; }

        public List<Choice> Choices { get; set; }
    }
}
