using System;

namespace SpaceCrew
{
    /// <summary>
    /// Пилот в составе космического экипажа.
    /// </summary>
    public class Pilot : CrewMember, ITrainable
    {
        public int FlightHours { get; set; }

        public bool IsAcePilot => FlightHours > 1000;

        public Pilot(int id, string fullName, int experience)
            : base(id, fullName, experience)
        {
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} pilots the spacecraft.");
        }

        public void Train(string program)
        {
            Console.WriteLine($"{FullName} trained for {program}.");
        }
    }
}