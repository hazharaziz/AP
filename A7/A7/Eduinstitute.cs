using System;
using System.Collections.Generic;

namespace A7
{
    /// <summary>
    /// EduInstitute class for checking the validation of an educational institute
    /// </summary>
    /// <typeparam name="TTeacher"></typeparam>
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {
        public string Title { get; set; }
        public Degree MinimumDegree { get; set; }
        public List<TTeacher> Teachers { get; set; }
        
        /// <summary>
        /// EduInstitute class constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="minimumDegree"></param>
        public EduInstitute(string title, Degree minimumDegree)
        {
            Title = title;
            MinimumDegree = minimumDegree;
        }

        /// <summary>
        /// Register method for checking the validation of a teacher
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool Register(TTeacher teacher)
        {
            if (IsEligible(teacher))
            {
                Teachers.Add(teacher);
                return true;
            }
            return false;
        }

        /// <summary>
        /// IsEligible method for checking the validation of a teacher degree
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool IsEligible(TTeacher teacher)
        {
            if ((int)teacher.TopDegree <= 1)
            {
                return false;
            }
            return true;
        }
    }
}