# <img src="https://ilmasoft.visualstudio.com/b3fbc85c-534c-4b82-8453-97ecc553d385/_apis/git/repositories/01a03d1b-365f-4a4d-bad8-113d1a1e9bdf/items?path=%2FCIQ.Client%2Ficon.png&versionDescriptor%5BversionOptions%5D=0&versionDescriptor%5BversionType%5D=0&versionDescriptor%5Bversion%5D=master&resolveLfs=true&%24format=octetStream&api-version=5.0" width="71" height="71"/> CIQ.Client

DSGHappinessClient.Utils is a .Net Standard package which contains Util class.Util class contains some helper methods.

## Supported Platforms

* NET Standard 2.0

## Setup

To use, simply install nuget DSGHappinessClient.Utils nuget package into your project. 

###### Class

Utils

## Methods

// Return URL encoded string
- static string GetEncodedString(string str)

// Return Current UTC timestamp in required format
- static string GetCurrentUtcTimeStamp()

// Convert Dictionary to JSON string
- static string GetJsonString(Dictionary(string,string) dictionary)

// Return 16 character random string
- static string GetRandomString()

// Return SHA 512 hashed string
- static string GetSHA512(string str)


## Usage

var sha512 = Utils.GetSHA512("HelloWorld!");

## Exceptions

ArgumentException is implemented for all the required and conditional parameters for each class

## Dependencies:

* Newtonsoft.Json 

## License
[MIT](https://licenses.nuget.org/MIT)
