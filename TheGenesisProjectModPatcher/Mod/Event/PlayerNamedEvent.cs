namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggered when player (client only!) is named
    /// </summary>
    public class PlayerNamedEvent : IGameEvent {
        /// <summary>
        /// Player who was named
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Name of player
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">ID of Player who was created</param>
        /// <param name="name">Name of player</param>
        public PlayerNamedEvent(int id, string name) {
            PlayerID = id;
            Name = name;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tPlayerID:{PlayerID}\n\tName:{Name}";
        }
    }
}
