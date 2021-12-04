using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSGHappinessClient.Models
{
    public class Transaction
    {
        private Transaction()
        {
        }

        /// <summary>
        /// Initialize Transaction Object with required parameters
        /// </summary>
        /// <param name="transactionId">(Requird) Service Provider Unique Transaction ID</param>
        /// <param name="gessEnabled">(Required) True of False based on if the Service is registered in the GESS System</param>
        /// <param name="serviceCode">(optional) Service code (as registered in GESS System)</param>
        /// <param name="serviceDescription">(Required) Service Description</param>
        /// <param name="channel">(Required) Any of WEB|SMARTAPP|KIOSK|IVR|SMS</param>
        public Transaction(string transactionId, string gessEnabled,
            string serviceCode, string serviceDescription, string channel)
        {

            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentException("Parameter 'transactionId' is required and cannot be null or empty.", "transactionId");

            if (string.IsNullOrEmpty(gessEnabled))
                throw new ArgumentException("Parameter 'gessEnabled' is required and cannot be null or empty.", "gessEnabled");

            if (string.IsNullOrEmpty(serviceDescription))
                throw new ArgumentException("Parameter 'serviceDescription' is required and cannot be null or empty.", "serviceDescription");

            if (string.IsNullOrEmpty(channel))
                throw new ArgumentException("Parameter 'channel' is required and cannot be null or empty.", "channel");

            if (!string.IsNullOrEmpty(channel) && !IsChannelValid(channel))
                throw new ArgumentException($"Parameter 'channel' cannot have value '{channel}'. WEB, SMARTAPP, KIOSK, IVR and SMS are the allowed values only.", "channel");



            TransactionId = transactionId;
            GessEnabled = gessEnabled;
            ServiceCode = serviceCode;
            ServiceDescription = serviceDescription;
            Channel = channel;
        }


        #region Properties

        /// <summary>
        /// Service Provider Unique Transaction ID
        /// Required
        /// </summary>
        public string TransactionId { get; private set; }

        /// <summary>
        /// True of False based on if the Service is registered in the GESS System
        /// Required
        /// </summary>
        public string GessEnabled { get; private set; }


        /// <summary>
        /// Service code (as registered in GESS System)
        /// Optional
        /// </summary>
        public string ServiceCode { get; private set; }

        /// <summary>
        /// Service Description
        /// Required
        /// </summary>
        public string ServiceDescription { get; private set; }

        /// <summary>
        /// Any of WEB|SMARTAPP|KIOSK|IVR|SMS
        /// Required
        /// </summary>
        public string Channel { get; private set; }


        #endregion


        #region Methods


        private bool IsChannelValid(string channel)
        {
            if (string.IsNullOrEmpty(channel))
                return false;

            if (channel != "WEB" && channel != "SMARTAPP" && channel != "KIOSK"
                && channel != "IVR" && channel != "SMS")

                return false;

            return true;
        }

        public Dictionary<string, string> GetDictionary()
        {
            return new Dictionary<string, string>
            {
                { "transactionID", TransactionId },
                { "gessEnabled", GessEnabled },
                { "serviceCode", ServiceCode},
                { "serviceDescription", ServiceDescription},
                { "channel", Channel }
            };

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
