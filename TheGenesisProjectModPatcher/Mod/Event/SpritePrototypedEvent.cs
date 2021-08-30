using UnityEngine;

namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// SpritePrototypedEvent
    /// </summary>
    public class SpritePrototypedEvent : IGameEvent {
        /// <summary>
        /// KernelSprite that was prototyped
        /// </summary>
        public KernelSprite Sprite { get; set; }
        /// <summary>
        /// Player ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// AssetBundle that was prototyped
        /// </summary>
        public AssetBundle Proto { get; set; }
        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="sprite">KernelSprite</param>
        /// <param name="id">Player ID</param>
        /// <param name="proto">AssetBundle that was prototyped</param>
        public SpritePrototypedEvent(KernelSprite sprite, int id, AssetBundle proto) {
            Sprite=sprite;
            PlayerID=id;
            Proto=proto;
        }
        /// <summary>
        /// Get string version of this object
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString() {
            return $"{GetType().Name}:\n\tSprite:{Sprite}\n\tPlayer:{PlayerID}\n\tProto:{Proto}";
        }
    }
}
