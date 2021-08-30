namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Empty event
    /// </summary>
    public class EmptyEvent : IGameEvent {
        /// <summary>
        /// Create a new event
        /// </summary>
        public EmptyEvent() {}
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}";
        }
    }
}
