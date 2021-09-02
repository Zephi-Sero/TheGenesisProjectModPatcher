using System;
using System.Collections.Generic;
using System.Linq;
using TheGenesisProjectModPatcher.Mod;
using TheGenesisProjectModPatcher.Mod.Event;

namespace TheGenesisProjectModPatcher {
    /// <summary>
    /// Base <c>ModPatcher</c> class.
    /// </summary>
    public class ModPatcher {
		
		/// <value>The version of the mod patcher being used.</value>
		public static string ModPatcherVersion = "0.2.0";
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
		/// <summary>
		/// Patches the game with the mod files.
		/// </summary>
		public static int PatchGame() {
			if (HasBeenPatched) return 1;
			HasBeenPatched = true;
			ModPatcherDebug.WriteLine("Starting ModPatcher...");
			Dictionary<string,TGPMod> mods = ModLoader.FindMods();
			Dictionary<string, bool> TagFinishedLoading = new Dictionary<string, bool>();
			ModPatcherDebug.WriteLine("Verifying dependencies");
			foreach(KeyValuePair<string,TGPMod> modfile in mods) {
				Pair<string, string>[] dependencies = modfile.Value.Dependencies;
				foreach(Pair<string, string> dependency in dependencies) {
					string version_preparse = dependency.b;
					string[] version_split_preparse = version_preparse.Split(',');
					Pair<string, bool> minversion = new Pair<string, bool>(version_split_preparse[0].Substring(1), version_split_preparse[0].IndexOf('[') == -1);
					Pair<string, bool> maxversion = new Pair<string, bool>(version_split_preparse[1].Substring(0, version_split_preparse[1].Length-1), version_split_preparse[1].IndexOf(']') == -1);
					ModPatcherDebug.WriteLine("Dependency required: " + dependency.a + ", version min" + (minversion.b ? "(exclusive)" : "(inclusive)") + ":" + minversion.a + " max"  + (maxversion.b ? "(exclusive)" : "(inclusive)") +  ":" + maxversion.a);
					bool dependencyfound = false;
					string[] minversion_split = minversion.a.Split('.');
					string[] maxversion_split = maxversion.a.Split('.');
					if(dependency.a == "TheGenesisProjectModPatcher") {
						string version = ModPatcherVersion;
						string[] version_split = version.Split('.');
						for(int min_idx = 0; min_idx < minversion_split.Length; min_idx++) {
							if(int.TryParse(minversion_split[min_idx], out int min_vers)) {
								if(min_idx < version_split.Length) {
									if(int.TryParse(version_split[min_idx], out int vers)) {
										if(vers < min_vers || (vers == min_vers && minversion.b && min_idx == minversion_split.Length-1)) {
											ModPatcherDebug.WriteLine("Dependency too old: mod '" + modfile.Value.ModName + "' " + modfile.Value.ModVersion +
																	  " requires '" + dependency.a + "' version: " + dependency.b + " but you have version " + version);
											Environment.Exit(0);
										}
									} else {
										ModPatcherDebug.WriteLine("Invalid mod version number: '" + minversion.a + "'");
										Environment.Exit(0);
									}
								} else {
									ModPatcherDebug.WriteLine("Versions do not have same number of splits: dependency minimum ('" + minversion.a + "') and mod ('" + version + "'");
									Environment.Exit(0);
								}
							} else {
								ModPatcherDebug.WriteLine("Invalid minimum version number: '" + minversion.a + "'");
								Environment.Exit(0);
							}
						}
						for(int max_idx = 0; max_idx < maxversion_split.Length; max_idx++) {
							if(int.TryParse(maxversion_split[max_idx], out int max_vers)) {
								if(max_idx < version_split.Length) {
									if(int.TryParse(version_split[max_idx], out int vers)) {
										if(vers > max_vers || (vers == max_vers && maxversion.b && max_idx == maxversion_split.Length-1)) {
											ModPatcherDebug.WriteLine(vers.ToString());
											ModPatcherDebug.WriteLine(max_vers.ToString());
											ModPatcherDebug.WriteLine(maxversion.b.ToString());
											ModPatcherDebug.WriteLine("Dependency too recent: mod '" + modfile.Value.ModName + "' " + modfile.Value.ModVersion +
																	  " requires '" + dependency.a + "' version: " + dependency.b + " but you have version " + version);
											Environment.Exit(0);
										} else {
											dependencyfound = true;
											break;
										}
									} else {
										ModPatcherDebug.WriteLine("Invalid mod version number: '" + maxversion.a + "'");
										Environment.Exit(0);
									}
								} else {
									ModPatcherDebug.WriteLine("Versions do not have same number of splits: dependency max ('" + maxversion.a + "') and mod ('" + version + "'");
									Environment.Exit(0);
								}
							} else {
								ModPatcherDebug.WriteLine("Invalid maximum version number: '" + maxversion.a + "'");
								Environment.Exit(0);
							}
						}
					} else {
						foreach(KeyValuePair<string, TGPMod> versionCheck in mods) {
							string modname = versionCheck.Value.ModName;
							if(modname != dependency.a) continue;
							string version = versionCheck.Value.ModVersion;
							string[] version_split = versionCheck.Value.ModVersion.Split('.');
							for(int min_idx = 0; min_idx < minversion_split.Length; min_idx++) {
								if(int.TryParse(minversion_split[min_idx], out int min_vers)) {
									if(min_idx < version_split.Length) {
										if(int.TryParse(version_split[min_idx], out int vers)) {
											if(vers < min_vers || (vers == min_vers && minversion.b && min_idx == minversion_split.Length-1)) {
												ModPatcherDebug.WriteLine("Dependency mismatch: mod '" + modfile.Value.ModName + "' " + modfile.Value.ModVersion +
																		  " requires '" + dependency.a + "' version: " + dependency.b + " but you have version " + version);
												Environment.Exit(0);
											}
										} else {
											ModPatcherDebug.WriteLine("Invalid mod version number: '" + minversion.a + "'");
											Environment.Exit(0);
										}
									} else {
										ModPatcherDebug.WriteLine("Versions do not have same number of splits: dependency minimum ('" + minversion.a + "') and mod ('" + version + "'");
										Environment.Exit(0);
									}
								} else {
									ModPatcherDebug.WriteLine("Invalid minimum version number: '" + minversion.a + "'");
									Environment.Exit(0);
								}
							}
							for(int max_idx = 0; max_idx < maxversion_split.Length; max_idx++) {
								if(int.TryParse(maxversion_split[max_idx], out int max_vers)) {
									if(max_idx < version_split.Length) {
										if(int.TryParse(version_split[max_idx], out int vers)) {
											if(vers > max_vers || (vers == max_vers && maxversion.b && max_idx == maxversion_split.Length-1)) {
												ModPatcherDebug.WriteLine("Dependency mismatch: mod '" + modfile.Value.ModName + "' " + modfile.Value.ModVersion +
																		  " requires '" + dependency.a + "' version: " + dependency.b + " but you have version " + version);
												Environment.Exit(0);
											} else {
												modfile.Value.LoadAfterTags.Add(dependency.a + dependency.b);
												versionCheck.Value.ModTags.Add(dependency.a + dependency.b);
												dependencyfound = true;
												break;
											}
										} else {
											ModPatcherDebug.WriteLine("Invalid mod version number: '" + maxversion.a + "'");
											Environment.Exit(0);
										}
									} else {
										ModPatcherDebug.WriteLine("Versions do not have same number of splits: dependency max ('" + maxversion.a + "') and mod ('" + version + "'");
										Environment.Exit(0);
									}
								} else {
									ModPatcherDebug.WriteLine("Invalid maximum version number: '" + maxversion.a + "'");
									Environment.Exit(0);
								}
							}
						}
					}
					if(!dependencyfound) {
						ModPatcherDebug.WriteLine("Could not find dependency: " + dependency.a + ", version min" + (minversion.b ? "(exclusive)" : "(inclusive)") + ":" + minversion.a + " max"  + (maxversion.b ? "(exclusive)" : "(inclusive)") +  ":" + maxversion.a);
						Environment.Exit(0);
					} else {
						ModPatcherDebug.WriteLine("Found dependency!");
                    }
				}
            }
			ModPatcherDebug.WriteLine("Dependencies verified, creating tags");
			foreach(KeyValuePair<string,TGPMod> modfile in mods) {
				TGPMod mod = modfile.Value;
				
				foreach(string tag in mod.ModTags) {
					if(!TagFinishedLoading.ContainsKey(tag)) TagFinishedLoading.Add(tag, false);
                }
            }
			List<TGPMod> loadorder = new List<TGPMod>();
			ModPatcherDebug.WriteLine("Adding mods without any tag requirements to load order first");
			foreach(KeyValuePair<string, TGPMod> modfile in mods) {
				if(modfile.Value.LoadAfterTags.Count == 0) {
					loadorder.Add(modfile.Value);
					modfile.Value.HasBeenPutIntoLoadOrder = true;
				}
            }
			List<string> tagsToFinish = new List<string>();
			ModPatcherDebug.WriteLine("Re-calculating which tags are finished loading");
			foreach(string tag in TagFinishedLoading.Keys) {
				bool finished = true;
				foreach(KeyValuePair<string, TGPMod> modfile in mods) {
					if(!modfile.Value.ModTags.Contains(tag)) continue;
					finished = finished && modfile.Value.HasBeenPutIntoLoadOrder;
				}
				if(finished) tagsToFinish.Add(tag);
			}
			foreach(string tag in tagsToFinish) {
				TagFinishedLoading[tag] = true;
            }
			bool allmodsloaded = false;
			ModPatcherDebug.WriteLine("Loading tag-dependent mods");
			while(!allmodsloaded) {
				allmodsloaded = true;
				foreach(KeyValuePair<string, TGPMod> modfile in mods) {
					if(!modfile.Value.HasBeenPutIntoLoadOrder && modfile.Value.LoadAfterTags.Count >= 1) {
						allmodsloaded = false;
						bool loadable = true;
						foreach(string tag in modfile.Value.LoadAfterTags) {
							bool noneoftag = !TagFinishedLoading.TryGetValue(tag, out bool finished);
							loadable = loadable && (finished || noneoftag);
						}
						if(loadable) {
							loadorder.Add(modfile.Value);
							modfile.Value.HasBeenPutIntoLoadOrder = true;
						}
					}
				}
			}
			ModPatcherDebug.WriteLine("Load order finalized, loading mods...");
			foreach(TGPMod mod in loadorder) {
				mod.PatchMod();
            }
			ModPatcherDebug.WriteLine("Mods loaded successfully!");
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
