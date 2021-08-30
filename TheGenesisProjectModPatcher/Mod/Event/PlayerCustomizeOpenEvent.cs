namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerCustomizeOpenEvent
    /// </summary>
    public class PlayerCustomizeOpenEvent : IGameEvent {
        /// <summary>
        /// ChangeSpritePart.CharacterOptionsGridComponent
        /// </summary>
        public CharacterOptionsGridComponent COGC { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        public PlayerCustomizeOpenEvent(CharacterOptionsGridComponent cogc) {
            COGC=cogc;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\t{COGC}";
        }
    }
}
