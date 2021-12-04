# <img src="https://ilmasoft.visualstudio.com/b3fbc85c-534c-4b82-8453-97ecc553d385/_apis/git/repositories/01a03d1b-365f-4a4d-bad8-113d1a1e9bdf/items?path=%2FCIQ.Client%2Ficon.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=master&resolveLfs=true&%24format=octetStream&api-version=5.0" width="71" height="71"/> CIQ.Client

DSGHappinessClient.Models is a .Net Standard package which contains Model Classes for DSG Happiness Client

## Supported Platforms

* NET Standard 2.0

## Setup

To use, simply install nuget DSGHappinessClient.Models nuget package into your project. 

###### Models

- Application

- Header

- Transaction

- User

- VotingRequest

### Common Method

Dictionary(string,string) GetDictionary();
 

## Usage

Initialize VotingRequest Class and pass all the paramters in it

var request = new VotingRequest(
                  new User("", "", "", ""),
                  new Header(Utils.GetCurrentTimeStamp(),"", "", "", "", RequestType.RequestTransactionWithoutMicroApp),
                  new Application("", "", "", "", "", ""),
                  new Transaction("", "", "", "", "")
                );

## Exceptions

ArgumentException is implemented for all the required and conditional parameters for each class

## Dependencies:

* Newtonsoft.Json 

## License
[MIT](https://licenses.nuget.org/MIT)
