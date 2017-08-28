using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;

namespace VentasSys.Utils
{
    public class Log
    {
        public Log()
        {
            SetLogger();
        }

        public void Info(String msg, String classname)
        {
            ILog iLOG = LogManager.GetLogger(classname + "()");
            iLOG.Info(msg);
        }

        public void Error(String msg, String classname)
        {
            ILog iLOG = LogManager.GetLogger(classname + "()");
            iLOG.Error(msg);
        }

        private void SetLogger()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "[%date][%level] %logger -> %message%newline";
            patternLayout.ActivateOptions();

            FileAppender roller = new FileAppender();
            String fecha = DateTime.Now.ToString("yyyy_MM_dd");
            roller.File = "C:\\VentasSys_Logs\\" + fecha + "_VentasSys.log";
            roller.AppendToFile = true;
            roller.Layout = patternLayout;
            
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = log4net.Core.Level.All;
            hierarchy.Configured = true;
        }
    }
}
