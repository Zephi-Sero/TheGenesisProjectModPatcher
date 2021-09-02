using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TheGenesisProjectModPatcher.Mod {
	/// <summary>
	/// Abstract mod class -- inherit from to create your own mods
	/// </summary>
	public abstract class TGPMod {
		/// <summary>
		/// List of active mods.
		/// </summary>
		internal static List<TGPMod> activeMods = new List<TGPMod>();
		internal bool HasBeenPutIntoLoadOrder = false;
		/// <summary>
		/// Base mod constructor, adds itself to a list of active mods
		/// </summary>
		public TGPMod() {
			activeMods.Add(this);
			ModAssets = Application.dataPath + "/../mods/" + ModName;
		}
		/// <summary>
		/// Base mod deconstructor, removes itself from list of active mods.
		/// </summary>
		~TGPMod() {
			activeMods.Remove(this);
		}
		/// <summary>
		/// Full path to mod
		/// </summary>
		public string Fullpath;
		/// <summary>
		/// Mod's Assembly
		/// </summary>
		internal Assembly Asm;
		/// <summary>
		/// Name of mod
		/// </summary>
		public abstract string ModName { get; }
		/// <summary>
		/// Mod version
		/// </summary>
		public abstract string ModVersion { get; }
		/// <summary>
		/// Author of mod
		/// </summary>
		public abstract string ModAuthor { get; }
		/// <summary>
		/// ModTags to load after
		/// </summary>
        internal virtual List<string> LoadAfterTags { get => loadaftertags; set => loadaftertags=value; }
		/// <summary>
		/// ModTags -- used to determine when a mod should be loaded
		/// </summary>
		internal virtual List<string> ModTags { get => modtags; set => modtags=value; }
		private List<string> loadaftertags = new List<string>();
		private List<string> modtags = new List<string>();
		/// <summary>
		/// Use this to set the load after tags
		/// </summary>
		public virtual void SetLoadAfterTags() {
			loadaftertags = new List<string>();
        }
		/// <summary>
		/// Use this to set the mod tags
		/// </summary>
		public virtual void SetModTags() {
			modtags = new List<string>();
        }
		/// <summary>
		/// Dependencies of the mod -- Pairs of string to string, like
		/// new Pair("Dependency_Mod_Name", "[0.1.0, 0.2.0)")
		/// will require a mod with ModName = to Dependency_Mod_Name
		/// and its version must be 0.1.0-0.2.0, excluding 0.2.0
		/// </summary>
		public abstract Pair<string, string>[] Dependencies { get; }
		/// <summary>
		/// Path to mod assets, located at /mods/ModName/
		/// </summary>
		public static string ModAssets;
		/// <summary>
		/// Constructor of the mod, more or less, time that it's called is based on dependencies and LoadAfterTags
		/// </summary>
		public abstract void PatchMod();
	}
}
