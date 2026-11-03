using System.Globalization;
using System.Resources;

namespace TailorSoft.Services
{
    /// <summary>
    /// Helper class to manage localization and resource string retrieval.
    /// Provides methods to get localized strings from resource files based on culture and control name.
    /// </summary>
    public static class LocalizationHelper
    {
        private static readonly Dictionary<string, ResourceManager> _resourceManagers = new Dictionary<string, ResourceManager>();

        /// <summary>
        /// Gets a localized string from the resource file for a specific form.
        /// </summary>
        /// <param name="formName">The name of the form (e.g., "frmLogin")</param>
        /// <param name="resourceKey">The resource key to retrieve (e.g., "label1_Text")</param>
        /// <param name="cultureName">The culture name (e.g., "ar", "fr", "en"). Defaults to current culture.</param>
        /// <returns>The localized string, or the resource key if not found.</returns>
        public static string GetString(string formName, string resourceKey, string? cultureName = null)
        {
            try
            {
                cultureName ??= CultureInfo.CurrentUICulture.Name.Split('-')[0]; // Get language part (ar, fr, en, etc.)

                string resourceName = $"TailorSoft.Resources.{formName}";

                if (!_resourceManagers.ContainsKey(resourceName))
                {
                    _resourceManagers[resourceName] = new ResourceManager(resourceName, typeof(LocalizationHelper).Assembly);
                }

                ResourceManager rm = _resourceManagers[resourceName];

                // Try to get the string for the specific culture
                string? result = rm.GetString(resourceKey, new CultureInfo(cultureName));

                return result ?? resourceKey; // Return resource key if string not found
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading localized string: {ex.Message}");
                return resourceKey; // Return resource key on error
            }
        }

        /// <summary>
        /// Clears the cached resource managers. Call this when switching cultures at runtime.
        /// </summary>
        public static void ClearCache()
        {
            _resourceManagers.Clear();
        }

        /// <summary>
        /// Gets a string with fallback to neutral resource if culture-specific resource not found.
        /// </summary>
        /// <param name="formName">The name of the form</param>
        /// <param name="resourceKey">The resource key</param>
        /// <param name="cultureName">The culture name</param>
        /// <returns>The localized string or the key if not found</returns>
        public static string GetStringWithFallback(string formName, string resourceKey, string? cultureName = null)
        {
            cultureName ??= CultureInfo.CurrentUICulture.Name.Split('-')[0];

            string result = GetString(formName, resourceKey, cultureName);

            // If we got back the key (not found), try neutral culture
            if (result == resourceKey && cultureName != "en")
            {
                result = GetString(formName, resourceKey, "en");
            }

            return result;
        }
    }
}
