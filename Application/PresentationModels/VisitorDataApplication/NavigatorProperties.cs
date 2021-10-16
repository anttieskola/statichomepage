namespace PresentationModels.VisitorDataApplication
{
    /// <summary>
    /// https://html.spec.whatwg.org/multipage/system-state.html#dom-navigator-appcodename
    /// All lowercase starting
    /// Navigator
    /// </summary>
    public class NavigatorProperties
    {
        /// <summary>
        /// Must return the string "Mozilla".
        /// </summary>
        public string AppCodeName { get; set; }

        /// <summary>
        /// Must return the string "Netscape".
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// Must return either the string "4.0" or a string representing the version of
        /// the browser in detail, e.g. "1.0 (VMS; en-US) Mellblomenator/9000". 
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Must return either the empty string or a string representing the platform
        /// on which the browser is executing, e.g. "MacIntel", "Win32", "FreeBSD i386", "WebTV OS"
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Must return the string "Gecko".
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Must return the appropriate string from the following list:
        /// <list type="bullet">
        /// <item>If the navigator compatibility mode is Chrome or WebKit The string "20030107".</item>
        /// <item>If the navigator compatibility mode is Gecko The string "20100101".</item>
        /// </list>
        /// </summary>
        public string ProductSub { get; set; }

        /// <summary>
        /// Must return the default `User-Agent` value.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Must return the appropriate string from the following list:
        /// </summary>
        public string Vendor { get; set; }

        /// <summary>
        /// Must return the empty string.
        /// </summary>
        public string vendorSub { get; set; }

        /// <summary>
        /// Must return a valid BCP 47 language tag representing either a plausible language or the user's most preferred language.
        /// https://www.rfc-editor.org/info/bcp47
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Array of
        /// https://www.rfc-editor.org/info/bcp47
        /// </summary>
        public string Languages { get; set; }
    }
}
