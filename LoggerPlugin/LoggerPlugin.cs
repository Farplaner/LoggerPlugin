using Advanced_Combat_Tracker;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ACTPlugins.FFXIV.Logger
{
    public partial class LoggerPlugin : UserControl, IActPluginV1
    {
        private string logFile = Path.Combine(Path.GetDirectoryName(ActGlobals.oFormActMain.LogFilePath), "ffxivlog.txt");

        public LoggerPlugin()
        {
            InitializeComponent();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            ActGlobals.oFormActMain.OnLogLineRead += OnLogLineRead;
        }

        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= OnLogLineRead;
        }

        private void OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            File.AppendAllText(logFile, logInfo.logLine + Environment.NewLine);
        }
    }
}
