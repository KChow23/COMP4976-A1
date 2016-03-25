namespace OptionsWebSite.Migrations.DiplomaMigrations
{
    using DiplomaDataModel;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaDataModel.DiplomaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DiplomaMigrations";
        }

        protected override void Seed(DiplomaDataModel.DiplomaContext context)
        {
            List<Choice> choices = new List<Choice>()
            {
                new Choice {FirstChoiceOptionId = 2,
                            SecondChoiceOptionId = 4,
                            ThirdChoiceOptionId = 3,
                            FourthChoiceOptionId = 1,
                            YearTermId = 4,
                            StudentId = "A00999969",
                            StudentFirstName = "Kevin",
                            StudentLastName = "Chow",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 1,
                            SecondChoiceOptionId = 2,
                            ThirdChoiceOptionId = 3,
                            FourthChoiceOptionId = 6,
                            YearTermId = 4,
                            StudentId = "A00999968",
                            StudentFirstName = "Rango",
                            StudentLastName = "Jango",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 1,
                            SecondChoiceOptionId = 4,
                            ThirdChoiceOptionId = 5,
                            FourthChoiceOptionId = 3,
                            YearTermId = 4,
                            StudentId = "A00999967",
                            StudentFirstName = "Riko",
                            StudentLastName = "Californ",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 2,
                            SecondChoiceOptionId = 6,
                            ThirdChoiceOptionId = 3,
                            FourthChoiceOptionId = 5,
                            YearTermId = 4,
                            StudentId = "A00999966",
                            StudentFirstName = "Saul",
                            StudentLastName = "Goodman",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 6,
                            SecondChoiceOptionId = 5,
                            ThirdChoiceOptionId = 1,
                            FourthChoiceOptionId = 3,
                            YearTermId = 4,
                            StudentId = "A00999965",
                            StudentFirstName = "Raphael",
                            StudentLastName = "Javar",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 2,
                            SecondChoiceOptionId = 1,
                            ThirdChoiceOptionId = 5,
                            FourthChoiceOptionId = 6,
                            YearTermId = 4,
                            StudentId = "A00999964",
                            StudentFirstName = "Thea",
                            StudentLastName = "Queen",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 2,
                            SecondChoiceOptionId = 1,
                            ThirdChoiceOptionId = 5,
                            FourthChoiceOptionId = 6,
                            YearTermId = 4,
                            StudentId = "A00999963",
                            StudentFirstName = "Firelink",
                            StudentLastName = "Shrine",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 6,
                            SecondChoiceOptionId = 2,
                            ThirdChoiceOptionId = 3,
                            FourthChoiceOptionId = 4,
                            YearTermId = 4,
                            StudentId = "A00999962",
                            StudentFirstName = "Linkin",
                            StudentLastName = "Parker",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 1,
                            SecondChoiceOptionId = 5,
                            ThirdChoiceOptionId = 4,
                            FourthChoiceOptionId = 3,
                            YearTermId = 4,
                            StudentId = "A00999961",
                            StudentFirstName = "Blue",
                            StudentLastName = "House",
                            SelectionDate = DateTime.Now
                },
                new Choice {FirstChoiceOptionId = 2,
                            SecondChoiceOptionId = 5,
                            ThirdChoiceOptionId = 1,
                            FourthChoiceOptionId = 3,
                            YearTermId = 4,
                            StudentId = "A00999960",
                            StudentFirstName = "Charlie",
                            StudentLastName = "Humongous",
                            SelectionDate = DateTime.Now
                },
            };
            context.Choices.AddOrUpdate(c => c.ChoiceId, choices.ToArray());

            /*List<YearTerm> yearTerms = new List<YearTerm>()
            {
                new YearTerm {Year=2015, Term=20, IsDefault=false },
                new YearTerm {Year=2015, Term=30, IsDefault=false },
                new YearTerm {Year=2016, Term=10, IsDefault=false },
                new YearTerm {Year=2016, Term=30, IsDefault=true }
            };
            context.YearTerms.AddOrUpdate(y => y.YearTermId, yearTerms.ToArray());

            List<Option> options = new List<Option>()
            {
                new Option {Title="Data Communications", IsActive=true },
                new Option {Title="Client Server", IsActive=true },
                new Option {Title="Digital Processing", IsActive=true },
                new Option {Title="Information Systems",IsActive=true },
                new Option {Title="Database", IsActive=false  },
                 new Option {Title="Tech Pro", IsActive=false},
                new Option {Title="Web & Mobile", IsActive=true}
            };
            context.Options.AddOrUpdate(o => o.OptionId, options.ToArray());*/
        }
    }
}
