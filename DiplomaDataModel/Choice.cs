using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        
        [ForeignKey("YearTerm")]
        public int? YearTermId { get; set; }
        [ForeignKey("YearTermId")]
        public virtual YearTerm YearTerm { get; set; }

        [RegularExpression("A00[0-9]{6}")]
        [Display(Name = "Student Id: ")]
        [MaxLength(9)]
        public string StudentId { get; set; }

        [Display(Name = "First Name: ")]
        [MaxLength(40)]
        [Required]
        public string StudentFirstName { get; set; }

        [Display(Name = "Last Name: ")]
        [MaxLength(40)]
        [Required]
        public string StudentLastName { get; set; }

        [Column(Order = 0)]
        [UIHint("OptionDropdown")]
        [ForeignKey("FirstOption")]
        public int? FirstChoiceOptionId { get; set; }

        [Display(Name = "First Choice: ")]
        [ForeignKey("FirstChoiceOptionId")]
        public virtual Option FirstOption { get; set; }

        [Column(Order = 1)]
        [UIHint("OptionDropdown")]
        [ForeignKey("SecondOption")]
        public int? SecondChoiceOptionId { get; set; }

        [Display(Name = "Second Choice: ")]
        [ForeignKey("SecondChoiceOptionId")]
        public virtual Option SecondOption { get; set; }

        [Column(Order = 3)]
        [UIHint("OptionDropdown")]
        [ForeignKey("ThirdOption")]
        public int? ThirdChoiceOptionId { get; set; }

        [Display(Name = "Third Choice: ")]
        [ForeignKey("ThirdChoiceOptionId")]
        public virtual Option ThirdOption { get; set; }

        [Column(Order = 4)]
        [UIHint("OptionDropdown")]
        [ForeignKey("FourthOption")]
        public int? FourthChoiceOptionId { get; set; }

        [Display(Name = "Fourth Choice: ")]
        [ForeignKey("FourthChoiceOptionId")]
        public virtual Option FourthOption { get; set; }

        private DateTime _SelectionDate = DateTime.MinValue;

        [DataType(DataType.DateTime)]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SelectionDate
        {
            get
            {
                return (_SelectionDate == DateTime.MinValue) ? DateTime.Now : _SelectionDate;
            }
            set
            {
                _SelectionDate = value;
            }
        }
    }
}
