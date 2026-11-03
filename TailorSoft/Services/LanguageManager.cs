using System.Globalization;
using TailorSoft_Data_Layer;

namespace TailorSoft.Services
{
    /// <summary>
    /// Manages language/culture settings for the application.
    /// Provides methods to set culture, manage UI direction (RTL/LTR), and apply localization across forms.
    /// </summary>
    public static class LanguageManager
    {
        // Event to notify when language changes
        public static event EventHandler? LanguageChanged;

        private static string _currentLanguage = "ar";
        private static int? _currentUserId = null;

        /// <summary>
        /// Gets the current language code (e.g., "ar", "fr")
        /// </summary>
        public static string CurrentLanguage => _currentLanguage;

        /// <summary>
        /// Gets the current user ID
        /// </summary>
        public static int? CurrentUserId => _currentUserId;

        /// <summary>
        /// Initializes the LanguageManager with default language.
        /// Call this on application startup.
        /// </summary>
        /// <param name="defaultLanguage">Default language code (default: "ar")</param>
        public static void Initialize(string defaultLanguage = "ar")
        {
            SetCulture(defaultLanguage);
        }

        /// <summary>
        /// Sets the current culture and updates UI direction (RTL/LTR).
        /// </summary>
        /// <param name="languageCode">Language code: "ar" for Arabic (RTL), "fr" for French (LTR), etc.</param>
        public static void SetCulture(string languageCode)
        {
            try
            {
                _currentLanguage = languageCode;

                // Set the culture for both CurrentCulture and CurrentUICulture
                CultureInfo culture = new CultureInfo(languageCode);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                // Clear cached resources when language changes
                LocalizationHelper.ClearCache();

                // Raise the LanguageChanged event
                LanguageChanged?.Invoke(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting culture: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the RightToLeft setting based on the language.
        /// </summary>
        /// <param name="languageCode">Language code</param>
        /// <returns>RightToLeft.Yes for RTL languages (Arabic), RightToLeft.No for LTR (French)</returns>
        public static RightToLeft GetRightToLeft(string languageCode)
        {
            return languageCode.ToLower() switch
            {
                "ar" => RightToLeft.Yes,  // Arabic is RTL
                "fr" => RightToLeft.No,   // French is LTR
                "en" => RightToLeft.No,   // English is LTR
                _ => RightToLeft.No       // Default to LTR
            };
        }

        /// <summary>
        /// Sets the current user and loads their language preference.
        /// </summary>
        /// <param name="userId">User ID</param>
        public static void SetCurrentUser(int userId)
        {
            try
            {
                _currentUserId = userId;

                // Retrieve user's language preference from database
                var user = clsUserData.GetUserById(userId);

                //if (user != null && !string.IsNullOrEmpty(user.Language))
                //{
                //    SetCulture(user.Language);
                //}
                //else
                //{
                //    SetCulture("ar"); // Default to Arabic if not set
                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error setting current user: {ex.Message}");
                SetCulture("ar");
            }
        }

        /// <summary>
        /// Updates user's language preference in the database.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="languageCode">Language code to set</param>
        /// <returns>True if update successful</returns>
        public static bool UpdateUserLanguage(int userId, string languageCode)
        {
            try
            {
                var user = clsUserData.GetUserById(userId);
                if (user != null)
                {
                    //user.Language = languageCode;
                    if (clsUserData.UpdateUser(user))
                    {
                        _currentLanguage = languageCode;
                        SetCulture(languageCode);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating user language: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets the display name for a language code.
        /// </summary>
        /// <param name="languageCode">Language code (e.g., "ar", "fr")</param>
        /// <returns>Display name in the target language</returns>
        public static string GetLanguageDisplayName(string languageCode)
        {
            return languageCode.ToLower() switch
            {
                "ar" => "العربية",
                "fr" => "Français",
                "en" => "English",
                _ => languageCode
            };
        }

        /// <summary>
        /// Gets all supported languages as key-value pairs (code, display name).
        /// </summary>
        /// <returns>Dictionary of language codes and display names</returns>
        public static Dictionary<string, string> GetSupportedLanguages()
        {
            return new Dictionary<string, string>
            {
                { "ar", "العربية" },
                { "fr", "Français" }
            };
        }
    }
}
