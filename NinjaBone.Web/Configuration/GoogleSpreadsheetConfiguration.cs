using System.Configuration;

namespace NinjaBone.Web.Configuration
{
    public class GoogleSpreadsheetConfiguration : ConfigurationSection, ISpreadsheetConfiguration
    {
        /// <summary>
        /// Gets the twitter account name
        /// </summary>
        [ConfigurationProperty("spreadsheetKey")]
        public string SpreadsheetKey
        {
            get
            {
                return this["spreadsheetKey"] as string;
            }
        }

        /// <summary>
        /// Gets the twitter account name
        /// </summary>
        [ConfigurationProperty("username")]
        public string Username
        {
            get
            {
                return this["username"] as string;
            }
        }

        /// <summary>
        /// Gets the twitter account name
        /// </summary>
        [ConfigurationProperty("password")]
        public string Password
        {
            get
            {
                return this["password"] as string;
            }
        }
    }
}