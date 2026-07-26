using System;

namespace ThpsQScriptEd
{
    /// <summary>
    /// CLI replacement for the old WinForms MainForm's user-facing message hooks.
    /// The core still calls <c>MainForm.WarnUser(...)</c> / <c>MainForm.Warn(...)</c>
    /// in ~25 places; here they simply write to stderr instead of popping a MessageBox,
    /// which keeps the core cross-platform and leaves those call sites untouched.
    /// </summary>
    internal static class MainForm
    {
        public static void WarnUser(string message) => Console.Error.WriteLine("WARN: " + message);

        public static void Warn(string message) => Console.Error.WriteLine(message);
    }
}
