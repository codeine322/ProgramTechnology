namespace PhotoStudio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Photographer> photographers = new List<Photographer>();
            List<Client> clients = new List<Client>();
            List<PhotoSession> sessions = new List<PhotoSession>();

            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - InMemoryRepository");
            Console.WriteLine("2 - CsvRepository");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InMemoryRepository memRepo = new InMemoryRepository();
                    photographers = memRepo.GetPhotographers();
                    clients = memRepo.GetClients();
                    sessions = memRepo.GetSessions();
                    break;
                case "2":
                    CsvRepository csvRepo = new CsvRepository("data");
                    photographers = csvRepo.GetPhotographers();
                    clients = csvRepo.GetClients();
                    sessions = csvRepo.GetSessions();
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }

            try
            {
                Console.WriteLine("\n1. FindPhotographer(\"Свадебная\"):");
                Photographer foundPhotographer = FindPhotographer(sessions, photographers, "Свадебная");
                if (foundPhotographer != null)
                    Console.WriteLine(foundPhotographer.GetInfo());
                else
                    Console.WriteLine("Не найдено");

                Console.WriteLine("\n2. FindClient(session \"Свадебная\"):");
                Client foundClient = FindClient(sessions, clients, "Свадебная");
                if (foundClient != null)
                    Console.WriteLine(foundClient.GetInfo());
                else
                    Console.WriteLine("Не найдено");

                Console.WriteLine("\n3. GetTotalDuration:");
                int totalDuration = GetTotalDuration(sessions);
                Console.WriteLine($"{totalDuration} часов");

                Console.WriteLine("\n4. GetPhotographerWithMaxRevenue:");
                Photographer maxRevenuePhotographer = GetPhotographerWithMaxRevenue(sessions, photographers);
                if (maxRevenuePhotographer != null)
                    Console.WriteLine($"{maxRevenuePhotographer.FullName} ({maxRevenuePhotographer.Experience} лет опыта)");
                else
                    Console.WriteLine("Нет сессий");

                Console.WriteLine("\n5. PrintAllSessions:");
                PrintAllSessions(sessions, photographers, clients);

                Console.WriteLine("\nНе найдено: FindPhotographer(\"Неизвестная сессия\") -> " + (FindPhotographer(sessions, photographers, "Неизвестная сессия") == null ? "null" : "найдено"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Находит фотографа, проводящего фотосессию с указанным названием.
        /// </summary>
        /// <param name="sessions">Список сессий.</param>
        /// <param name="photographers">Список фотографов.</param>
        /// <param name="sessionName">Название сессии.</param>
        /// <returns>Объект Photographer или null.</returns>
        public static Photographer FindPhotographer(List<PhotoSession> sessions, List<Photographer> photographers, string sessionName)
        {
            if (sessions == null || photographers == null || string.IsNullOrWhiteSpace(sessionName))
                return null;

            PhotoSession targetSession = null;
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Name == sessionName)
                {
                    targetSession = sessions[i];
                    break;
                }
            }

            if (targetSession == null) return null;

            for (int i = 0; i < photographers.Count; i++)
            {
                if (photographers[i].Id == targetSession.PhotographerId)
                {
                    return photographers[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Находит клиента, заказавшего фотосессию с указанным названием.
        /// </summary>
        /// <param name="sessions">Список сессий.</param>
        /// <param name="clients">Список клиентов.</param>
        /// <param name="sessionName">Название сессии.</param>
        /// <returns>Объект Client или null.</returns>
        public static Client FindClient(List<PhotoSession> sessions, List<Client> clients, string sessionName)
        {
            if (sessions == null || clients == null || string.IsNullOrWhiteSpace(sessionName))
                return null;

            PhotoSession targetSession = null;
            for (int i = 0; i < sessions.Count; i++)
            {
                if (sessions[i].Name == sessionName)
                {
                    targetSession = sessions[i];
                    break;
                }
            }

            if (targetSession == null) return null;

            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id == targetSession.ClientId)
                {
                    return clients[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Вычисляет общую длительность всех сессий.
        /// </summary>
        /// <param name="sessions">Список сессий.</param>
        /// <returns>Суммарная длительность в часах.</returns>
        public static int GetTotalDuration(List<PhotoSession> sessions)
        {
            if (sessions == null) return 0;

            int total = 0;
            for (int i = 0; i < sessions.Count; i++)
            {
                total += sessions[i].Duration;
            }
            return total;
        }

        /// <summary>
        /// Находит фотографа с максимальной суммарной выручкой.
        /// </summary>
        /// <param name="sessions">Список сессий.</param>
        /// <param name="photographers">Список фотографов.</param>
        /// <returns>Объект Photographer или null.</returns>
        public static Photographer GetPhotographerWithMaxRevenue(List<PhotoSession> sessions, List<Photographer> photographers)
        {
            if (sessions == null || photographers == null || sessions.Count == 0 || photographers.Count == 0)
                return null;

            decimal maxRevenue = -1;
            int bestPhotographerId = -1;

            for (int i = 0; i < photographers.Count; i++)
            {
                decimal currentRevenue = 0;
                for (int j = 0; j < sessions.Count; j++)
                {
                    if (sessions[j].PhotographerId == photographers[i].Id)
                    {
                        currentRevenue += sessions[j].Price;
                    }
                }

                if (currentRevenue > maxRevenue)
                {
                    maxRevenue = currentRevenue;
                    bestPhotographerId = photographers[i].Id;
                }
            }

            if (bestPhotographerId == -1) return null;

            for (int i = 0; i < photographers.Count; i++)
            {
                if (photographers[i].Id == bestPhotographerId)
                {
                    return photographers[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Выводит информацию о всех сессиях.
        /// </summary>
        /// <param name="sessions">Список сессий.</param>
        /// <param name="photographers">Список фотографов.</param>
        /// <param name="clients">Список клиентов.</param>
        public static void PrintAllSessions(List<PhotoSession> sessions, List<Photographer> photographers, List<Client> clients)
        {
            if (sessions == null || photographers == null || clients == null) return;

            for (int i = 0; i < sessions.Count; i++)
            {
                PhotoSession session = sessions[i];

                string photographerName = "Не найдено";
                for (int j = 0; j < photographers.Count; j++)
                {
                    if (photographers[j].Id == session.PhotographerId)
                    {
                        photographerName = photographers[j].FullName;
                        break;
                    }
                }

                string clientName = "Не найдено";
                for (int j = 0; j < clients.Count; j++)
                {
                    if (clients[j].Id == session.ClientId)
                    {
                        clientName = clients[j].FullName;
                        break;
                    }
                }

                Console.WriteLine($"{session.GetInfo()} - фотограф {photographerName}, клиент {clientName}");
            }
        }
    }
}
