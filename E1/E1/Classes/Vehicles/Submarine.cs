using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Submarine : ISwimable
    {
        public string Model { get; set; }
        public double MaxDepthSupported { get; set; }
        public double SpeedRate { get; set; }

        /// <summary>
        /// Submarine Class Constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="maxDepthSupported"></param>
        /// <param name="speedRate"></param>
        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            Model = model;
            MaxDepthSupported = maxDepthSupported;
            SpeedRate = speedRate;
        }

        /// <summary>
        /// Swim Method talking about the swimming abilities of the submarine
        /// </summary>
        /// <returns></returns>
        public string Swim() => $"{Model} is a {typeof(Submarine).Name} and is swimming in {MaxDepthSupported} meter depth";
    }
}