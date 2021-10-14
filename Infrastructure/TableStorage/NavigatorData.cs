namespace TableStorage
{
    /// <summary>
    /// https://html.spec.whatwg.org/multipage/system-state.html#dom-navigator-appcodename
    /// Navigator
    /// </summary>
    public class NavigatorData
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
        public string AppVersion {  get; set; }

        /// <summary>
        /// Must return either the empty string or a string representing the platform
        /// on which the browser is executing, e.g. "MacIntel", "Win32", "FreeBSD i386", "WebTV OS"
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Must return the string "Gecko".
        /// </summary>
        public string Product { get; set; }
    }
}
