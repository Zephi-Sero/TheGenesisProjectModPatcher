namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// ChangeSpritePartCommitEvent
    /// </summary>
    public class ChangeSpritePartCommitEvent : IGameEvent {
        /// <summary>
        /// ChangeSpritePart
        /// </summary>
        public ChangeSpritePart CSP { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        public ChangeSpritePartCommitEvent(ChangeSpritePart csp) {
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
