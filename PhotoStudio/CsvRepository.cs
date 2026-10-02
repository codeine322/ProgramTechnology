using System.Globalization;

namespace PhotoStudio
{
    /// <summary>
    /// Репозиторий для загрузки данных из CSV-файлов.
    /// </summary>
    public class CsvRepository
    {
        private string _basePath;

        /// <summary>
        /// Конструктор репозитория.
        /// </summary>
        /// <param name="basePath">Путь к папке с CSV-файлами.</param>
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }

        /// <summary>
        /// Загружает список фотографов из CSV.
        /// </summary>
        public List<Photographer> GetPhotographers()
        {
            List<Photographer> result = new List<Photographer>();
            string filePath = Path.Combine(_basePath, "photographers.csv");

            if (!File.Exists(filePath)) return result;

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 3) continue;

                try
                {
                    int id = int.Parse(parts[0]);
                    string fullName = parts[1];
                    int experience = int.Parse(parts[2]);
                    result.Add(new Photographer(id, fullName, experience));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return result;
        }

        /// <summary>
        /// Загружает список клиентов из CSV.
        /// </summary>
        public List<Client> GetClients()
        {
            List<Client> result = new List<Client>();
            string filePath = Path.Combine(_basePath, "clients.csv");

            if (!File.Exists(filePath)) return result;

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 4) continue;

                try
                {
                    int id = int.Parse(parts[0]);
                    string fullName = parts[1];
                    string phone = parts[2];
                    string email = parts[3];
                    result.Add(new Client(id, fullName, phone, email));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return result;
        }

        /// <summary>
        /// Загружает список фотосессий из CSV.
        /// </summary>
        public List<PhotoSession> GetSessions()
        {
            List<PhotoSession> result = new List<PhotoSession>();
            string filePath = Path.Combine(_basePath, "sessions.csv");

            if (!File.Exists(filePath)) return result;

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 7) continue;

                try
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    int photographerId = int.Parse(parts[2]);
                    int clientId = int.Parse(parts[3]);
                    DateTime date = DateTime.ParseExact(parts[4], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    decimal price = decimal.Parse(parts[5], CultureInfo.InvariantCulture);
                    int duration = int.Parse(parts[6]);
                    result.Add(new PhotoSession(id, name, photographerId, clientId, date, price, duration));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return result;
        }
    }
}