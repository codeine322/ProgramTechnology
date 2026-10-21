using System;

namespace SpaceCrew
{
    /// <summary>
    /// Командир космического экипажа.
    /// </summary>
    public class Commander : CrewMember, ITrainable
    {
        public int MissionsCount { get; set; }

        public bool IsExperienced => MissionsCount > 5;

        public Commander(int id, string fullName, int experience)
            : base(id, fullName, experience)
        {
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} commands the mission.");
        }

        public void Train(string program)
        {
            Console.WriteLine($"{FullName} trained for {program}.");
        }
    }
}