namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerJoinEvent - Triggered when player joins a server
    /// </summary>
    public class PlayerJoinEvent : IGameEvent {
        /// <summary>
        /// Player ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">Player ID</param>
        public PlayerJoinEvent(int id) {
            PlayerID=id;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tPlayer:{PlayerID}";
        }
    }
}
