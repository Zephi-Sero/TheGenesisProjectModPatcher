namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerCustomizeFinishedEvent
    /// </summary>
    public class PlayerCustomizeFinishedEvent : IGameEvent {
        /// <summary>
        /// ChangeSpritePart
        /// </summary>
        public ChangeSpritePart CSP { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        public PlayerCustomizeFinishedEvent(ChangeSpritePart csp) {
            CSP = csp;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\t{CSP}";
        }
    }
}
