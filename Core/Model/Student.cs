using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Student
    {
        public int ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime InDate { get; set; }
    }
}
