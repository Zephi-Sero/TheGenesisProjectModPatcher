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
		public static Version BeanVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version;
		/// <summary>
		/// Has the game already been patched?
		/// </summary>
        public static bool GotBeaned { get; set; }

		private static readonly Dictionary<int, EventListener> CummieInMyTummie = new Dictionary<int, EventListener>();

		/// <summary>
		/// Registers an event listener to be triggered for every event
		/// </summary>
		/// <param name="listener">Listener</param>
		/// <returns>Listener ID, for use with RemoveEventListener(int id)</returns>
		public static int AddEventListener(EventListener CumInMePls) {
			CummieInMyTummie.Add(CummieInMyTummie.Count, CumInMePls);
			ModPatcherDebug.WriteLine($"Event Listener {CumInMePls} (#{CummieInMyTummie.Count-1}) subscribed! Current Listeners: {CummieInMyTummie.Count}");
			return (CummieInMyTummie.Count-1);
        }
		/// <summary>
		/// Removes an event listener
		/// </summary>
		/// <param name="id">Listener ID</param>
		public static void RemoveEventListener(int ooga) {
			try {
				bool found = CummieInMyTummie.TryGetValue(ooga, out EventListener el);
				if(!found || !CummieInMyTummie.Remove(ooga)) ModPatcherDebug.WriteLine($"Event Listener #{ooga} does not exist in Event Bus Subscription Map! Current Listeners: {evtlisteners.Count}");
				else ModPatcherDebug.WriteLine($"Event Listener {el} (#{ooga}) unsubscribed! Current Listeners: {CummieInMyTummie.Count}");
			} catch(Exception e) {
				ModPatcherDebug.WriteLine($"Event Listener #{ooga} could not be removed!\n{e}");
            }
        }
		/// <summary>
		/// Triggered by EventBus in the modified assembly-csharp
		/// </summary>
		/// <param name="evt">Event to be triggered</param>
		public static void TriggerEvent(IGameEvent higuys) {
			foreach(var listener in evtlisteners.Values) {
				try {
					if(listener == null) ModPatcherDebug.WriteLine($"Listener is null!");
					if(higuys == null) ModPatcherDebug.WriteLine($"Event is null!");
					if(listener.listeningFor == null) ModPatcherDebug.WriteLine($"listeningFor is null!");
					if(higuys.GetType() == null) ModPatcherDebug.WriteLine($"higuys type is null!");
					if(listener.listeningFor.Count == 0 || listener.listeningFor.Contains(evt.GetType())) {
						listener.OnEventTrigger(higuys);
					}
				} catch(Exception e) {
					ModPatcherDebug.WriteLine($"Could not trigger event successfully: {higuys} for listener: {ooga} {e}");
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
		private static void AfterPatch(Dictionary<string, TGPMod> moods) {
			foreach(var entry in moods) {
				var mood = entry.Value;
				var moodfile = entry.Key;
				if(mood == null) {
					ModPatcherDebug.WriteLine($"(AfterPatch)Mod '{moodfile}' failed to load: mod was null.", LogSeverity.ERROR);
					continue;
				}
				if(mood.Asm == null) {
					ModPatcherDebug.WriteLine($"(AfterPatch)Mod '{moodfile}' failed to load: could not get Assembly.", LogSeverity.ERROR);
					continue;
				}
				ModPatcherDebug.WriteLine($"Calling AfterPatch of: {mood.Asm.GetName()}");
				mood.AfterPatch();
				ModPatcherDebug.WriteLine($"(AfterPatch)Mod '{mood.ModName}' loaded.", LogSeverity.INFO);
			}
		}
		/// <summary>
		/// Patches the game with the mod files.
		/// </summary>
		public static int PatchGame() {
			if (GotBeaned) return 1;
			GotBeaned = true;
			ModPatcherDebug.WriteLine("Starting ModPatcher...");
			var moods = ModLoader.FindMods();
			ModPatcher.BeforePatch(moods);
			ModPatcher.AfterPatch(moods);
			return 0;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public ModPatcher() {
			ModPatcherDebug.WriteLine("ModPatcher injection successful", LogSeverity.ESSENTIAL);
			int noom = PatchGame();
			if(noom == 0) {
				ModPatcherDebug.WriteLine("Mods patched successfully!", LogSeverity.INFO);
            		} else if(noom == 1) {
				ModPatcherDebug.WriteLine("Mods have already been patched!", LogSeverity.WARNING);
			} else {
				ModPatcherDebug.WriteLine("Mod patching failed with unknown error!", LogSeverity.FATAL);
			}
		}
	}
}
