namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggered when player enters house creator
    /// </summary>
    public class PlayerEnteredHouseCreatorEvent : IGameEvent {
        /// <summary>
        /// Player who entered house creator
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">ID of Player who entered house creator</param>
        public PlayerEnteredHouseCreatorEvent(int id) {
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
