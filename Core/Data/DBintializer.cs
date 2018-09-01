using Core.EF;
using Core.EnumType;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Data
{
    public class DBintializer
    {
        public static void Initializer(SchoolDBContext context)
        {
            context.Database.EnsureCreated();
            //检查是否有信息
            if (context.Students.Any())
            {
                return;
            }
            var students = new Student[]
                {
                    new Student{ Name="张三", InDate=DateTime.Now },
                     new Student{ Name="李四", InDate=DateTime.Now.AddDays(-1) },
                     new Student{Name="王五", InDate=DateTime.Now.AddDays(-2) }
                };
            foreach (var s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
                {
                   new Course{ CourseName="语文", Credits=100},
                   new Course{ CourseName="数学", Credits=100},
                   new Course{ CourseName="英语", Credits=100}
                };
            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
                {
                    new Enrollment{   StudentID=1,CourseID=1, Grade=CourseGrade.A},
                    new Enrollment{  StudentID=2,CourseID=2, Grade=CourseGrade.B},
                    new Enrollment{StudentID=1,CourseID=2, Grade=CourseGrade.B},

                };
            foreach (var e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();

        }
    }
}
