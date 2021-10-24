namespace VisitorDataApplication.Entitites
{
    /// <summary>
    /// Visitors browsers properties (window.navigator)
    /// JS properties have same name but start with lowercase letter.
    /// https://html.spec.whatwg.org/multipage/system-state.html#dom-navigator-appcodename
    /// </summary>
    internal record NavigatorProperties
    {
        /// <summary>
        /// Must return the string "Mozilla".
        /// </summary>
        public string AppCodeName { get; init; }

        /// <summary>
        /// Must return the string "Netscape".
        /// </summary>
        public string AppName { get; init; }

        /// <summary>
        /// Must return either the string "4.0" or a string representing the version of
        /// the browser in detail, e.g. "1.0 (VMS; en-US) Mellblomenator/9000". 
        /// </summary>
        public string AppVersion { get; init; }

        /// <summary>
        /// Must return either the empty string or a string representing the platform
        /// on which the browser is executing, e.g. "MacIntel", "Win32", "FreeBSD i386", "WebTV OS"
        /// </summary>
        public string Platform { get; init; }

        /// <summary>
        /// Must return the string "Gecko".
        /// </summary>
        public string Product { get; init; }

        /// <summary>
        /// Must return the appropriate string from the following list:
        /// <list type="bullet">
        /// <item>If the navigator compatibility mode is Chrome or WebKit The string "20030107".</item>
        /// <item>If the navigator compatibility mode is Gecko The string "20100101".</item>
        /// </list>
        /// </summary>
        public string ProductSub { get; init; }

        /// <summary>
        /// Must return the default `User-Agent` value.
        /// </summary>
        public string UserAgent { get; init; }

        /// <summary>
        /// Must return the appropriate string from the following list:
        /// </summary>
        public string Vendor { get; init; }

        /// <summary>
        /// Must return the empty string.
        /// </summary>
        public string VendorSub { get; init; }

        /// <summary>
        /// Must return a valid BCP 47 language tag representing either a plausible language or the user's most preferred language.
        /// https://www.rfc-editor.org/info/bcp47
        /// </summary>
        public string Language { get; init; }

        /// <summary>
        /// Array of
        /// https://www.rfc-editor.org/info/bcp47
        /// </summary>
        public string[] Languages { get; init; }

        /// <summary>
        /// Create NavigatorProperties record
        /// </summary>
        /// <param name="appCodeName"></param>
        /// <param name="appName"></param>
        /// <param name="appVersion"></param>
        /// <param name="platform"></param>
        /// <param name="product"></param>
        /// <param name="productSub"></param>
        /// <param name="userAgent"></param>
        /// <param name="vendor"></param>
        /// <param name="vendorSub"></param>
        /// <param name="language"></param>
        /// <param name="languages"></param>
        /// <exception cref="ArgumentNullException">if any argument is null</exception>
        public NavigatorProperties(string appCodeName, string appName, string appVersion, string platform, string product, string productSub, string userAgent, string? vendor, string vendorSub, string language, string[] languages)
        {
            AppCodeName = appCodeName ?? throw new ArgumentNullException(nameof(appCodeName));
            AppName = appName ?? throw new ArgumentNullException(nameof(appName));
            AppVersion = appVersion ?? throw new ArgumentNullException(nameof(appVersion));
            Platform = platform ?? throw new ArgumentNullException(nameof(platform));
            Product = product ?? throw new ArgumentNullException(nameof(product));
            ProductSub = productSub ?? throw new ArgumentNullException(nameof(productSub));
            UserAgent = userAgent ?? throw new ArgumentNullException(nameof(userAgent));
            Vendor = vendor ?? throw new ArgumentNullException(nameof(vendor));
            VendorSub = vendorSub ?? throw new ArgumentNullException(nameof(vendorSub));
            Language = language ?? throw new ArgumentNullException(nameof(language));
            Languages = languages ?? throw new ArgumentNullException(nameof(languages));
        }
    }
}
