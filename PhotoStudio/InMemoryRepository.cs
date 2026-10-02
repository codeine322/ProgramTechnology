namespace PhotoStudio
{
    /// <summary>
    /// Репозиторий для работы с тестовыми данными в памяти.
    /// </summary>
    public class InMemoryRepository
    {
        private List<Photographer> _photographers;
        private List<Client> _clients;
        private List<PhotoSession> _sessions;

        /// <summary>
        /// Конструктор, заполняющий коллекции тестовыми данными (не менее 5 записей).
        /// </summary>
        public InMemoryRepository()
        {
            _photographers = new List<Photographer>
            {
                new Photographer { Id = 1, FullName = "Сидоров С.С.", Experience = 8 },
                new Photographer { Id = 2, FullName = "Петров П.П.", Experience = 3 },
                new Photographer { Id = 3, FullName = "Иванов И.И.", Experience = 12 },
                new Photographer { Id = 4, FullName = "Смирнов А.А.", Experience = 5 },
                new Photographer { Id = 5, FullName = "Кузнецов К.К.", Experience = 1 }
            };

            _clients = new List<Client>
            {
                new Client { Id = 1, FullName = "Иванова А.А.", Phone = "+79001112233", Email = "ivanova@mail.ru" },
                new Client { Id = 2, FullName = "Кузнецов Д.Д.", Phone = "+79004445566", Email = "" },
                new Client { Id = 3, FullName = "Смирнова Е.Е.", Phone = "+79007778899", Email = "smirnova@mail.ru" },
                new Client { Id = 4, FullName = "Попов В.В.", Phone = "+79001234567", Email = "popov@mail.ru" },
                new Client { Id = 5, FullName = "Соколова М.М.", Phone = "+79009876543", Email = "" }
            };

            _sessions = new List<PhotoSession>
            {
                new PhotoSession { Id = 1, Name = "Свадебная", PhotographerId = 1, ClientId = 1, Date = new DateTime(2026, 5, 20), Price = 15000, Duration = 3 },
                new PhotoSession { Id = 2, Name = "Портретная", PhotographerId = 2, ClientId = 2, Date = new DateTime(2026, 6, 15), Price = 8000, Duration = 2 },
                new PhotoSession { Id = 3, Name = "Семейная", PhotographerId = 1, ClientId = 3, Date = new DateTime(2026, 7, 10), Price = 12000, Duration = 4 },
                new PhotoSession { Id = 4, Name = "Репортажная", PhotographerId = 3, ClientId = 4, Date = new DateTime(2026, 8, 5), Price = 20000, Duration = 5 },
                new PhotoSession { Id = 5, Name = "Детская", PhotographerId = 4, ClientId = 5, Date = new DateTime(2026, 9, 1), Price = 5000, Duration = 1 }
            };
        }

        /// <summary>
        /// Возвращает список фотографов.
        /// </summary>
        public List<Photographer> GetPhotographers() { return _photographers; }

        /// <summary>
        /// Возвращает список клиентов.
        /// </summary>
        public List<Client> GetClients() { return _clients; }

        /// <summary>
        /// Возвращает список фотосессий.
        /// </summary>
        public List<PhotoSession> GetSessions() { return _sessions; }
    }
}