using System;

namespace SpaceCrew
{
    /// <summary>
    /// Командир космического экипажа.
    /// </summary>
    public class Commander : CrewMember, ITrainable
    {
        /// <summary>
        /// Количество выполненных миссий.
        /// </summary>
        public int MissionsCount { get; init; }

        /// <summary>
        /// Является ли командир опытным (больше 5 миссий).
        /// </summary>
        public bool IsExperienced => MissionsCount > 5;

        /// <summary>
        /// Создаёт командира.
        /// </summary>
        /// <param name="id">Идентификатор члена экипажа.</param>
        /// <param name="fullName">Полное имя.</param>
        /// <param name="experience">Опыт (в годах).</param>
        /// <param name="missionsCount">Количество миссий (по умолчанию 0).</param>
        public Commander(int id, string fullName, int experience, int missionsCount = 0)
            : base(id, fullName, experience)
        {
            MissionsCount = missionsCount;
        }

        /// <summary>
        /// Выполняет обязанность командира — руководит миссией.
        /// </summary>
        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} commands the mission.");
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