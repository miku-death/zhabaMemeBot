namespace zhabaMemeBot
{
    public class Logger
    {
        public static string Folder {get; private set;}

        public Logger(string folder)
        {
            if(Folder is null)
            {
                Folder = folder;
                System.IO.Directory.CreateDirectory(Folder);
            }
        }

        public bool WriteToLog(string line)
        {
            string path = $"{Folder}/{DateTime.Now.ToString("dd-MM-yyyy")}.log";

            try
            {
                using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                using(StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(line);
                }
                return true;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}