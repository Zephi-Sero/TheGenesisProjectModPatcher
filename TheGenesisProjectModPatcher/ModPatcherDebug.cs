using System;

namespace TheGenesisProjectModPatcher {
    /// <summary>
    /// Severity of logged message
    /// </summary>
    public enum LogSeverity {
		/// <summary>
		/// Essential - always shows
		/// </summary>
		ESSENTIAL,
		/// <summary>
		/// Info
		/// </summary>
		INFO,
		/// <summary>
		/// Warning
		/// </summary>
		WARNING,
		/// <summary>
		/// Error
		/// </summary>
		ERROR,
		/// <summary>
		/// Error that may cause crashing
		/// </summary>
		FATAL
	}
	internal static class ModPatcherDebug {
		public static void WriteLine(String txt, LogSeverity severity = LogSeverity.INFO, params object[] args) => ModLogger.WriteLine("ZephisModPatcher", txt, severity, args);
	}
}
