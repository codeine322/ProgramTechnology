using System;

namespace SpaceCrew
{
    /// <summary>
    /// Инженер в составе космического экипажа.
    /// </summary>
    public class Engineer : CrewMember
    {
        public string Specialization { get; set; }

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