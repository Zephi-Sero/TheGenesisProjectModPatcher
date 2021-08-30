namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// ClientStartEvent
    /// </summary>
    public class ClientStartEvent : IGameEvent {
        /// <summary>
        /// Create a new event
        /// </summary>
        public ClientStartEvent() {}
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}";
        }
    }
}
