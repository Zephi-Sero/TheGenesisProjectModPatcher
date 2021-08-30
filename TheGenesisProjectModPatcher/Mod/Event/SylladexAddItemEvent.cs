namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Triggered when an item is added to the sylladex
    /// </summary>
    public class SylladexAddItemEvent : IGameEvent {
        /// <summary>
        /// Item that was put into the sylladex
        /// </summary>
        public Item Item { get; set; }
        /// <summary>
        /// Sylladex containing the item.
        /// </summary>
        public Sylladex Sylladex { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <param name="sylladex">Sylladex added to</param>
        public SylladexAddItemEvent(Item item, Sylladex sylladex) {
            this.Item=item;
            this.Sylladex=sylladex;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tSylladex:{Sylladex}\n\tItem:{Item}";
        }
    }
}
