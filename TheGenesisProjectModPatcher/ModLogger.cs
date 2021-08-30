using System;
using System.IO;

namespace TheGenesisProjectModPatcher {
    /// <summary>
    /// Used to write logs
    /// </summary>
    public static class ModLogger {
		private static readonly LogSeverity logLevel = LogSeverity.INFO;
		private static readonly string date = DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
		/// <summary>
		/// Write a line to a log file
		/// </summary>
		/// <param name="txt">Text to write</param>
		/// <param name="severity">LogSeverity to prefix with</param>
		/// <param name="args">Arguments to string formatting</param>
		/// <param name="modname">Mod name to prefix with</param>
		public static void WriteLine(string modname, string txt, LogSeverity severity = LogSeverity.INFO, params object[] args) {
			String beans = $"<{severity}>[{modname}] {string.Format(txt, args)}";
			if(severity == LogSeverity.ESSENTIAL || severity >= logLevel) {
				switch(severity) {
					case LogSeverity.ESSENTIAL:
						Console.ForegroundColor = ConsoleColor.Green;
						break;
					case LogSeverity.INFO:
						Console.ForegroundColor = ConsoleColor.Gray;
						break;
					case LogSeverity.WARNING:
						Console.ForegroundColor = ConsoleColor.Yellow;
						break;
					case LogSeverity.ERROR:
						Console.ForegroundColor = ConsoleColor.Red;
						break;
					case LogSeverity.FATAL:
						Console.ForegroundColor = ConsoleColor.Magenta;
						break;
				}
				Console.Write(beans);
				Console.ResetColor();
			}
			using(FileStream fs = File.Open($"logs/{modname}-{date}.log", FileMode.Append)) {
				using(StreamWriter sw = new StreamWriter(fs)) {
					sw.WriteLine(beans);
				}
			}
        }
	}
}
