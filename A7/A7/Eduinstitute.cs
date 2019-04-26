using System;
using System.Collections.Generic;

namespace A7
{
    public class EduInstitute<TTeacher> where TTeacher : ITeacher, ICitizen
    {

        public bool Register(TTeacher teacher)
        {
            throw new NotImplementedException();
        }

        public bool IsEligible(TTeacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}