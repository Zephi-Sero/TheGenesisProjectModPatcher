namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// ChangeSpritePartRefreshEvent
    /// </summary>
    public class ChangeSpritePartRefreshEvent : IGameEvent {
        /// <summary>
        /// ChangeSpritePart
        /// </summary>
        public ChangeSpritePart CSP { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        public ChangeSpritePartRefreshEvent(ChangeSpritePart csp) {
            CSP=csp;
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
