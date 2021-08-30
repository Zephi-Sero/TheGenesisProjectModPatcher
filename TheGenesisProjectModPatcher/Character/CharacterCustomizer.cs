namespace TheGenesisProjectModPatcher.Character {
    /// <summary>
    /// Holds various functions for the character customization screen
    /// </summary>
    public static class CharacterCustomizer {
        /// <summary>
        /// Add a mod to the character customizer custom tab
        /// </summary>
        /// <param name="modname">Mod name (is displayed on button)</param>
        /// <param name="func">Function to run when button is clicked</param>
        public static void AddModToCustomizer(string modname, UnityEngine.Events.UnityAction func) {
            InternalPatcher.PatcherBus.AddCharacterCustomizationModButton(modname, func);
        }
    }
}
