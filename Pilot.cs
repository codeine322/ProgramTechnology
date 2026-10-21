using System;

namespace SpaceCrew
{
    /// <summary>
    /// Пилот в составе космического экипажа.
    /// </summary>
    public class Pilot : CrewMember, ITrainable
    {
        /// <summary>
        /// Налёт часов пилота.
        /// </summary>
        public int FlightHours { get; init; }

        /// <summary>
        /// Является ли пилот асом (налёт больше 1000 часов).
        /// </summary>
        public bool IsAcePilot => FlightHours > 1000;

        /// <summary>
        /// Создаёт пилота.
        /// </summary>
        /// <param name="id">Идентификатор члена экипажа.</param>
        /// <param name="fullName">Полное имя.</param>
        /// <param name="experience">Опыт (в годах).</param>
        /// <param name="flightHours">Налёт часов (по умолчанию 0).</param>
        public Pilot(int id, string fullName, int experience, int flightHours = 0)
            : base(id, fullName, experience)
        {
            FlightHours = flightHours;
        }

        /// <summary>
        /// Выполняет обязанность пилота — управляет кораблём.
        /// </summary>
        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} pilots the spacecraft.");
        }

        /// <summary>
        /// Проходит обучение по указанной программе.
        /// </summary>
        /// <param name="program">Название программы обучения.</param>
        public void Train(string program)
        {
            Console.WriteLine($"{FullName} trained for {program}.");
        }
    }
}