using System;

namespace A7
{
    /// <summary>
    /// Khalle class containing khalle properties
    /// </summary>
    public class Khalle : ICitizen, ITeacher
    {
        public string Name { get ; set ; }
        public string NationalId { get ; set ; }
        public Degree TopDegree { get ; set ; }
        public string ImgUrl { get ; set ; }

        /// <summary>
        /// Khalle Class constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationalId"></param>
        /// <param name="topDegree"></param>
        /// <param name="imgUrl"></param>
        public Khalle(string nationalId, string name, string imgUrl, Degree topDegree)
        {
            Name = name;
            NationalId = nationalId;
            TopDegree = topDegree;
            ImgUrl = imgUrl;
        }

        /// <summary>
        /// Teach method for describing khalle properties
        /// </summary>
        /// <returns></returns>
        public string Teach() => $"Khalle {Name} is teaching";        
    }
}