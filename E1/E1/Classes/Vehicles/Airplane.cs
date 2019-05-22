using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public string Model { get; set; }
        public double SpeedRate { get; set; }

        /// <summary>
        /// Airplane Class Constructor
        /// </summary>
        /// <param name="speedRate"></param>
        /// <param name="model"></param>
        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }   

        /// <summary>
        /// Fly Method talking about the flying abilities of the airplane
        /// </summary>
        /// <returns></returns>
        public string Fly() => $"{Model} with {SpeedRate} speed rate is flying";
    }
}