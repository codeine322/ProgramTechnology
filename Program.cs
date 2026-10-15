using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace SpaceCrew
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of base type and populate with derived objects (Polymorphism)
            List<CrewMember> crew = new List<CrewMember>
            {
                new Commander(1, "Ivanov", 15),
                new Engineer(2, "Petrov", 5)
            };

            foreach (CrewMember member in crew)
            {
                // Output the ToString() result
                Console.WriteLine(member.ToString());
                Console.WriteLine($"   veteran: {member.IsVeteran.ToString().ToLower()}");

                // Polymorphic method call
                member.PerformDuty();

                // Type checking via pattern matching (is) to verify interface implementation
                if (member is ITrainable trainable)
                {
                    trainable.Train("EVAs"); // Example training program
                }
                else
                {
                    Console.WriteLine($"{member.FullName} cannot train.");
                }

                Console.WriteLine("---------------------------------");
            }

            Console.ReadLine();
        }
    }
}