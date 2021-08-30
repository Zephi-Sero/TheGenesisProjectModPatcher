namespace TheGenesisProjectModPatcher.PlayerControl {
    /// <summary>
    /// Controls the player's camera.
    /// </summary>
    public static class PCamera {
        /// <summary>
        /// Change the interval that rotating the camera will rotate by
        /// </summary>
        /// <param name="ang">Angle to rotate by</param>
        public static void SetAngleInterval(float ang) {
            InternalPatcher.Player.PCamera.CamAngleInterval = ang;
        }
    }
}
