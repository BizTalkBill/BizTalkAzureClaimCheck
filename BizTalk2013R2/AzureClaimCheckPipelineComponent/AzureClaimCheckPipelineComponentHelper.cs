using Microsoft.Azure.KeyVault;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BizTalkBill
{
    public class AzureClaimCheckPipelineComponentHelper
    {
        public static void ParseInboundBody(string body, ref string fullURL, ref string relativeURL)
        {
            bool bFound = false;

            if (IsValidJson(body))
            {
                bFound = true;
                if (body.Contains("cloudEventsVersion"))
                {
                    // CloudEvents
                    CloudEventsStorageEvent storageEvent = null;
                    try
                    {
                            storageEvent = JsonConvert.DeserializeObject<CloudEventsStorageEvent>(body);
                            fullURL = storageEvent.data.url;
                    }
                    catch (Exception Ex1)
                    {
                        throw new ApplicationException(string.Format("Storage CloudEvents Deserialization Failed - body = '{0}'", body), Ex1);
                    }
                }
                else
                {
                    if (body.Contains("topic"))
                    {
                        // EventGrid
                        EventGridStorageEvent storageEvent = null;
                        try
                        {
                            if ((body.StartsWith("[") && body.EndsWith("]"))) //For array
                            {
                                List<EventGridStorageEvent> storageEventList = JsonConvert.DeserializeObject<List<EventGridStorageEvent>>(body);
                                if (storageEventList.Count == 1)
                                {
                                    fullURL = storageEventList[0].data.url;
                                    storageEvent = storageEventList[0];
                                }
                                else
                                {
                                    throw new ApplicationException(string.Format("Storage EventGrid Array Deserialization Failed - body = '{0}'", body));
                                }
                            }
                            else
                            {
                                storageEvent = JsonConvert.DeserializeObject<EventGridStorageEvent>(body);
                                fullURL = storageEvent.data.url;
                            }
                        }
                        catch (Exception Ex1)
                        {
                            throw new ApplicationException(string.Format("Storage EventGrid Deserialization Failed - body = '{0}'", body), Ex1);
                        }
                    }
                }
                // other JSON Payload types here
            }
            else
            {
                if (IsValidXML(body))
                {
                    bFound = true;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(body);
                    // find field in schema
                }
            }
            if (!bFound)
            {
                // service bus message contains text, check if full or relative
                Uri tempURI;
                if (Uri.TryCreate(body, UriKind.Absolute, out tempURI))
                {
                    fullURL = tempURI.AbsoluteUri;
                }
                else
                {
                    relativeURL = body;
                }
            }

            if ((string.IsNullOrEmpty(relativeURL)) && (string.IsNullOrEmpty(fullURL)))
                throw new ApplicationException(string.Format("url not found - body = '{0}'", body));
        }

        private static bool IsValidJson(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            var value = stringValue.Trim();

            if ((value.StartsWith("{") && value.EndsWith("}")) || //For object
                (value.StartsWith("[") && value.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(value);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }

            return false;
        }

        private static bool IsValidXML(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return false;
            }

            var value = stringValue.Trim();

            if ((value.StartsWith("<") && value.EndsWith(">")))
            {
                try
                {
                    XDocument.Parse(value);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public static async Task<string> GetKeyVaultSecret(string KeyVaultURL,string KeyVaultClientId, string KeyVaultClientSecret, string keyVaultSecret)
        {
            KeyVaultClient keyClient = new KeyVaultClient(async (authority, resource, scope) =>
            {
                var adCredential = new ClientCredential(KeyVaultClientId, KeyVaultClientSecret);
                var authenticationContext = new AuthenticationContext(authority, null);
                return (await authenticationContext.AcquireTokenAsync(resource, adCredential)).AccessToken;
            });

            //var secret = await keyClient.GetSecretAsync("https://biztalktoazurepoc.vault.azure.net/" + "secrets/" + keyVaultSecret);
            var secret = await keyClient.GetSecretAsync(KeyVaultURL.EndsWith("/")?KeyVaultURL:KeyVaultURL+"/" + "secrets/" + keyVaultSecret);

            return secret.Value;
        }

        public static string GetContextProperty(IBaseMessageContext messageContext, string propertyName, string propertyNamespace)
        {
            string result = "";

            object contextProperty = messageContext.Read(propertyName, propertyNamespace);
            if (contextProperty != null)
            {
                return (string)contextProperty;
            }

            return result;
        }

        public static string ExpandFileName(IBaseMessageContext messageContext, string messageId, string inFileName)
        {
            string outFileName = inFileName;

            bool bUpdateOutFileName = false;
            if (outFileName.Contains("%"))
            {
                if (outFileName.Contains("%SourceFileName%"))
                {
                    string sourceFileName = GetContextProperty(messageContext, "ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties");
                    if (!string.IsNullOrWhiteSpace(sourceFileName))
                    {
                        outFileName = outFileName.Replace("%SourceFileName%", sourceFileName);
                        bUpdateOutFileName = true;
                    }
                }

                // need to expand macros
                if (outFileName.Contains("%MessageID%"))
                {
                    outFileName = outFileName.Replace("%MessageID%", messageId.ToUpper());
                    bUpdateOutFileName = true;
                }

                if (outFileName.Contains("%datetime_bts2000%"))
                {
                    string tempDate = DateTime.UtcNow.ToString("yyyyMMddHHmmssf");
                    outFileName = outFileName.Replace("%datetime_bts2000%", tempDate);
                    bUpdateOutFileName = true;
                }

                if (outFileName.Contains("%datetime%"))
                {
                    string tempDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHHmmss");
                    outFileName = outFileName.Replace("%datetime%", tempDate);
                    bUpdateOutFileName = true;
                }

                if (outFileName.Contains("%datetime.tz%"))
                {
                    string tempDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHHmmsszzz");
                    outFileName = outFileName.Replace("%datetime.tz%", tempDate);
                    bUpdateOutFileName = true;
                }

                if (outFileName.Contains("%time%"))
                {
                    string tempDate = DateTime.UtcNow.ToString("HHmmss");
                    outFileName = outFileName.Replace("%time%", tempDate);
                    bUpdateOutFileName = true;
                }

                if (outFileName.Contains("%time.tz%"))
                {
                    string tempDate = DateTime.UtcNow.ToString("HHmmsszzz");
                    outFileName = outFileName.Replace("%time.tz%", tempDate);
                    bUpdateOutFileName = true;
                }

                if (bUpdateOutFileName)
                {
                    // update context property
                    messageContext.Write("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties", outFileName);
                }
            }

            return outFileName;
        }

    }
}
