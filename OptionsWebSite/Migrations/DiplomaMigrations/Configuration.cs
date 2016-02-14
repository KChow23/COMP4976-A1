namespace OptionsWebSite.Migrations.DiplomaMigrations
{
    using DiplomaDataModel;
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
            List<YearTerm> yearTerms = new List<YearTerm>()
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
                new Option {Title="Database", IsActive=true  },
                new Option {Title="Web & Mobile", IsActive=true}
            };
            context.Options.AddOrUpdate(o => o.OptionId, options.ToArray());
        }
    }
}
