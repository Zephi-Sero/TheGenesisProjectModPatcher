namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggered when local player quits to desktop from in-game
    /// </summary>
    public class QuitToDesktopEvent : IGameEvent {
        /// <summary>
        /// QuitToDesktopEvent
        /// </summary>
        public QuitToDesktopEvent() { }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}";
        }
    }
}
