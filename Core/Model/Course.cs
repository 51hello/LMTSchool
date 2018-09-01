using Core.EnumType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Course
    {
        public int CourseID { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public int Credits { get; set; }
       


    }
}
