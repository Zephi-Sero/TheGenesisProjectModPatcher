using System;
using System.Collections.Generic;

namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// SingleEventListener class -- listens until OnEvent() returns true, then ignores all other events.
    /// </summary>
    public abstract class SingleEventListener : EventListener {
        /// <summary>
        /// Whether all events should be ignored.
        /// </summary>
        private bool disabled = false;
        /// <summary>
        /// Create event listener w/ mod
        /// </summary>
        /// <param name="mod">Mod owning this listener</param>
        protected SingleEventListener(TGPMod mod) : base(mod) {}
        /// <summary>
        /// Create event listener w/ mod and types to listen for
        /// </summary>
        /// <param name="mod">Mod owning this listener</param>
        /// <param name="listeningFor">List of types to listen for</param>
        protected SingleEventListener(TGPMod mod, List<Type> listeningFor) : base(mod, listeningFor) {}

        /// <summary>
        /// Event handler -- DO NOT USE
        /// </summary>
        internal override void OnEventTrigger(IGameEvent evt) {
            if(!disabled) disabled = OnEvent(evt);
        }
    }
}
