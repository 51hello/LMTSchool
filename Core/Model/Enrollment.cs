using Core.EnumType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        /// <summary>
        /// 课程评级
        /// </summary>
        public CourseGrade Grade { get; set; }

    }
}
