using System;

namespace A7
{ 
    /// <summary>
    /// Dabir class containing dabir properties
    /// </summary>
    public class Dabir : ICitizen, ITeacher
    {
        public string Name { get; set; }
        public string NationalId { get; set; }
        public Degree TopDegree { get; set; }
        public string ImgUrl { get; set; }
        public int Under100StudentCount { get; set; }

        /// <summary>
        /// Dabir Class constructor
        /// </summary>
        /// <param name="nationalId"></param>
        /// <param name="name"></param>
        /// <param name="imgUrl"></param>
        /// <param name="topDegree"></param>
        /// <param name="under100StudentCount"></param>
        public Dabir(string nationalId, string name, string imgUrl,Degree topDegree, int under100StudentCount)
        {
            Name = name;
            NationalId = nationalId;
            TopDegree = topDegree;
            ImgUrl = imgUrl;
            Under100StudentCount = under100StudentCount;
        }

        /// <summary>
        /// Teach Method for describing dabir
        /// </summary>
        /// <returns></returns>
        public string Teach() => $"Dabir {Name} is teaching";
    }
}