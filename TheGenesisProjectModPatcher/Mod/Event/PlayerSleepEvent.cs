using UnityEngine;

namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerSleepEvent - triggered 3 seconds after a player sleeps
    /// </summary>
    public class PlayerSleepEvent : IGameEvent {
        /// <summary>
        /// Player ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Where player is sleeping
        /// </summary>
        public Vector3 Location { get; set; }
        /// <summary>
        /// Trigger string
        /// </summary>
        public string Trigger { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <param name="where">Location of sleeping</param>
        /// <param name="trigger">Trigger string</param>
        public PlayerSleepEvent(int id, Vector3 where, string trigger) {
            PlayerID=id;
            Location=where;
            Trigger=trigger;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tPlayer:{PlayerID}\nLocation:{Location}\nTrigger:{Trigger}";
        }
    }
}
