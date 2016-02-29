using BowlersBuddy.WinPhoneMVVM10.Resources;

namespace BowlersBuddyXam.WinPhone.Resources
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static readonly AppResources _localizedResources = new AppResources();

        internal AppResources LocalizedResources { get { return _localizedResources; } }
    }
}
