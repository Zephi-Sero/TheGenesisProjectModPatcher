namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerCreatedEvent - Triggered when player spawns into world / is created
    /// </summary>
    public class PlayerCreatedEvent : IGameEvent {
        /// <summary>
        /// ID of Player who was created
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">ID of Player who was created</param>
        public PlayerCreatedEvent(int id) {
            PlayerID = id;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tPlayerID:{PlayerID}";
        }
    }
}
