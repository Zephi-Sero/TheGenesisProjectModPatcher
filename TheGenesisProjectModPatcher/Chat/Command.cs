using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalPatcher.Chat;

namespace TheGenesisProjectModPatcher.Chat {
    /// <summary>
    /// Extendable chat command
    /// </summary>
    public abstract class ChatCommand : ModdedChatCommand {
        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="cmd">Command name</param>
        public ChatCommand(string cmd) : base(cmd) {}
    }
}
