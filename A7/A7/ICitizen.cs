using System;

namespace A7
{
    /// <summary>
    /// ICitizen interface for Name, NationalId properties
    /// </summary>
    public interface ICitizen
    {
        string Name { get; set; }
        string NationalId { get; set; }
    }
}