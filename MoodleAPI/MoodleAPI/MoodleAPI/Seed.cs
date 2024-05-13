using MoodleAPI.Data;
using MoodleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoodleAPI
{
    public class Seed
    {
        private readonly AppDbContext dataContext;

        public Seed(AppDbContext context)
        {
            dataContext = context;
        }

        public void SeedDataContext()
        {
            try
            {
                if (!dataContext.Users.Any())
                {
                    // Populate Degrees and save to generate IDs
                    var degrees = new List<Degree>
            {
                new Degree { Name = "Computer Science" },
                new Degree { Name = "Mathematics" },
                new Degree { Name = "Economy"},
                // Add more degrees as needed
            };
                    dataContext.Degrees.AddRange(degrees);
                    dataContext.SaveChanges(); // Ensures Degree IDs are generated

                    // Populate Courses and save to generate IDs
                    var courses = new List<Course>
            {
                new Course { Code = "CS101", Name = "Introduction to Computer Science", Credit = 3 },
                new Course { Code = "MATH101", Name = "Calculus I", Credit = 4 },
                new Course { Code = "MATH102", Name = "Calculus II", Credit = 5 },
                new Course { Code = "NMATH101", Name = "Numberical Analysis", Credit = 6 },
                new Course { Code = "AI100", Name = "Introduction to AI", Credit = 4 },
                new Course { Code = "UI100", Name = "User Interface I", Credit = 3 },
                new Course { Code = "SMAT01", Name = "Software modeling I.", Credit = 3 },
                // Add more courses as per your data
            };
                    dataContext.Courses.AddRange(courses);
                    dataContext.SaveChanges(); // Ensures Course IDs are generated

                    // Populate Users, dynamically link them to Degrees
                    var computerScienceDegree = degrees.FirstOrDefault(d => d.Name == "Computer Science").Id;
                    var mathDegree = degrees.FirstOrDefault(d => d.Name == "Mathematics").Id;
                    var users = new List<User>
            {
                new User { Username = "user1", Name = "John Doe", Password = "password1", DegreeId = computerScienceDegree },
                new User { Username = "user2", Name = "Jane Smith", Password = "password2", DegreeId = mathDegree },
                new User { Username = "user3", Name = "James Smith", Password = "password3", DegreeId = computerScienceDegree },
                new User { Username = "user4", Name = "Jane Booth", Password = "password4", DegreeId = mathDegree },
                // Add more users as per your data
            };
                    dataContext.Users.AddRange(users);

                    // Populate Events (link to Courses by ID)
                    var introToCompScienceCourseId = courses.FirstOrDefault(c => c.Code == "CS101").Id;
                    var events = new List<Event>
            {
                new Event { CourseId = introToCompScienceCourseId, Name = "Seminar on Programming", Description = "Learn about the latest trends in programming"},
                 new Event { CourseId = 2 , Name = "Workshop on Calculus",Description = "Practical exercises to improve calculus skills"}, 
                // Add more events as per your data
            };
                    dataContext.Events.AddRange(events);

                    // Populate MyCourses (link Users and Courses by ID)
                    var user1Id = users.FirstOrDefault(u => u.Username == "user1").Id;
                    var myCourses = new List<MyCourse>
            {
                new MyCourse { UserId = user1Id, CourseId = introToCompScienceCourseId },
                // Add more myCourses as per your data
            };
                    dataContext.MyCourses.AddRange(myCourses);

                    dataContext.SaveChanges(); // Saves Users, Events, MyCourses

                    // Populate ApprovedDegrees (link Courses to Degrees)
                    var approvedDegrees = new List<ApprovedDegree>
            {
                new ApprovedDegree { CourseId = introToCompScienceCourseId, DegreeId = computerScienceDegree },
                // Add more approvedDegrees as per your data
            };
                    dataContext.ApprovedDegrees.AddRange(approvedDegrees);
                    dataContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during data seeding: {ex.Message}");
            }
        }


    }
}