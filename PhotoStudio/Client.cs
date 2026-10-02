namespace PhotoStudio
{
    /// <summary>
    /// Класс, представляющий клиента фотостудии.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Полное имя клиента.
        /// </summary>
        public string FullName { get; init; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Phone { get; init; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; init; }

        /// <summary>
        /// Вычисляемое свойство: есть ли у клиента email.
        /// </summary>
        public bool HasEmail
        {
            get { return !string.IsNullOrWhiteSpace(Email); }
        }

        /// <summary>
        /// Конструктор класса Client с валидацией данных.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="fullName">Полное имя.</param>
        /// <param name="phone">Номер телефона.</param>
        /// <param name="email">Электронная почта.</param>
        public Client(int id, string fullName, string phone, string email)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive", nameof(id));
            if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("FullName cannot be empty", nameof(fullName));
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException("Phone cannot be empty", nameof(phone));

            Id = id;
            FullName = fullName;
            Phone = phone;
            Email = email;
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Client()
        {
            Id = 1;
            FullName = "Неизвестный клиент";
            Phone = "0000000000";
            Email = "";
        }

        /// <summary>
        /// Возвращает строковое представление информации о клиенте.
        /// </summary>
        /// <returns>Строка с именем и email.</returns>
        public string GetInfo()
        {
            return $"{FullName} ({Email})";
        }
    }
}