namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerUseAbilityEvent
    /// </summary>
    public class PlayerUseAbilityEvent : IGameEvent {
        /// <summary>
        /// Player ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Player ability
        /// </summary>
        public PlayerAbilityUse PAU { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <param name="pau">Player Ability Use</param>"
        public PlayerUseAbilityEvent(int id, PlayerAbilityUse pau) {
            PlayerID=id;
            PAU=pau;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tPlayer:{PlayerID}\nPAU:{PAU}";
        }
    }
}
