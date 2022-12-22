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
            try
            {
                using(FileStream fs = new FileStream($"{Folder}/{DateTime.Now.ToShortDateString()}.log", FileMode.OpenOrCreate))
                {
                    byte[] a = System.Text.Encoding.ASCII.GetBytes(line);
                    fs.Write(a, 0, a.Length);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}