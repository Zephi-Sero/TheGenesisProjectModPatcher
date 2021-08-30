namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggered on world enter
    /// </summary>
    public class WorldManagerCreatedEvent : IGameEvent {
        /// <summary>
        /// Create a new event
        /// </summary>
        public WorldManagerCreatedEvent() { }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}\n\t{WorldManager.GetManager()}";
        }
    }
}
