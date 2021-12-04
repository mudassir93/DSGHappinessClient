using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSGHappinessClient.Models
{
    public class User
    {
        private User()
        {

        }


        /// <summary>
        /// Initialize User Object with required parameters
        /// </summary>
        /// <param name="source">(Required) Any Of LOCAL|MYID|ANONYMOUS Where LOCAL to be used with Departments Local User Profile.</param>
        /// <param name="username">(Conditional) username is required when source is LOCAL</param>
        /// <param name="email">(Optional) User Email in case available</param>
        /// <param name="mobile">(Optional) User Mobile in case available</param>
        public User(string source, string username, string email,
            string mobile)
        {

            if (string.IsNullOrEmpty(source))
                throw new ArgumentException("Parameter 'source' is required and cannot be null or empty.", "source");

            if (!string.IsNullOrEmpty(source) && source == "LOCAL" && string.IsNullOrEmpty(username))
                throw new ArgumentException("Parameter 'username' is required when source is 'LOCAL'", "username");

            Source = source;
            Username = username;
            Email = email;
            Mobile = mobile;
        }

        #region Properties 

        /// <summary>
        /// Any Of LOCAL|MYID|ANONYMOUS
        /// Where LOCAL to be used with Departments Local User Profile.
        /// Required
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// Username in case available
        /// Conditional - username is required when source is LOCAL
        /// </summary>
        public string Username  { get; private set; }

        /// <summary>
        /// User Email in case available
        /// Optional
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// User Mobile in case available
        /// Format 9715X XXXXXXX
        /// Optional
        /// </summary>
        public string Mobile { get; private set; }


        #endregion

        #region Methods

        public Dictionary<string, string> GetDictionary()
        {
            return new Dictionary<string, string>
            {
                { "source", Source },
                { "username", Username },
                { "email", Email},
                { "mobile", Mobile}
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
