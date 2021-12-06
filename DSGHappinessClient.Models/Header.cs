using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSGHappinessClient.Models
{
    public class Header
    {
        private Header()
        {
        }


        /// <summary>
        /// Initialize Header Object with required parameters
        /// </summary>
        /// <param name="timestamp">(Required) Set UTC timestamp with format : dd/MM/yyyy HH:mm:ss</param>
        /// <param name="serviceProvider">(Required) Set service provider e.g: DSG</param>
        /// <param name="microApp">(Optional) Set the service name</param>
        /// <param name="microAppDisplay">(Optional) Set the service name for display only. English or Arabic according to user language</param>
        /// <param name="themeColor">(Optional) Modify the theme color. Both hex and color values are acceptable e.g: red or #FFFFFF</param>
        /// <param name="requestType">(Optional) Select the request type from one of the defined enum</param>
        public Header(string timestamp, string serviceProvider,
            string microApp, string microAppDisplay, string themeColor,
            RequestType requestType)
        {

            if(string.IsNullOrEmpty(timestamp))
                throw new ArgumentException("Parameter 'timestamp' is required and cannot be null or empty.", "timestamp");

            if(string.IsNullOrEmpty(serviceProvider))
                throw new ArgumentException("Parameter 'serviceProvider' is required and cannot be null or empty.", "serviceProvider");


            TimeStamp = timestamp;
            ServiceProvider = serviceProvider;
            MicroApp = microApp;
            MicroAppDisplay = microAppDisplay;
            ThemeColor = themeColor;
            RType = requestType;
        }


        #region Properties

        /// <summary>
        /// Set UTC timestamp with format : dd/MM/yyyy HH:mm:ss
        /// Required
        /// </summary>
        public string TimeStamp { get; private set; }

        /// <summary>
        /// Set service provider e.g: DSG
        /// Required
        /// </summary>
        public string ServiceProvider { get; private set; }

        /// <summary>
        /// Set the service name
        /// Optional 
        /// </summary>
        public string MicroApp { get; private set; }

        /// <summary>
        /// Set the service name for display only. English or Arabic according to user language
        /// Optional
        /// </summary>
        public string MicroAppDisplay { get; private set; }

        /// <summary>
        /// Modify the theme color. Both hex and color values are acceptable e.g: red or #FFFFFF
        /// Optional
        /// </summary>
        public string ThemeColor { get; private set; }

        /// <summary>
        /// Select the request type from one of the defined enum
        /// Optional
        /// </summary>
        public RequestType RType { get; private set; }

        #endregion

        #region Methods

        public Dictionary<string, string> GetDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "timestamp", TimeStamp },
                { "serviceProvider", ServiceProvider },
                { "themeColor", ThemeColor}
            };

            switch (RType)
            {
                case RequestType.RequestAppWithoutMicroApp:
                    {
                        dictionary.Add("microApp", string.Empty);
                        dictionary.Add("microAppDisplay", string.Empty);

                        break;
                    }

                case RequestType.RequestTransactionWithoutMicroApp:
                    {
                        dictionary.Add("microApp", string.Empty);
                        dictionary.Add("microAppDisplay", string.Empty);

                        break;
                    }

                case RequestType.RequestAppWithMicroApp:
                    {
                        dictionary.Add("microApp", MicroApp);
                        dictionary.Add("microAppDisplay", MicroAppDisplay);

                        break;
                    }
                default:
                    break;


            }



            return dictionary;

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

    public enum RequestType
    {
        RequestTypeNone,
        RequestAppWithMicroApp,
        RequestAppWithoutMicroApp,
        RequestTransactionWithoutMicroApp
    }
}
