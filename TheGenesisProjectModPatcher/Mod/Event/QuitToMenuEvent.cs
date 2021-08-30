namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggered when local player quits to menu from in game
    /// </summary>
    public class QuitToMenuEvent : IGameEvent {
        /// <summary>
        /// QuitToMenuEvent
        /// </summary>
        public QuitToMenuEvent() { }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}";
        }
    }
}
