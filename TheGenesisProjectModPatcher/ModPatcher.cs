using System;
using System.Collections.Generic;
using System.Reflection;
using TheGenesisProjectModPatcher.Mod;
using TheGenesisProjectModPatcher.Mod.Event;

namespace TheGenesisProjectModPatcher {
    /// <summary>
    /// Base <c>ModPatcher</c> class.
    /// </summary>
    public class ModPatcher {
		
		/// <value>The version of the mod patcher being used.</value>
		public static Version ModPatcherVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version;
		/// <summary>
		/// Has the game already been patched?
		/// </summary>
        public static bool HasBeenPatched { get; set; }

		private static readonly Dictionary<int, EventListener> evtlisteners = new Dictionary<int, EventListener>();

		/// <summary>
		/// Registers an event listener to be triggered for every event
		/// </summary>
		/// <param name="listener">Listener</param>
		/// <returns>Listener ID, for use with RemoveEventListener(int id)</returns>
		public static int AddEventListener(EventListener listener) {
			evtlisteners.Add(evtlisteners.Count, listener);
			ModPatcherDebug.WriteLine($"Event Listener {listener} (#{evtlisteners.Count-1}) subscribed! Current Listeners: {evtlisteners.Count}");
			return (evtlisteners.Count-1);
        }
		/// <summary>
		/// Removes an event listener
		/// </summary>
		/// <param name="id">Listener ID</param>
		public static void RemoveEventListener(int id) {
			try {
				bool found = evtlisteners.TryGetValue(id, out EventListener el);
				if(!found || !evtlisteners.Remove(id)) ModPatcherDebug.WriteLine($"Event Listener #{id} does not exist in Event Bus Subscription Map! Current Listeners: {evtlisteners.Count}");
				else ModPatcherDebug.WriteLine($"Event Listener {el} (#{id}) unsubscribed! Current Listeners: {evtlisteners.Count}");
			} catch(Exception e) {
				ModPatcherDebug.WriteLine($"Event Listener #{id} could not be removed!\n{e}");
            }
        }
		/// <summary>
		/// Triggered by EventBus in the modified assembly-csharp
		/// </summary>
		/// <param name="evt">Event to be triggered</param>
		public static void TriggerEvent(IGameEvent evt) {
			foreach(var listener in evtlisteners.Values) {
				try {
					if(listener == null) ModPatcherDebug.WriteLine($"Listener is null!");
					if(evt == null) ModPatcherDebug.WriteLine($"Event is null!");
					if(listener.listeningFor == null) ModPatcherDebug.WriteLine($"listeningFor is null!");
					if(evt.GetType() == null) ModPatcherDebug.WriteLine($"evt type is null!");
					if(listener.listeningFor.Count == 0 || listener.listeningFor.Contains(evt.GetType())) {
						listener.OnEventTrigger(evt);
					}
				} catch(Exception e) {
					ModPatcherDebug.WriteLine($"Could not trigger event successfully: {evt} for listener: {listener} {e}");
                }
            }
        }
		private static void BeforePatch(Dictionary<string, TGPMod> mods) {
			foreach(var entry in mods) {
				var mod = entry.Value;
				var modfile = entry.Key;
				if(mod == null) {
					ModPatcherDebug.WriteLine($"(BeforePatch)Mod '{modfile}' failed to load: mod was null.", LogSeverity.ERROR);
					continue;
				}
				if(mod.Asm == null) {
					ModPatcherDebug.WriteLine($"(BeforePatch)Mod '{modfile}' failed to load: could not get Assembly.", LogSeverity.ERROR);
					continue;
				}
				ModPatcherDebug.WriteLine($"Calling BeforePatch of: {mod.Asm.GetName()}");
				mod.BeforePatch();
			}
		}
		private static void AfterPatch(Dictionary<string, TGPMod> mods) {
			foreach(var entry in mods) {
				var mod = entry.Value;
				var modfile = entry.Key;
				if(mod == null) {
					ModPatcherDebug.WriteLine($"(AfterPatch)Mod '{modfile}' failed to load: mod was null.", LogSeverity.ERROR);
					continue;
				}
				if(mod.Asm == null) {
					ModPatcherDebug.WriteLine($"(AfterPatch)Mod '{modfile}' failed to load: could not get Assembly.", LogSeverity.ERROR);
					continue;
				}
				ModPatcherDebug.WriteLine($"Calling AfterPatch of: {mod.Asm.GetName()}");
				mod.AfterPatch();
				ModPatcherDebug.WriteLine($"(AfterPatch)Mod '{mod.ModName}' loaded.", LogSeverity.INFO);
			}
		}
		/// <summary>
		/// Patches the game with the mod files.
		/// </summary>
		public static int PatchGame() {
			if (HasBeenPatched) return 1;
			HasBeenPatched = true;
			ModPatcherDebug.WriteLine("Starting ModPatcher...");
			var mods = ModLoader.FindMods();
			ModPatcher.BeforePatch(mods);
			ModPatcher.AfterPatch(mods);
			return 0;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public ModPatcher() {
			ModPatcherDebug.WriteLine("ModPatcher injection successful", LogSeverity.ESSENTIAL);
			int num = PatchGame();
			if(num == 0) {
				ModPatcherDebug.WriteLine("Mods patched successfully!", LogSeverity.INFO);
            } else if(num == 1) {
				ModPatcherDebug.WriteLine("Mods have already been patched!", LogSeverity.WARNING);
			} else {
				ModPatcherDebug.WriteLine("Mod patching failed with unknown error!", LogSeverity.FATAL);
			}
		}
	}
}
