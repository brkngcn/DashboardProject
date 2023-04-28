using System;
using System.IO;

namespace Dashboard
{
    public class Logger
    {

        private static object LockLogger = new object();
        private static object LockInstance = new object();
        private static volatile Logger _instance;
        public static Logger Instance()
        {
            lock (LockInstance)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
        private readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");



        public void LogWrite(string text, LogType logType = LogType.Info)
        {
            try
            {
                lock (LockLogger)
                {


                    {
                        var dayPath = Path.Combine(LogPath, DateTime.Now.ToString("yyyyMMdd"));
                        DirectoryControl(dayPath);
                        dayPath = Path.Combine(dayPath, "Log.txt");
                        using (StreamWriter w = File.AppendText(dayPath))
                        {
                            var tmp = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm.ss.ff")}  [{logType}]    {text}";
                            w.WriteLine(tmp);
                        }
                    }


                }



            }
            catch (Exception exception)
            {
                LogWrite($"LogWrite Error {exception.Message} \n message:{text}", LogType.Fatal);
            }

        }
        private void DirectoryControl(string path)
        {
            if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
        }

        public enum LogType
        {
            Info, Error, Fatal, Warning
        }
    }
}