using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Core.EF;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LMTSchool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolDBContext>();

                    var query =
                                from c in context.Enrollments
                                join b in context.Students
 on c.StudentID equals b.ID
                                join a in context.Courses
     on c.CourseID equals a.CourseID
                                select new
                                {
                                    sname = b.Name,
                                    cname = a.CourseName,
                                    grade = c.Grade,
                                    credits = a.Credits
                                };
                    var z = query.ToList();



                    var model = context.Students.Where(q => q.Name == "张三").FirstOrDefault();

                    DBintializer.Initializer(context);
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogInformation(e, "初始化异常");

                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
