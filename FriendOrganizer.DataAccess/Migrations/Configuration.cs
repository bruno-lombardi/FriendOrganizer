namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                new Friend { FirstName = "Italo", LastName = "Ferretti" },
                new Friend { FirstName = "Mateus", LastName = "Eduardo" },
                new Friend { FirstName = "Alexandre", LastName = "Almeida" },
                new Friend { FirstName = "Rafael", LastName = "Sousa" }
            );

            context.ProgrammingLanguages.AddOrUpdate(
                pl => pl.Name,
                new ProgrammingLanguage { Name = "C#" },
                new ProgrammingLanguage { Name = "Java" },
                new ProgrammingLanguage { Name = "C++" },
                new ProgrammingLanguage { Name = "C" },
                new ProgrammingLanguage { Name = "TypeScript" },
                new ProgrammingLanguage { Name = "JavaScript" },
                new ProgrammingLanguage { Name = "Ruby" },
                new ProgrammingLanguage { Name = "Rust" },
                new ProgrammingLanguage { Name = "Swift" },
                new ProgrammingLanguage { Name = "Python" },
                new ProgrammingLanguage { Name = "PHP" }
            );

            context.FriendPhoneNumbers.AddOrUpdate(pn => pn.Number,
                new FriendPhoneNumber { Number = "+55 12131231", FriendId = context.Friends.First().Id });

            context.Meetings.AddOrUpdate(m => m.Title,
                new Meeting
                {
                    Title = "Playing Minecraft",
                    DateFrom = new DateTime(2019, 4, 10),
                    DateTo = new DateTime(2019, 4, 10),
                    Friends =
                    {
                        context.Friends.Single(f => f.FirstName == "Italo" && f.LastName == "Ferretti"),
                        context.Friends.Single(f => f.FirstName == "Mateus" && f.LastName == "Eduardo")
                    }
                });
        }
    }
}
