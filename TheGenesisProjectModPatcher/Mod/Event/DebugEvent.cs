namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// DebugEvent -- meant for internal debugging purposes
    /// </summary>
    public class DebugEvent : IGameEvent {
        /// <summary>
        /// Debug text
        /// </summary>
        public string DebugTXT { get; set; }
        /// <summary>
        /// Debug args
        /// </summary>
        public object[] Args { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="debugtxt">Debug Text</param>
        /// <param name="args">Debug args</param>
        public DebugEvent(string debugtxt, params object[] args) {
            DebugTXT=debugtxt;
            this.Args = args;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\t{DebugTXT}\n\t\t{Args}";
        }
    }
}
