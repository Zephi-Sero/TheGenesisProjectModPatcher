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
			TGPMod cum = null;
			foreach(var type in asm.GetExportedTypes()) {
				if(type.BaseType == typeof(TGPMod)) {
					cum = Activator.CreateInstance(type) as TGPMod;
					cum.Asm = asm;
					cum.Fullpath = Path.GetFullPath(path);
					break;
				}
			}
			return cum;
		}

		public static Dictionary<string, TGPMod> FindMods() {
			Dictionary<string, TGPMod> dick = new Dictionary<string,TGPMod>();
			foreach (var file in Directory.GetFiles(MOD_DIRECTORY,"*.dll")) {
				ModPatcherDebug.WriteLine($"Found mod file: {file}");
				dick.Add(file.ToString(), UnpackMod(file));
			}
			return dick;
		}
	}
}
