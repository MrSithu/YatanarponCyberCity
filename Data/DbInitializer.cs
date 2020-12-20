using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CyberCity.Models;

namespace CyberCity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { LastName = "Aung",   FirstName = "Sithu",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { LastName = "Thura", FirstName = "Win",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { LastName = "Wah",   FirstName = "Joseph",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { LastName = "Aung",    FirstName = "Zinthu",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { LastName = "Khant",      FirstName = "LuMin",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { LastName = "Aung",    FirstName = "LinHtet",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { LastName = "Htet",    FirstName = "Moe",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { LastName = "WaiAung",     FirstName = "Shine",
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { LastName = "Aye Thant",     FirstName = "Hnin",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { LastName = "Nyo Yee",    FirstName = "Nyo",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { LastName = "Ni Oo",   FirstName = "Htet",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { LastName = "Thu Win", FirstName = "May",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { LastName = "Win Min",   FirstName = "Nandar",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "IS",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.FirstName == "Hnin").ID },
                new Department { Name = "CE", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.FirstName == "Htet").ID },
                new Department { Name = "PrE", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.FirstName == "Nyo").ID },
                new Department { Name = "AME",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.FirstName == "Nandar").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Java",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "IS").DepartmentID
                },
                new Course {CourseID = 4022, Title = "React", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "CE").DepartmentID
                },
                new Course {CourseID = 4041, Title = "Angular", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "PrE").DepartmentID
                },
                new Course {CourseID = 1045, Title = "Blazor",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "AME").DepartmentID
                },
                new Course {CourseID = 3141, Title = "PHP",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "IS").DepartmentID
                },
                new Course {CourseID = 2021, Title = "JavaScript",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "CE").DepartmentID
                },
                new Course {CourseID = 2042, Title = "Dart",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "IS").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.FirstName == "May").ID,
                    Location = "Yangon" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.FirstName == "Nandar").ID,
                    Location = "Mandalay" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.FirstName == "Htet").ID,
                    Location = "PyinOoLwin" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Dart" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Hnin").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Java" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Nyo").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "React" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Htet").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Angular" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "May").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Nandar").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "PHP" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Hnin").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Dart" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Nandar").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Blazor" ).CourseID,
                    InstructorID = instructors.Single(i => i.FirstName == "Nyo").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Sithu").ID,
                    CourseID = courses.Single(c => c.Title == "Java" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Win").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Joseph").ID,
                    CourseID = courses.Single(c => c.Title == "PHP" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.FirstName == "Zinthu").ID,
                    CourseID = courses.Single(c => c.Title == "Angular" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.FirstName == "LuMin").ID,
                    CourseID = courses.Single(c => c.Title == "React" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "LinHtet").ID,
                    CourseID = courses.Single(c => c.Title == "Dart" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Moe").ID,
                    CourseID = courses.Single(c => c.Title == "Java" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Shine").ID,
                    CourseID = courses.Single(c => c.Title == "Blazor").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "LuMin").ID,
                    CourseID = courses.Single(c => c.Title == "PHP").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Win").ID,
                    CourseID = courses.Single(c => c.Title == "React").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.FirstName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}