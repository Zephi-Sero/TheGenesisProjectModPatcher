using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalPatcher.Chat;

namespace TheGenesisProjectModPatcher.Chat {
    /// <summary>
    /// Allows you to register aliases for commands
    /// </summary>
    public static class CommandAlias {
        /// <summary>
        /// Registar an alias
        /// </summary>
        /// <param name="alias">Command that, when typed, will resolve to aliasOf</param>
        /// <param name="aliasOf">Name of command that will be run</param>
        public static void RegisterAlias(string alias, string aliasOf) {
            ModdedCommands.commandaliases.Add(alias, aliasOf);
        }
    }
}
