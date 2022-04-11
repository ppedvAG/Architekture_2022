namespace HalloSingelton
{
    internal class Logger
    {

        private static Logger? _instance;
        private static object _lockObj = new();
        public static Logger Instance
        {
            get
            {
                lock (_lockObj)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }

                return _instance;
            }
        }

        private Logger()
        {
            Info("New Logger");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:t} {msg}");
        }
    }
}
