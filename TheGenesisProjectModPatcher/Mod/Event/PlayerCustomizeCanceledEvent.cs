namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerCustomizeCanceledEvent
    /// </summary>
    public class PlayerCustomizeCanceledEvent : IGameEvent {
        /// <summary>
        /// ChangeSpritePart
        /// </summary>
        public ChangeSpritePart CSP { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        public PlayerCustomizeCanceledEvent(ChangeSpritePart csp) {
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
