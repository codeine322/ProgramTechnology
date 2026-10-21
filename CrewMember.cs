using System;

namespace SpaceCrew
{
    /// <summary>
    /// Член космического экипажа.
    /// </summary>
    public abstract class CrewMember
    {
        private int _id;

        /// <summary>
        /// Полное имя члена экипажа.
        /// </summary>
        public string FullName { get; init; }

        /// <summary>
        /// Опыт члена экипажа (в годах).
        /// </summary>
        public int Experience { get; init; }

        /// <summary>
        /// Роль члена экипажа на корабле.
        /// </summary>
        public CrewRole Role { get; init; } = CrewRole.Engineer;

        /// <summary>
        /// Является ли член экипажа ветераном (опыт больше 10 лет).
        /// </summary>
        public bool IsVeteran => Experience > 10;

        /// <summary>
        /// Создаёт члена экипажа.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="fullName">Полное имя.</param>
        /// <param name="experience">Опыт (в годах).</param>
        /// <param name="role">Роль (по умолчанию Engineer).</param>
        public CrewMember(int id, string fullName, int experience, CrewRole role = CrewRole.Engineer)
        {
            _id = id;
            FullName = fullName;
            Experience = experience;
            Role = role;
        }

        /// <summary>
        /// Создаёт члена экипажа только с именем (id = 0, опыт = 0).
        /// </summary>
        /// <param name="fullName">Полное имя.</param>
        public CrewMember(string fullName) : this(0, fullName, 0)
        {
        }

        /// <summary>
        /// Выполняет основную обязанность члена экипажа.
        /// </summary>
        public abstract void PerformDuty();

        /// <summary>
        /// Возвращает строковое представление члена экипажа.
        /// </summary>
        /// <returns>Строка с типом, именем, опытом и ролью.</returns>
        public override string ToString()
        {
            return $"[{this.GetType().Name}] {FullName}, exp={Experience}, role: {Role}";
        }
    }
}