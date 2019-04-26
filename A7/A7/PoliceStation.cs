using System;
using System.Collections.Generic;

namespace A7
{
    /// <summary>
    /// PoliceStation class for checking the citizens' background
    /// </summary>
    public static class PoliceStation
    {
        public static List<ICitizen> BlackList { get; set; }  

        /// <summary>
        /// Background method for checking the background of a citizen 
        /// </summary>
        /// <param name="citizen"></param>
        /// <returns></returns>
        public static bool BackgroundCheck(ICitizen citizen)
        {
            if (BlackList.Contains(citizen))
            {
                return true;
            }
            return false;
        }
    }
}