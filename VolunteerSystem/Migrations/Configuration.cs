namespace VolunteerSystem.Migrations
{
    using VolunteerSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VolunteerSystem.DAL.CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VolunteerSystem.DAL.CompanyContext context)
        {
            var volunteers = new List<Volunteer>
            {
                new Volunteer { FirstMidName = "Carson",   LastName = "Alexander",BirthDate =DateTime.Parse("1986-08-01").Date,
                    EnrollmentDate = DateTime.Parse("2010-09-01").Date },
                new Volunteer { FirstMidName = "Meredith", LastName = "Alonso", BirthDate =DateTime.Parse("1985-07-01").Date,
                    EnrollmentDate = DateTime.Parse("2012-09-01").Date },
                new Volunteer { FirstMidName = "Arturo",   LastName = "Anand", BirthDate =DateTime.Parse("1965-06-12").Date,
                    EnrollmentDate = DateTime.Parse("2013-09-01").Date },
                new Volunteer { FirstMidName = "Gytis",    LastName = "Barzdukas", BirthDate =DateTime.Parse("1955-11-15").Date,
                    EnrollmentDate = DateTime.Parse("2012-09-01").Date },
                new Volunteer { FirstMidName = "Yan",      LastName = "Li", BirthDate =DateTime.Parse("1991-08-01").Date,
                    EnrollmentDate = DateTime.Parse("2012-09-01").Date },
                new Volunteer { FirstMidName = "Peggy",    LastName = "Justice", BirthDate =DateTime.Parse("1990-06-01").Date,
                    EnrollmentDate = DateTime.Parse("2011-09-01").Date },
                new Volunteer { FirstMidName = "Laura",    LastName = "Norman", BirthDate =DateTime.Parse("1955-08-05").Date,
                    EnrollmentDate = DateTime.Parse("2013-09-01").Date },
                new Volunteer { FirstMidName = "Nino",     LastName = "Olivetto", BirthDate =DateTime.Parse("1993-08-01").Date,
                    EnrollmentDate = DateTime.Parse("2005-08-11").Date }
            };
            volunteers.ForEach(s => context.Volunteers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var jobs = new List<Job>
            {
                new Job {JobID = 1050, Title = "Administration" },
                new Job {JobID = 4022, Title = "Food deliveries" },
                new Job {JobID = 4041, Title = "Phone bank" },
                new Job {JobID = 1045, Title = "Food pickup" },
                new Job {JobID = 3141, Title = "Fundraising/grant writing" },
                new Job {JobID = 2021, Title = "Newsletter production" },
                new Job {JobID = 2042, Title = "Volunteer coordination" }
            };
            jobs.ForEach(s => context.Jobs.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alexander").ID,
                    JobID = jobs.Single(c => c.Title == "Administration" ).JobID,
                  
                },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alexander").ID,
                    JobID = jobs.Single(c => c.Title == "Food deliveries" ).JobID,
                
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alexander").ID,
                    JobID = jobs.Single(c => c.Title == "Phone bank" ).JobID,
                   
                 },
                 new Enrollment {
                     VolunteerID = volunteers.Single(s => s.LastName == "Alonso").ID,
                    JobID = jobs.Single(c => c.Title == "Food pickup" ).JobID,
                   
                 },
                 new Enrollment {
                     VolunteerID = volunteers.Single(s => s.LastName == "Alonso").ID,
                    JobID = jobs.Single(c => c.Title == "Fundraising/grant writing" ).JobID,
                   
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alonso").ID,
                    JobID = jobs.Single(c => c.Title == "Volunteer coordination" ).JobID,
                  
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Anand").ID,
                    JobID = jobs.Single(c => c.Title == "Newsletter production" ).JobID
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Anand").ID,
                    JobID = jobs.Single(c => c.Title == "Volunteer coordination").JobID,
                    //Grade = Grade.B
                 },
                new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Barzdukas").ID,
                    JobID = jobs.Single(c => c.Title == "Volunteer coordination").JobID,
                    
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Li").ID,
                    JobID = jobs.Single(c => c.Title == "Food pickup").JobID,
                  
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Justice").ID,
                    JobID = jobs.Single(c => c.Title == "Food pickup").JobID,
                   
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Volunteer.ID == e.VolunteerID &&
                         s.Job.JobID == e.JobID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
