//---------------------------------------------------------------------
// File: AzureClaimCheckPipelineComponent.cs
// 
//---------------------------------------------------------------------

namespace BizTalkBill
{
    using System;
    using System.Resources;
    using System.Drawing;
    using System.Collections;
    using System.Reflection;
    using System.ComponentModel;
    using System.Text;
    using System.IO;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;


    /// <summary>
    /// Implements custom pipeline component for Azure Claim Check Pattern.
    /// </summary>
    /// <remarks>
    /// AzureClaimCheckPipelineComponent class implements pipeline component that can be used in receive and
    /// send BizTalk pipelines. The pipeline component implements the Azure Claim Check Pattern.
    ///</remarks>
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    [ComponentCategory(CategoryTypes.CATID_Encoder)]
    [System.Runtime.InteropServices.Guid("86358C6B-C8E4-4318-B242-5F4DD2C426A3")]
    public class AzureClaimCheckPipelineComponent :
    BaseCustomTypeDescriptor,
        IBaseComponent,
        Microsoft.BizTalk.Component.Interop.IComponent,
        Microsoft.BizTalk.Component.Interop.IPersistPropertyBag,
        IComponentUI
    {

        private bool _Enabled;
        private string _ClientId;
        private string _MessageTypeId;
        private string _StorageAccountName;
        private string _StorageAccountKey;
        private string _StorageOutboundContainer;
        private string _StorageOutboundFileName;
        private string _KeyVaultClientId;
        private string _KeyVaultClientSecret;
        private string _KeyVaultSecretSufix;

        static ResourceManager resManager = new ResourceManager("BizTalkBill.AzureClaimCheckPipelineComponent", Assembly.GetExecutingAssembly());

        /// <summary>
        /// Constructor initializes base class to allow custom names and description for component properies
        /// </summary>
        public AzureClaimCheckPipelineComponent() :
            base(resManager)
        {
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropEnabled"),
        AzureClaimCheckPipelineComponentDescription("DescrEnabled")
        ]
        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropClientId"),
        AzureClaimCheckPipelineComponentDescription("DescrClientId")
        ]
        public string ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropMessageTypeId"),
        AzureClaimCheckPipelineComponentDescription("DescrMessageTypeId")
        ]
        public string MessageTypeId
        {
            get { return _MessageTypeId; }
            set { _MessageTypeId = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropStorageAccountName"),
        AzureClaimCheckPipelineComponentDescription("DescrStorageAccountName")
        ]
        public string StorageAccountName
        {
            get { return _StorageAccountName; }
            set { _StorageAccountName = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropStorageAccountKey"),
        AzureClaimCheckPipelineComponentDescription("DescrStorageAccountKey")
        ]
        public string StorageAccountKey
        {
            get { return _StorageAccountKey; }
            set { _StorageAccountKey = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropStorageOutboundContainer"),
        AzureClaimCheckPipelineComponentDescription("DescrStorageOutboundContainer")
        ]
        public string StorageOutboundContainer
        {
            get { return _StorageOutboundContainer; }
            set { _StorageOutboundContainer = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropStorageOutboundFileName"),
        AzureClaimCheckPipelineComponentDescription("DescrStorageOutboundFileName")
        ]
        public string StorageOutboundFileName
        {
            get { return _StorageOutboundFileName; }
            set { _StorageOutboundFileName = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropKeyVaultClientId"),
        AzureClaimCheckPipelineComponentDescription("DescrKeyVaultClientId")
        ]
        public string KeyVaultClientId
        {
            get { return _KeyVaultClientId; }
            set { _KeyVaultClientId = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropKeyVaultClientSecret"),
        AzureClaimCheckPipelineComponentDescription("DescrKeyVaultClientSecret")
        ]
        public string KeyVaultClientSecret
        {
            get { return _KeyVaultClientSecret; }
            set { _KeyVaultClientSecret = value; }
        }

        [
        AzureClaimCheckPipelineComponentPropertyName("PropKeyVaultSecretSufix"),
        AzureClaimCheckPipelineComponentDescription("DescrKeyVaultSecretSufix")
        ]
        public string KeyVaultSecretSufix
        {
            get { return _KeyVaultSecretSufix; }
            set { _KeyVaultSecretSufix = value; }
        }

        #region IBaseComponent

        /// <summary>
        /// Name of the component.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get { return "AzureClaimCheckPipelineComponent"; }
        }

        /// <summary>
        /// Version of the component.
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get { return "1.0"; }
        }

        /// <summary>
        /// Description of the component.
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get { return "Azure Claim Check Pipeline Component"; }
        }

        #endregion

        #region IComponent

        /// <summary>
        /// Implements IComponent.Execute method.
        /// </summary>
        /// <param name="pc">Pipeline context</param>
        /// <param name="inmsg">Input message.</param>
        /// <returns>Processed input message with appended or prepended data.</returns>
        /// <remarks>
        /// IComponent.Execute method is used to initiate
        /// the processing of the message in pipeline component.
        /// </remarks>
        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            if (Enabled == false)
            {
                return pInMsg;
            }

            if (null == pContext)
                throw new ArgumentNullException("PC is null");
            if (null == pInMsg)
                throw new ArgumentNullException("pInMsg is null");

            IBaseMessageContext messageContext = pInMsg.Context;

            if (pInMsg.BodyPart == null)
            {
                return pInMsg;
            }
            IBaseMessagePart bodyPart = pInMsg.BodyPart;


            // send or receive 
            string pipelineType = "";
            switch (pContext.StageID.ToString())
            {
                case CategoryTypes.CATID_Decoder: // should only be here on receive
                case CategoryTypes.CATID_DisassemblingParser:
                case CategoryTypes.CATID_Validate:
                case CategoryTypes.CATID_PartyResolver:
                    pipelineType = "Receive";
                    break;
                case CategoryTypes.CATID_Encoder: // should only be here on send
                case CategoryTypes.CATID_Transmitter:
                case CategoryTypes.CATID_AssemblingSerializer:
                    pipelineType = "Send";
                    break;
                default:
                    pipelineType = "Unknown Pipeline Stage - " + pContext.StageID.ToString();
                    break;
            }

            if (pipelineType.StartsWith("Unknown"))
            {
                throw new ApplicationException(pipelineType);
            }

            if (pipelineType == "Receive")
            {
                // do Receive
                string relativeURI = "";
                string fullURI = "";

                Stream originalStrm = bodyPart.GetOriginalDataStream();

                if (originalStrm != null)
                {
                    StreamReader sr = new StreamReader(originalStrm);
                    string body = sr.ReadToEnd();

                    AzureClaimCheckPipelineComponentHelper.ParseInboundBody(body, ref fullURI, ref relativeURI);

                    string _storageAccount = "";
                    // if it is relative URI, storage account name must be in pipeline configuraion
                    if (!string.IsNullOrEmpty(relativeURI))
                    {
                        if (!string.IsNullOrEmpty(StorageAccountName))
                        {
                            _storageAccount = StorageAccountName;
                        }
                        else
                        {
                            throw new ApplicationException(string.Format("StorageAccountName not found, required with RelativeURI"));
                        }
                    }

                    // if fullURI then storage account name can be derived
                    if (!string.IsNullOrEmpty(fullURI))
                    {
                        Uri blobLocation = new Uri(fullURI);
                        string hostURI = blobLocation.Host;
                        if (!string.IsNullOrEmpty(StorageAccountName))
                        {
                            _storageAccount = hostURI.Substring(0, hostURI.IndexOf("."));
                        }
                        relativeURI = blobLocation.PathAndQuery;
                    }

                    // get SB Properties in not specified in pipeline configuration
                    if (string.IsNullOrEmpty(ClientId))
                    {
                        ClientId = AzureClaimCheckPipelineComponentHelper.GetContextProperty(messageContext, "ClientId", "https://AzureClaimCheck.AzureClaimCheckSBProperties");
                    }
                    if (string.IsNullOrEmpty(MessageTypeId))
                    {
                        MessageTypeId = AzureClaimCheckPipelineComponentHelper.GetContextProperty(messageContext, "MessageTypeId", "https://AzureClaimCheck.AzureClaimCheckSBProperties");
                    }

                    // get ClientId & MessageTypeId from relativeURI in not found in SB Properties or in pipeline configuration
                    // relativeURI should be /ClientId/MessageTypeId/filename
                    string tempRelativeURI = relativeURI;
                    if (string.IsNullOrEmpty(MessageTypeId))
                    {
                        try
                        {
                            tempRelativeURI = tempRelativeURI.Substring(0, tempRelativeURI.LastIndexOf('/'));
                            MessageTypeId = tempRelativeURI.Substring(tempRelativeURI.LastIndexOf('/') + 1);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (string.IsNullOrEmpty(ClientId))
                    {
                        try
                        {
                            tempRelativeURI = tempRelativeURI.Substring(0, tempRelativeURI.LastIndexOf('/'));
                            ClientId = tempRelativeURI.Substring(tempRelativeURI.LastIndexOf('/') + 1);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    bool bHaveStorageKey = false;
                    if (!string.IsNullOrEmpty(StorageAccountKey))
                        bHaveStorageKey = true;

                    // check key vault properties
                    if (!bHaveStorageKey)
                    {
                        if (!string.IsNullOrEmpty(KeyVaultClientId))
                        {
                            if (!string.IsNullOrEmpty(KeyVaultClientSecret))
                            {
                                string keyVaultSecret = string.IsNullOrEmpty(ClientId) ? "" : ClientId;
                                keyVaultSecret += string.IsNullOrEmpty(MessageTypeId) ? "" : MessageTypeId;
                                keyVaultSecret += string.IsNullOrEmpty(_KeyVaultSecretSufix) ? "" : _KeyVaultSecretSufix;

                                string StorageAccountKeyTemp = AzureClaimCheckPipelineComponentHelper.GetKeyVaultSecret(KeyVaultClientId, KeyVaultClientSecret, keyVaultSecret).GetAwaiter().GetResult();
                                StorageAccountKey = StorageAccountKeyTemp;
                            }
                        }
                    }

                    // find the container, reletive filename & filename
                    string container = "";
                    string inFileNameRelative = "";
                    string inFileName = "";

                    tempRelativeURI = relativeURI;
                    if (tempRelativeURI.StartsWith("/"))
                        tempRelativeURI = tempRelativeURI.Substring(1);
                    container = tempRelativeURI.Substring(0, tempRelativeURI.IndexOf("/"));
                    inFileNameRelative = tempRelativeURI.Substring(tempRelativeURI.IndexOf("/") + 1);
                    inFileName = inFileNameRelative.Substring(inFileNameRelative.LastIndexOf("/") + 1);

                    // check for storage key
                    if (!bHaveStorageKey)
                    {
                        if (string.IsNullOrEmpty(StorageAccountName))
                            throw new ApplicationException(string.Format("StorageAccountName not found"));
                        if (string.IsNullOrEmpty(StorageAccountKey))
                            throw new ApplicationException(string.Format("StorageAccountKey not found"));
                    }

                    // connect to storage account
                    StorageCredentials creds = new StorageCredentials(_storageAccount, StorageAccountKey);
                    CloudStorageAccount storAccount = new CloudStorageAccount(creds, true);
                    CloudBlobClient blobClient = storAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);
                    CloudBlob blob = blobContainer.GetBlobReference(inFileNameRelative);

                    MemoryStream strm = new MemoryStream();

                    blob.DownloadToStream(strm);
                    strm.Seek(0, SeekOrigin.Begin);

                    // set context properties
                    messageContext.Write("EventGridSubscriptionResponse", "https://AzureClaimCheck.AzureClaimCheckProperties", "False");
                    messageContext.Write("OriginalStoragePath", "https://AzureClaimCheck.AzureClaimCheckProperties", string.IsNullOrEmpty(fullURI) ? relativeURI : fullURI);
                    messageContext.Write("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties", inFileName);

                    messageContext.Write("ClientId", "https://AzureClaimCheck.AzureClaimCheckSBProperties", ClientId);
                    messageContext.Write("MessageTypeId", "https://AzureClaimCheck.AzureClaimCheckSBProperties", MessageTypeId);

                    bodyPart.Data = strm;
                    pContext.ResourceTracker.AddResource(strm);
                }
            }
            else
            {
                // do Send

                // prepare outbound file name
                string outFileName = AzureClaimCheckPipelineComponentHelper.ExpandFileName(messageContext, pInMsg.MessageID.ToString(), StorageOutboundFileName);

                bool bHaveStorageKey = false;
                if (!string.IsNullOrEmpty(StorageAccountKey))
                    bHaveStorageKey = true;

                // check key vault properties
                if (!bHaveStorageKey)
                {
                    if (!string.IsNullOrEmpty(KeyVaultClientId))
                    {
                        if (!string.IsNullOrEmpty(KeyVaultClientSecret))
                        {
                            string keyVaultSecret = string.IsNullOrEmpty(ClientId) ? "" : ClientId;
                            keyVaultSecret += string.IsNullOrEmpty(MessageTypeId) ? "" : MessageTypeId;
                            keyVaultSecret += string.IsNullOrEmpty(_KeyVaultSecretSufix) ? "" : _KeyVaultSecretSufix;

                            string StorageAccountKeyTemp = AzureClaimCheckPipelineComponentHelper.GetKeyVaultSecret(KeyVaultClientId, KeyVaultClientSecret, keyVaultSecret).GetAwaiter().GetResult();
                            StorageAccountKey = StorageAccountKeyTemp;
                        }
                    }
                }

                // check for storage key
                if (!bHaveStorageKey)
                {
                    if (string.IsNullOrEmpty(StorageAccountName))
                        throw new ApplicationException(string.Format("StorageAccountName not found"));
                    if (string.IsNullOrEmpty(StorageAccountKey))
                        throw new ApplicationException(string.Format("StorageAccountKey not found"));
                }

                string outFileNameRelative = string.Format("{0}/{1}/{2}", ClientId, MessageTypeId, outFileName);

                // connect to storage account
                StorageCredentials creds = new StorageCredentials(StorageAccountName, StorageAccountKey);
                CloudStorageAccount storAccount = new CloudStorageAccount(creds, true);
                CloudBlobClient blobClient = storAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(StorageOutboundContainer);
                blobContainer.CreateIfNotExists();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(outFileNameRelative);

                blob.UploadFromStream(bodyPart.GetOriginalDataStream());

                string fullFileName = blob.Uri.AbsolutePath;

                // create service bus message body
                MemoryStream strm = new MemoryStream(Encoding.UTF8.GetBytes(fullFileName));
                strm.Seek(0, SeekOrigin.Begin);
                bodyPart.Data = strm;
                pContext.ResourceTracker.AddResource(strm);

                // set context properties for SB message
                if (!string.IsNullOrEmpty(ClientId))
                {
                    messageContext.Write("ClientId", "https://AzureClaimCheck.AzureClaimCheckSBProperties", ClientId);
                }
                if (!string.IsNullOrEmpty(MessageTypeId))
                {
                    messageContext.Write("MessageTypeId", "https://AzureClaimCheck.AzureClaimCheckSBProperties", MessageTypeId);
                }
            }

            return pInMsg;
        }


        #endregion

        #region IPersistPropertyBag

        /// <summary>
        /// Gets class ID of component for usage from unmanaged code.
        /// </summary>
        /// <param name="classid">Class ID of the component.</param>
        public void GetClassID(out Guid classid)
        {
            classid = new System.Guid("86358C6B-C8E4-4318-B242-5F4DD2C426A3");
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        public void InitNew()
        {
        }

        /// <summary>
        /// Loads configuration property for component.
        /// </summary>
        /// <param name="pb">Configuration property bag.</param>
        /// <param name="errlog">Error status (not used in this code).</param>
        public void Load(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, Int32 errlog)
        {
            object val = null;
            val = ReadPropertyBag(propertyBag, "Enabled");
            if ((val != null))
            {
                this._Enabled = ((bool)(val));
            }
            val = ReadPropertyBag(propertyBag, "ClientId");
            if ((val != null))
            {
                this._ClientId = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "MessageTypeId");
            if ((val != null))
            {
                this._MessageTypeId = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "StorageAccountName");
            if ((val != null))
            {
                this._StorageAccountName = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "StorageAccountKey");
            if ((val != null))
            {
                this._StorageAccountKey = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "KeyVaultClientId");
            if ((val != null))
            {
                this._KeyVaultClientId = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "KeyVaultClientSecret");
            if ((val != null))
            {
                this._KeyVaultClientSecret = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "KeyVaultSecretSufix");
            if ((val != null))
            {
                this._KeyVaultSecretSufix = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "StorageOutboundContainer");
            if ((val != null))
            {
                this._StorageOutboundContainer = ((string)(val));
            }
            val = ReadPropertyBag(propertyBag, "StorageOutboundFileName");
            if ((val != null))
            {
                this._StorageOutboundFileName = ((string)(val));
            }

        }

        /// <summary>
        /// Saves the current component configuration into the property bag.
        /// </summary>
        /// <param name="pb">Configuration property bag.</param>
        /// <param name="fClearDirty">Not used.</param>
        /// <param name="fSaveAllProperties">Not used.</param>
        public void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, Boolean fClearDirty, Boolean fSaveAllProperties)
        {
            WritePropertyBag(propertyBag, "Enabled", this.Enabled);
            WritePropertyBag(propertyBag, "ClientId", this.ClientId);
            WritePropertyBag(propertyBag, "MessageTypeId", this.MessageTypeId);
            WritePropertyBag(propertyBag, "StorageAccountName", this.StorageAccountName);
            WritePropertyBag(propertyBag, "StorageAccountKey", this.StorageAccountKey);
            WritePropertyBag(propertyBag, "KeyVaultClientId", this.KeyVaultClientId);
            WritePropertyBag(propertyBag, "KeyVaultClientSecret", this.KeyVaultClientSecret);
            WritePropertyBag(propertyBag, "KeyVaultSecretSufix", this.KeyVaultSecretSufix);
            WritePropertyBag(propertyBag, "StorageOutboundContainer", this.StorageOutboundContainer);
            WritePropertyBag(propertyBag, "StorageOutboundFileName", this.StorageOutboundFileName);
        }

        /// <summary>
        /// Reads property value from property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <returns>Value of the property.</returns>
        private static object ReadPropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName)
        {
            object val = null;
            try
            {
                pb.Read(propName, out val, 0);
            }

            catch (ArgumentException)
            {
                return val;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return val;
        }

        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private static void WritePropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName, object val)
        {
            try
            {
                pb.Write(propName, ref val);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        #endregion

        #region IComponentUI

        /// <summary>
        /// Component icon to use in BizTalk Editor.
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                return ((Bitmap)resManager.GetObject("AzureClaimCheckPipelineComponentBitmap")).GetHicon();
            }

        }

        /// <summary>
        /// The Validate method is called by the BizTalk Editor during the build 
        /// of a BizTalk project.
        /// </summary>
        /// <param name="obj">Project system.</param>
        /// <returns>
        /// A list of error and/or warning messages encounter during validation
        /// of this component.
        /// </returns>
        public IEnumerator Validate(object obj)
        {
            IEnumerator enumerator = null;
            ArrayList strList = new ArrayList();

            // Validate prepend data property
            //if ((prependData != null) &&
            //(prependData.Length >= 64))
            //{
            //    strList.Add(resManager.GetString("ErrorPrependDataTooLong"));
            //}

            // validate append data property
            //if ((appendData != null) &&
            //(appendData.Length >= 64))
            //{
            //    strList.Add(resManager.GetString("ErrorAppendDataTooLong"));
            //}

            if (strList.Count > 0)
            {
                enumerator = strList.GetEnumerator();
            }

            return enumerator;
        }

        #endregion
    }
}
