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

        // Enum property with default value as specified
        public CrewRole Role { get; set; } = CrewRole.Engineer;

        // Computed property (get-only, no backing field)
        public bool IsVeteran => Experience > 10;

        // Constructor overloading (chaining via this())
        public CrewMember(int id, string fullName, int experience)
        {
            _id = id;
            FullName = fullName;
            Experience = experience;
        }

        public CrewMember(string fullName) : this(0, fullName, 0)
        {
        }

        // Abstract method to be overridden by derived classes
        public abstract void PerformDuty();

        // Overridden ToString using specific fields
        public override string ToString()
        {
            return $"[{this.GetType().Name}] {FullName}, exp={Experience}, role: {Role}";
        }
    }
}