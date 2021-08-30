using UnityEngine;

namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// PlayerMoveEvent
    /// </summary>
    public class PlayerMoveEvent : IGameEvent {
        /// <summary>
        /// Player ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// Where player is moving
        /// </summary>
        public Vector3 Location { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="id">Player ID</param>
        /// <param name="where">Location</param>"
        public PlayerMoveEvent(int id, Vector3 where) {
            PlayerID=id;
            Location=where;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tPlayer:{PlayerID}\nLocation:{Location}";
        }
    }
}
