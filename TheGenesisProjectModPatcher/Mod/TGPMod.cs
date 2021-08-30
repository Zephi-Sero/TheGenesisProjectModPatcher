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
		public string Fullpath { get; internal set; }
		/// <summary>
		/// Mod's Assembly
		/// </summary>
		internal Assembly Asm { get; set; }
		/// <summary>
		/// Mod's name as a <c>string</c>
		/// </summary>
		public abstract string ModName { get; }
		/// <summary>
		/// Version of mod as a <c>Version</c>
		/// </summary>
		public abstract Version ModVersion { get; }
		/// <summary>
		/// Author of mod, as a <c>string</c>
		/// </summary>
		public abstract string ModAuthor { get; }
		/// <summary>
		/// Path to mod assets, located at /mods/ModName/
		/// </summary>
		public readonly string ModAssets;
		/// <summary>
		/// Patch that happens before the main patch
		/// </summary>
		public abstract void BeforePatch();
		/// <summary>
		/// Patch that happens after the main patch
		/// </summary>
		public abstract void AfterPatch();

	}
}
