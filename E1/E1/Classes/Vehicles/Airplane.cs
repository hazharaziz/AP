using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane : IFlyable
    {
        public string Model { get; set; }
        public double SpeedRate { get; set; }

        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }   

        public string Fly() => $"{Model} with {SpeedRate} speed rate is flying";
    }
}