using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TheGenesisProjectModPatcher.Mod;

namespace TheGenesisProjectModPatcher {
    internal static class ModLoader {
		public const string MOD_DIRECTORY = "./mods";
		
		private static TGPMod UnpackMod(string path) {
			var asm = Assembly.LoadFrom(path);
			TGPMod mod = null;
			foreach(var type in asm.GetExportedTypes()) {
				if(type.BaseType == typeof(TGPMod)) {
					mod = Activator.CreateInstance(type) as TGPMod;
					mod.Asm = asm;
					mod.Fullpath = Path.GetFullPath(path);
					break;
				}
			}
			return mod;
		}

		public static Dictionary<string, TGPMod> FindMods() {
			Dictionary<string, TGPMod> dict = new Dictionary<string,TGPMod>();
			foreach (var file in Directory.GetFiles(MOD_DIRECTORY,"*.dll")) {
				ModPatcherDebug.WriteLine($"Found mod file: {file}");
				dict.Add(file.ToString(), UnpackMod(file));
			}
			return dict;
		}
	}
}
