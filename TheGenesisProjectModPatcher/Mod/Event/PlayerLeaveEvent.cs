namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerLeaveEvent -- Triggered when player leaves a server
    /// </summary>
    public class PlayerLeaveEvent : IGameEvent {
        /// <summary>
        /// Player ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">Player ID</param>
        public PlayerLeaveEvent(int id) {
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
