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
        public int YearTermId { get; set; }
        [ForeignKey("YearTermId")]
        public YearTerm YearTerm { get; set; }

        [RegularExpression("A00[0-9]{6}")]
        [MaxLength(9)]
        [ReadOnly(true)]
        public string StudentId { get; set; }

        [MaxLength(40)]
        [Required]
        public string StudentFirstName { get; set; }

        [MaxLength(40)]
        [Required]
        public string StudentLastName { get; set; }

        [Display(Name = "First Choice: ")]
        [Column(Order = 0)]
        [Index(IsUnique = true)]
        [UIHint("OptionDropdown")]
        [ForeignKey("FirstOption")]
        public int? FirstChoiceOptionId { get; set; }

        [ForeignKey("FirstChoiceOptionId")]
        public Option FirstOption { get; set; }

        [Display(Name = "Second Choice: ")]
        [Column(Order = 1)]
        [Index(IsUnique = true)]
        [UIHint("OptionDropdown")]
        [ForeignKey("SecondOption")]
        public int? SecondChoiceOptionId { get; set; }

        [ForeignKey("SecondChoiceOptionId")]
        public Option SecondOption { get; set; }

        [Display(Name = "Third Choice: ")]
        [Column(Order = 3)]
        [Index(IsUnique = true)]
        [UIHint("OptionDropdown")]
        [ForeignKey("ThirdOption")]
        public int? ThirdChoiceOptionId { get; set; }

        [ForeignKey("ThirdChoiceOptionId")]
        public Option ThirdOption { get; set; }

        [Display(Name = "Fourth Choice: ")]
        [Column(Order = 4)]
        [Index(IsUnique = true)]
        [UIHint("OptionDropdown")]
        [ForeignKey("FourthOption")]
        public int? FourthChoiceOptionId { get; set; }

        [ForeignKey("FourthChoiceOptionId")]
        public Option FourthOption { get; set; }

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
