using System;
using System.Collections.Generic;

namespace SpaceCrew
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CrewMember> crew = new List<CrewMember>
            {
                new Commander(1, "Ivanov", 15),
                new Engineer(2, "Petrov", 5)
            };

            foreach (CrewMember member in crew)
            {
                Console.WriteLine(member.ToString());
                Console.WriteLine($"   veteran: {member.IsVeteran.ToString().ToLower()}");

                member.PerformDuty();

                if (member is ITrainable trainable)
                {
                    trainable.Train("EVAs");
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