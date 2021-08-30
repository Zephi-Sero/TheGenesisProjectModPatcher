namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggers when server starts
    /// </summary>
    public class ServerStartEvent : IGameEvent {
        /// <summary>
        /// Create a new event
        /// </summary>
        public ServerStartEvent() {}
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}";
        }
    }
}
