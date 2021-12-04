using System;
using DSGHappinessClient.Models;
using DSGHappinessClient.Utils;

namespace DSGHappiness.Client
{
    public class VotingManager
    {
        private readonly string BaseURL = "https://happinessmeter.dubai.gov.ae/";
        private readonly string BaseURLQA = "https://happinessmeterqa.dubai.gov.ae/";

        private VotingManager(string serviceProviderSecret, string clientId,
            string language, bool isQA = true)
        {
            ServiceProviderSecret = serviceProviderSecret;
            ClientId = clientId;
            Language = language;


            var baseURL = isQA ? BaseURLQA : BaseURL;

            RequestUrl =  $"{baseURL}HappinessMeter2/MobilePostDataService";

            Random = Utils.GetRandomString();

            var request = new VotingRequest(
                  new User("", "", "", ""),
                  new Header(Utils.GetCurrentTimeStamp(),"", "", "", "", RequestType.RequestTransactionWithoutMicroApp),
                  new Application("", "", "", "", "", ""),
                  new Transaction("", "", "", "", "")
                );

            var jsonPayload = Utils.GetJsonString(request.GetDictionary());

            var signatureRaw = $"{jsonPayload}|{ServiceProviderSecret}";

            string signature = Utils.GetSHA512(signatureRaw);

            string nonceRaw = $"{Random}|{request.Header.TimeStamp}|{serviceProviderSecret}";

            string nonce = Utils.GetSHA512(nonceRaw);

        }

        public string ServiceProviderSecret { get; private set; }

        public string Language { get; private set; }

        public string ClientId { get; private set; }

        public string RequestUrl { get; private set; }

        public string Random { get; private set; }

    }
}
