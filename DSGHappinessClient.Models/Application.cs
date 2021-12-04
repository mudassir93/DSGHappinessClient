using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSGHappinessClient.Models
{
    public class Application
    {
        private Application()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId">(Required) Application ID, DSG to provide to Entity during Application Registration.</param>
        /// <param name="type">(Required) Any of WEBAPP|SMARTAPP|DESKTOP</param>
        /// <param name="platform">(Conditional - Required when type is SMARTAPP) Any of IOS|ANDROID|BLACKBERRY|WINDOWS |OTHERS</param>
        /// <param name="url">(Conditional - Field is required when type is WEBAPP or SMARTAPP) Web application URL or Mobile Application Store URL.</param>
        /// <param name="note">(Optional)  Customer notes if present</param>
        /// <param name="applicationVersion">(Required) Application version</param>
        public Application(string applicationId, string type, string platform,
            string url, string note, string applicationVersion)
        {
           
            if (string.IsNullOrEmpty(applicationId))
                throw new ArgumentException("Parameter 'applicationId' is required and cannot be null or empty.", "applicationId");

            if (string.IsNullOrEmpty(type))
                throw new ArgumentException("Parameter 'type' is required and cannot be null or empty.", "type");

            if (!string.IsNullOrEmpty(type) && !IsTypeValid(type))
                throw new ArgumentException($"Parameter 'type' cannot have value '{type}'. WEBAPP,SMARTAPP or DESKTOP are the allowed values only.", "type");

            if (type == "SMARTAPP" && string.IsNullOrEmpty(platform))
                throw new ArgumentException("Parameter 'platform' is required when type is 'SMARTAPP'.", "platform");

            if (type == "SMARTAPP" && !string.IsNullOrEmpty(platform) && !IsPlatformValid(platform))
                throw new ArgumentException($"Parameter 'platform' cannot have value '{platform}'. IOS, ANDROID, BLACKBERRY, WINDOWS and OTHERS are the allowed values only.", "platform");

            if ((type == "SMARTAPP" || type == "WEBAPP") && string.IsNullOrEmpty(url))
                throw new ArgumentException("Parameter 'url' is required when type is 'SMARTAPP' OR 'WEBAPP'.", "url");

            if (string.IsNullOrEmpty(applicationVersion))
                throw new ArgumentException("Parameter 'applicationVersion' is required and cannot be null or empty.", "applicationVersion");

            ApplicationId = applicationId;
            Type = type;
            Platform = platform;
            Url = url;
            Notes = note;
            ApplicationVersion = applicationVersion;

        }

        #region Properties


        /// <summary>
        /// Application ID, DSG to provide to Entity during Application Registration.
        /// (Required)
        /// </summary>
        public string ApplicationId { get; private set; }


        /// <summary>
        ///  Any of WEBAPP|SMARTAPP|DESKTOP
        ///  (Required)
        /// </summary>
        public string Type { get; private set; }


        /// <summary>
        /// Any of IOS|ANDROID|BLACKBERRY|WINDOWS |OTHERS
        /// Conditional - Filed Required when type is SMARTAPP
        /// </summary>
        public string Platform { get; private set; }

        /// <summary>
        /// Web application URL or Mobile Application Store URL.
        ///Field is required when type is WEBAPP or SMARTAPP
        ///Conditional - *Field is required when type is WEBAPP or SMARTAPP
        /// </summary>
        public string Url { get; private set; }


        /// <summary>
        /// Customer notes if present
        /// Optional
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// Application version
        /// Required
        /// </summary>
        public string ApplicationVersion { get; private set; }

        #endregion

        #region Methods

        public Dictionary<string, string> GetDictionary()
        {
            return new Dictionary<string, string>
            {
                { "applicationID", ApplicationId },
                { "type", Type },
                { "platform", Platform},
                { "url", Url},
                { "notes", Notes},
                { "version", ApplicationVersion }
            };

        }

        private bool IsTypeValid(string type)
        {
            if (string.IsNullOrEmpty(type))
                return false;

            if (type != "WEBAPP" && type != "SMARTAPP" && type != "DESKTOP")
                return false;

            return true;
        }

        private bool IsPlatformValid(string platform)
        {
            if (string.IsNullOrEmpty(platform))
                return false;

            if (platform != "IOS" && platform != "ANDROID"
                && platform != "BLACKBERRY" && platform != "WINDOWS"
                && platform != "OTHERS")
                return false;

            return true;
        }


        /// <summary>
        /// Return object in JSON Format
        /// </summary>
        /// <returns>(string) JSON Formatted string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion

    }
}
