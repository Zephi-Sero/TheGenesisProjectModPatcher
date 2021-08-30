namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// LobbyInitEvent
    /// </summary>
    public class LobbyInitEvent : IGameEvent {
        /// <summary>
        /// LobbyComponent
        /// </summary>
        public LobbyComponent Lobby { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="lobby">LobbyComponent</param>
        public LobbyInitEvent(LobbyComponent lobby) {
            Lobby=lobby;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\t{Lobby}";
        }
    }
}
