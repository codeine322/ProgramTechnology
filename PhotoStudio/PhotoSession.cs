namespace PhotoStudio
{
    /// <summary>
    /// Класс, представляющий фотосессию.
    /// </summary>
    public class PhotoSession
    {
        /// <summary>
        /// Уникальный идентификатор фотосессии.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Название фотосессии.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Внешний ключ: Id фотографа.
        /// </summary>
        public int PhotographerId { get; init; }

        /// <summary>
        /// Внешний ключ: Id клиента.
        /// </summary>
        public int ClientId { get; init; }

        /// <summary>
        /// Дата проведения.
        /// </summary>
        public DateTime Date { get; init; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Price { get; init; }

        /// <summary>
        /// Длительность в часах.
        /// </summary>
        public int Duration { get; init; }

        /// <summary>
        /// Вычисляемое свойство: стоимость за час.
        /// </summary>
        public decimal PricePerHour
        {
            get
            {
                if (Duration == 0) return 0;
                return Price / Duration;
            }
        }

        /// <summary>
        /// Вычисляемое свойство: является ли сессия длительной (больше 3 часов).
        /// </summary>
        public bool IsLong
        {
            get { return Duration > 3; }
        }

        /// <summary>
        /// Конструктор класса PhotoSession с валидацией данных.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="name">Название сессии.</param>
        /// <param name="photographerId">Id фотографа.</param>
        /// <param name="clientId">Id клиента.</param>
        /// <param name="date">Дата проведения.</param>
        /// <param name="price">Стоимость.</param>
        /// <param name="duration">Длительность в часах.</param>
        public PhotoSession(int id, string name, int photographerId, int clientId, DateTime date, decimal price, int duration)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive", nameof(id));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty", nameof(name));
            if (photographerId <= 0) throw new ArgumentException("PhotographerId must be positive", nameof(photographerId));
            if (clientId <= 0) throw new ArgumentException("ClientId must be positive", nameof(clientId));
            if (price < 0) throw new ArgumentException("Price cannot be negative", nameof(price));
            if (duration <= 0) throw new ArgumentException("Duration must be greater than 0", nameof(duration));

            Id = id;
            Name = name;
            PhotographerId = photographerId;
            ClientId = clientId;
            Date = date;
            Price = price;
            Duration = duration;
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public PhotoSession()
        {
            Id = 1;
            Name = "Стандартная";
            PhotographerId = 1;
            ClientId = 1;
            Date = DateTime.Now;
            Price = 1000;
            Duration = 1;
        }

        /// <summary>
        /// Возвращает строковое представление информации о фотосессии.
        /// </summary>
        /// <returns>Строка с названием, длительностью и ценой.</returns>
        public string GetInfo()
        {
            return $"\"{Name}\" ({Duration} ч, {Price} руб.)";
        }
    }
}