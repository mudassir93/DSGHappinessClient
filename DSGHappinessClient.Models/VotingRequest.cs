using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSGHappinessClient.Models
{
    public class VotingRequest
    {
        private VotingRequest()
        {
        }


        /// <summary>
        /// Initialize the VotingRequest Object with required parameters
        /// </summary>
        /// <param name="user">User class object</param>
        /// <param name="header">Header class object</param>
        /// <param name="application">Application class object</param>
        /// <param name="transaction">Transaction class object</param>
        public VotingRequest(User user, Header header, Application application,
            Transaction transaction)
        {
            User = user;
            Header = header;
            Application = application;
            Transaction = transaction;
        }

        #region Properties

        /// <summary>
        /// User Object
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Header Object
        /// </summary>
        public Header Header { get; private set; }

        /// <summary>
        /// Application Object
        /// </summary>
        public Application Application { get; private set; }

        /// <summary>
        /// Transaction Object
        /// </summary>
        public Transaction Transaction { get; private set; }

        /// <summary>
        /// Additonal Parameter Dictionary
        /// </summary>
        public Dictionary<string, string> AdditionalParameter { get; private set; }


        #endregion

        public Dictionary<string, object> GetDictionary()
        {
            var dictionary = new Dictionary<string, object>();

            switch(Header.RType)
            {
                case RequestType.RequestTransactionWithoutMicroApp:
                    {
                        dictionary.Add("header", Header.GetDictionary());
                        dictionary.Add("transaction", Transaction.GetDictionary());
                        dictionary.Add("user", User.GetDictionary());
                        break;
                    }
                case RequestType.RequestAppWithMicroApp:
                case RequestType.RequestAppWithoutMicroApp:
                    {
                        dictionary.Add("header", Header.GetDictionary());
                        dictionary.Add("application", Application.GetDictionary());
                        dictionary.Add("user", User.GetDictionary());
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
    }
}
