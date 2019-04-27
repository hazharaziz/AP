using System;

namespace A7
{
    /// <summary>
    /// ITeacher interface for teacher properties
    /// </summary>
    public interface ITeacher
    {
        string Name { get; set; }
        Degree TopDegree { get; set; }
        string ImgUrl { get; set; }

        /// <summary>
        /// teach method describing the teacher
        /// </summary>
        /// <returns></returns>
        string Teach();
    }
}