namespace ThpsQScriptEd.Properties
{
    /// <summary>
    /// Minimal replacement for the old WinForms-generated user-settings class.
    /// The CLI has no UI to change these, so it just exposes the former default
    /// values as read-only members via a <see cref="Default"/> singleton, keeping
    /// the existing <c>Settings.Default.X</c> call sites unchanged.
    /// </summary>
    internal sealed class Settings
    {
        public static Settings Default { get; } = new Settings();

        public bool useTab => false;
        public bool useShortLine => true;
        public bool useSymFile => false;
        public byte minQBLevel => 3;
        public bool useCaps => false;
        public bool roundAngles => true;
        public bool useDegrees => true;
        public bool removeTrailNewlines => true;
        public bool fixIncorrectChecksums => false;
        public bool applyCosmetics => false;
    }
}
