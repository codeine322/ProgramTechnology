using System;

namespace SpaceCrew
{
    /// <summary>
    /// Represents a generic member of a space crew.
    /// </summary>
    public abstract class CrewMember
    {
        private int _id;

        public string FullName { get; set; }
        public int Experience { get; set; }

        public CrewRole Role { get; set; } = CrewRole.Engineer;

        public bool IsVeteran => Experience > 10;

        public CrewMember(int id, string fullName, int experience)
        {
            _id = id;
            FullName = fullName;
            Experience = experience;
        }

        public CrewMember(string fullName) : this(0, fullName, 0)
        {
        }

        public abstract void PerformDuty();

        public override string ToString()
        {
            return $"[{this.GetType().Name}] {FullName}, exp={Experience}, role: {Role}";
        }
    }
}