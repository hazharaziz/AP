using System;

namespace A7
{
    /// <summary>
    /// Professor class containing professor properties
    /// </summary>
    public class Professor : ICitizen, ITeacher
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public int ResearchCount { get; set; }

        /// <summary>
        /// Professor constructor
        /// </summary>
        /// <param name="nationalId"></param>
        /// <param name="name"></param>
        /// <param name="imgUrl"></param>
        /// <param name="topDegree"></param>
        /// <param name="researchCount"></param>
        public Professor(string nationalId, string name, string imgUrl, Degree topDegree, int researchCount)
        {
            Name = name;
            NationalId = nationalId;
            TopDegree = topDegree;
            ImgUrl = imgUrl;
            ResearchCount = researchCount;
        }

        /// <summary>
        /// Teach method for describing professor
        /// </summary>
        /// <returns></returns>
        public string Teach() => $"Professor {Name} is teaching";
        
    }
}