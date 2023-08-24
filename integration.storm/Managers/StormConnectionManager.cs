// using Integration.Storm.Exceptions;
// using Microsoft.Extensions.Configuration;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Net.Http;
// using System.Security.Authentication;
// using System.Security.Cryptography.X509Certificates;
// using System.Text;
// using System.Threading.Tasks;
//
// /******************************************************************************
//  ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
//  ** Purpose: Sample code for how to build an integration from a frontend
//  **          solution to communicate with Storm Commerce (storm.io)
//  ** Copyright (C) Jolix AB, Storm Commerce AB
//  ******************************************************************************/
//
// namespace Integration.Storm.Managers
// {
//     public class StormConnectionManager: IStormConnectionManager
//     {
//         IConfiguration _configuration;
//         private string CertFilename;
//         private string CertPassword;
//         private string StormBaseUrl;
//
//         public StormConnectionManager(IConfiguration configuration)
//         {
//             /*
//             _settingsManager = new StormSettingsManager();
//             */
//             CertFilename = configuration["Storm:CertFilename"];
//             CertPassword = configuration["Storm:CertPassword"];
//             StormBaseUrl = configuration["Storm:ApiUrl"];
//             _configuration = configuration;
//         }
//
//         public async Task<TR> GetResult<TR>(string url)
//         {
//             var handler = new HttpClientHandler();
//
//             if( !string.IsNullOrEmpty(  this.CertFilename) ) {
//                 var certFile = Path.Combine(Directory.GetCurrentDirectory(), this.CertFilename);
//                 var certificate = new X509Certificate2(File.ReadAllBytes(certFile), this.CertPassword);
//                 handler.ClientCertificateOptions = ClientCertificateOption.Manual;
//                 handler.ClientCertificates.Add(certificate);
//             }
//             handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
//
//             using (var client = new HttpClient(handler))
//             {
//                 var fullUrl = prepareUrl(url);
//                 var respone = client.GetAsync(new Uri(fullUrl)).Result;
//                 var result = respone.Content.ReadAsStringAsync();
//                 if (!respone.IsSuccessStatusCode)
//                 {
//                     if( (int)respone.StatusCode >= 400 && (int)respone.StatusCode <= 499 )
//                     {
//                         throw new BadRequestException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else if( (int)respone.StatusCode >=500 && (int)respone.StatusCode <= 599 )
//                     {
//                         throw new ServerErrorException((int)respone.StatusCode, respone.ReasonPhrase);
//                     } else
//                     {
//                         throw new Exception("Invalid request status " + (int)respone.StatusCode + ", reason=" + respone.ReasonPhrase);
//                     }
//                 }
//                 return JsonConvert.DeserializeObject<TR>(result.Result);
//             }
//         }
//
//         public TR PostResult<TR>(string url)
//         {
//             var handler = new HttpClientHandler();
//
//             if (!string.IsNullOrEmpty(this.CertFilename))
//             {
//                 var certFile = Path.Combine(Directory.GetCurrentDirectory(), this.CertFilename);
//                 var certificate = new X509Certificate2(File.ReadAllBytes(certFile), this.CertPassword);
//                 handler.ClientCertificateOptions = ClientCertificateOption.Manual;
//                 handler.ClientCertificates.Add(certificate);
//             }
//             handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
//
//             using (var client = new HttpClient(handler))
//             {
//                 var respone = client.PostAsync(new Uri(prepareUrl(url)), new StringContent(string.Empty, Encoding.UTF8, "application/json")).Result;
//                 var result = respone.Content.ReadAsStringAsync();
//                 if (!respone.IsSuccessStatusCode)
//                 {
//                     if ((int)respone.StatusCode >= 400 && (int)respone.StatusCode <= 499)
//                     {
//                         throw new BadRequestException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else if ((int)respone.StatusCode >= 500 && (int)respone.StatusCode <= 599)
//                     {
//                         throw new ServerErrorException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else
//                     {
//                         throw new Exception("Invalid request status " + (int)respone.StatusCode + ", reason=" + respone.ReasonPhrase);
//                     }
//                 }
//                 return JsonConvert.DeserializeObject<TR>(result.Result);
//             }
//         }
//
//         public TR PostResult<TR>(string url, object content)
//         {
//             var data = JsonConvert.SerializeObject(content, Newtonsoft.Json.Formatting.None,
//                     new JsonSerializerSettings
//                     {
//                         NullValueHandling = NullValueHandling.Ignore
//                     });
//
//
//             var handler = new HttpClientHandler();
//
//             if (!string.IsNullOrEmpty(this.CertFilename))
//             {
//                 var certFile = Path.Combine(Directory.GetCurrentDirectory(), this.CertFilename);
//                 var certificate = new X509Certificate2(File.ReadAllBytes(certFile), this.CertPassword);
//                 handler.ClientCertificateOptions = ClientCertificateOption.Manual;
//                 handler.ClientCertificates.Add(certificate);
//             }
//             handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
//
//             using (var client = new HttpClient(handler))
//             {
//                 var respone = client.PostAsync(new Uri(prepareUrl(url)), new StringContent(data, Encoding.UTF8, "application/json")).Result;
//                 var result = respone.Content.ReadAsStringAsync();
//                 if (!respone.IsSuccessStatusCode)
//                 {
//                     if ((int)respone.StatusCode >= 400 && (int)respone.StatusCode <= 499)
//                     {
//                         throw new BadRequestException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else if ((int)respone.StatusCode >= 500 && (int)respone.StatusCode <= 599)
//                     {
//                         throw new ServerErrorException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else
//                     {
//                         throw new Exception("Invalid request status " + (int)respone.StatusCode + ", reason=" + respone.ReasonPhrase);
//                     }
//                 }
//                 return JsonConvert.DeserializeObject<TR>(result.Result);
//             }
//         }
//
//         public TR FormPostResult<TR>(string url, Dictionary<string,string> formDictionary)
//         {
//
//             var nvc = new List<KeyValuePair<string, string>>();
//             foreach( var key in formDictionary.Keys )
//             {
//                 nvc.Add(new KeyValuePair<string, string>(key, formDictionary[key]));
//             }
//
//             var handler = new HttpClientHandler();
//
//             if (!string.IsNullOrEmpty(this.CertFilename))
//             {
//                 var certFile = Path.Combine(Directory.GetCurrentDirectory(), this.CertFilename);
//                 var certificate = new X509Certificate2(File.ReadAllBytes(certFile), this.CertPassword);
//                 handler.ClientCertificateOptions = ClientCertificateOption.Manual;
//                 handler.ClientCertificates.Add(certificate);
//             }
//             handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
//
//             using (var client = new HttpClient(handler))
//             {
//                 var respone = client.PostAsync(new Uri(prepareUrl(url)), new FormUrlEncodedContent(nvc)).Result;
//                 var result = respone.Content.ReadAsStringAsync();
//                 if (!respone.IsSuccessStatusCode)
//                 {
//                     if ((int)respone.StatusCode >= 400 && (int)respone.StatusCode <= 499)
//                     {
//                         throw new BadRequestException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else if ((int)respone.StatusCode >= 500 && (int)respone.StatusCode <= 599)
//                     {
//                         throw new ServerErrorException((int)respone.StatusCode, respone.ReasonPhrase);
//                     }
//                     else
//                     {
//                         throw new Exception("Invalid request status " + (int)respone.StatusCode + ", reason=" + respone.ReasonPhrase);
//                     }
//                 }
//                 return JsonConvert.DeserializeObject<TR>(result.Result);
//             }
//         }
//
//
//         private string prepareUrl(string url)
//         {
//             var finalUrl = url;
//             if (!url.StartsWith("http"))
//             {
//                 finalUrl = StormBaseUrl + url;
//                 if( !finalUrl.Contains("format=json")) {
//                     if (!finalUrl.Contains("?"))
//                     {
//                         finalUrl += "?format=json";
//                     }
//                     else
//                     {
//                         finalUrl += "&format=json";
//
//                     }
//                 }
//             }
//             return finalUrl;
//         }
//
//     }
// }
