using System;

namespace SpaceCrew
{
    /// <summary>
    /// Инженер в составе космического экипажа.
    /// </summary>
    public class Engineer : CrewMember
    {
        /// <summary>
        /// Специализация инженера.
        /// </summary>
        public string Specialization { get; init; }

        /// <summary>
        /// Является ли инженер техническим специалистом (специализация задана).
        /// </summary>
        public bool IsTechnical => !string.IsNullOrEmpty(Specialization);

        /// <summary>
        /// Создаёт инженера.
        /// </summary>
        /// <param name="id">Идентификатор члена экипажа.</param>
        /// <param name="fullName">Полное имя.</param>
        /// <param name="experience">Опыт (в годах).</param>
        /// <param name="specialization">Специализация (по умолчанию пустая).</param>
        public Engineer(int id, string fullName, int experience, string specialization = "")
            : base(id, fullName, experience)
        {
            Specialization = specialization;
        }

        /// <summary>
        /// Выполняет обязанность инженера — ремонтирует станцию.
        /// </summary>
        public override void PerformDuty()
        {
            Console.WriteLine($"{FullName} repairs the station.");
        }
    }
}