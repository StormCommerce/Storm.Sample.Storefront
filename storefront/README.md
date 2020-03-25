# Storefront

Storefront is a sample Ecommerce project, built on top of [Storm Commerce's commerce engine](https://storm.io/).
The project includes some functionality so that the basic commerce processes works.
Use this as a starting point to your own development of commerce apps. Use as example or as a starting kit.

This repository provides a library of code that is right away executable and should work without any changes. 
Read more about the project and what you can do [here](https://storm.io/docs/samplestorefront).

Even though this is a functional project out of the box, it is not tested or ready for production.

## Configuration and execution
The [appsettings.json](Storefront/appsettings.json) file contains the configuration of how to connect to Storm´s SaaS platform. Read about how to change the setup [here](https://storm.io/docs/samplestorefront).
This .net core solution can be run on a local machine (like IIS Express) or using Docker, which needs to be setup separately.

Below is a sample configuration file. The DefaultPaymentMethodId is the payment method code for Klarna Checkout V3. 

ExcludeTypeFromBAseket of 

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "Storm": {
    "ImagePrefix": "https://yourhostname.cdn.storm.io/",
    "CertFilename": "PalysetStormAPI-SE.pfx",
    "CertPassword": "4711",
    "ApiUrl": "https://servicesstage.enferno.se/api/1.1/",
    "StatusSeed": "1,2,3",
    "ExcludeTypeFromBasket": "3,9",
    "RootCategoryId": "",
    "DefaultPageSize": "20",
    "DefaultPaymentMethodId": "156",
    "BaseUrl": "https://localhost:44329"
  },
  "defaultLanguage": "sv-SE",
  "defaultCurrency": "2"
}



## License
See the [LICENSE](LICENSE.md) file for license rights and limitations (MIT).
