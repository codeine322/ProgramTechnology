using System;

namespace SpaceCrew
{
    /// <summary>
    /// Represents a commander in the space crew.
    /// </summary>
    public class Commander : CrewMember, ITrainable
    {
        public int MissionsCount { get; set; }

        // Computed property
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