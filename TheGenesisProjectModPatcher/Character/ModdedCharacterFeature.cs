namespace TheGenesisProjectModPatcher.Character {
    /// <summary>
    /// Character feature
    /// </summary>
    public abstract class ModdedCharacterFeature : InternalPatcher.Character.ModdedCharacterFeature {
        /// <summary>
        /// Base constructor -- used when loading from saved char file
        /// </summary>
        /// <param name="loadedData">Data to load</param>
        public ModdedCharacterFeature(string loadedData) {}
    }
}
