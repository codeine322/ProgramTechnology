using System;

namespace SpaceCrew
{
    /// <summary>
    /// Represents an engineer in the space crew.
    /// </summary>
    public class Engineer : CrewMember
    {
        public string Specialization { get; set; }

        // Computed property
        public bool IsTechnical => !string.IsNullOrEmpty(Specialization);

        public Engineer(int id, string fullName, int experience)
            : base(id, fullName, experience)
        {
        }

        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} repairs the station.");
        }
    }
}