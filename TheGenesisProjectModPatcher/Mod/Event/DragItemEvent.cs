namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// DragItemEvent - triggered when an item started being dragged
    /// </summary>
    public class DragItemEvent : IGameEvent {
        /// <summary>
        /// Item that was dragged
        /// </summary>
        public Item Item { get; set; }
        /// <summary>
        /// Sylladex of player dragging the item
        /// </summary>
        public Sylladex Sylladex { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="item">Item being dragged</param>
        /// <param name="sylladex">Sylladex of player dragging item</param>
        public DragItemEvent(Item item, Sylladex sylladex) {
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
