namespace PhotoStudio
{
    /// <summary>
    /// Класс, представляющий фотографа.
    /// </summary>
    public class Photographer
    {
        /// <summary>
        /// Уникальный идентификатор фотографа.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Полное имя фотографа.
        /// </summary>
        public string FullName { get; init; }

        /// <summary>
        /// Опыт работы в годах.
        /// </summary>
        public int Experience { get; init; }

        /// <summary>
        /// Вычисляемое свойство: является ли фотограф опытным (опыт больше 5 лет).
        /// </summary>
        public bool IsExperienced
        {
            get { return Experience > 5; }
        }

        /// <summary>
        /// Конструктор класса Photographer с валидацией данных.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="fullName">Полное имя.</param>
        /// <param name="experience">Опыт работы в годах.</param>
        public Photographer(int id, string fullName, int experience)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive", nameof(id));
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("FullName cannot be empty", nameof(fullName));
            if (experience < 0) throw new ArgumentException("Experience cannot be negative", nameof(experience));

            Id = id;
            FullName = fullName;
            Experience = experience;
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Photographer()
        {
            Id = 1;
            FullName = "Неизвестный фотограф";
            Experience = 0;
        }

        /// <summary>
        /// Возвращает строковое представление информации о фотографе.
        /// </summary>
        /// <returns>Строка с именем и опытом.</returns>
        public string GetInfo()
        {
            return $"{FullName} ({Experience} лет опыта)";
        }
    }
}