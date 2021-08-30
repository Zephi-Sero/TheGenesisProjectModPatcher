using System;
using System.Collections.Generic;

namespace TheGenesisProjectModPatcher.Mod.Event {
    /// <summary>
    /// Event Listener class -- events that it is listening to can be added, by default listens to all.
    /// </summary>
    public abstract class EventListener {
        /// <summary>
        /// Events to listen for. When listeningTo is empty, listens for any event.
        /// </summary>
        public List<Type> listeningFor = new List<Type>();
        /// <summary>
        /// Mod containing this event listener.
        /// </summary>
        public TGPMod mod;
        /// <summary>
        /// Event Listener constructor
        /// </summary>
        /// <param name="mod">Mod this event listener is owned by.</param>
        public EventListener(TGPMod mod) {
            this.mod=mod;
        }
        /// <summary>
        /// Event Listener constructor with list of events to listen for
        /// </summary>
        /// <param name="mod">Mod this event listener is owned by.</param>
        /// <param name="listeningFor">List of Types of GameEvents to listen for</param>
        public EventListener(TGPMod mod, List<Type> listeningFor) {
            this.mod=mod;
            this.listeningFor=listeningFor;
        }
        /// <summary>
        /// Function triggered by event
        /// </summary>
        internal virtual void OnEventTrigger(IGameEvent evt) {
            OnEvent(evt);
        }
        /// <summary>
        /// Triggered by OnEventTrigger by the event bus
        /// </summary>
        /// <param name="evt">Event that was triggered</param>
        /// <returns>Conditional boolean -- only used by some kinds of event listeners (Such as SingleEventListener, to tell the event bus whether it should actually unsubscribe the listener)</returns>
        public abstract bool OnEvent(IGameEvent evt);
    }
}
