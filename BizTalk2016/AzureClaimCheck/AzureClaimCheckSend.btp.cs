namespace AzureClaimCheck
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class AzureClaimCheckSend : Microsoft.BizTalk.PipelineOM.SendPipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>8c6b051c-0ff5-4fc2-9ae5-5016cb726282</CategoryId>  <FriendlyName>Transmit</FriendlyName"+
">  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Pre-Assemble\" minO"+
"ccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4101-4cce-4536-83fa-4a5040674ad6\" />      <Co"+
"mponents />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Assemb"+
"le\" minOccurs=\"0\" maxOccurs=\"1\" execMethod=\"All\" stageId=\"9d0e4107-4cce-4536-83fa-4a5040674ad6\" />  "+
"    <Components />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name="+
"\"Encode\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4108-4cce-4536-83fa-4a5040674ad6"+
"\" />      <Components>        <Component>          <Name>BizTalkBill.AzureClaimCheckPipelineComponen"+
"t,AzureClaimCheckPipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=84e46c92401ee8d"+
"d</Name>          <ComponentName>AzureClaimCheckPipelineComponent</ComponentName>          <Descript"+
"ion>Azure Claim Check Pipeline Component</Description>          <Version>1.0</Version>          <Pro"+
"perties>            <Property Name=\"Enabled\">              <Value xsi:type=\"xsd:boolean\">true</Value"+
">            </Property>            <Property Name=\"ClientId\" />            <Property Name=\"MessageT"+
"ypeId\" />            <Property Name=\"StorageAccountName\" />            <Property Name=\"StorageAccoun"+
"tKey\" />            <Property Name=\"KeyVaultClientId\" />            <Property Name=\"KeyVaultClientSe"+
"cret\" />            <Property Name=\"KeyVaultSecretSufix\" />            <Property Name=\"StorageOutbou"+
"ndContainer\" />            <Property Name=\"StorageOutboundFileName\" />          </Properties>       "+
"   <CachedDisplayName>AzureClaimCheckPipelineComponent</CachedDisplayName>          <CachedIsManaged"+
">true</CachedIsManaged>        </Component>      </Components>    </Stage>  </Stages></Document>";
        
        private const string _versionDependentGuid = "dc0d4ae3-d9aa-4789-923b-dcc6865bc21e";
        
        public AzureClaimCheckSend()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4108-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("BizTalkBill.AzureClaimCheckPipelineComponent,AzureClaimCheckPipelineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=84e46c92401ee8dd");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"Enabled\">      "+
"<Value xsi:type=\"xsd:boolean\">true</Value>    </Property>    <Property Name=\"ClientId\" />    <Proper"+
"ty Name=\"MessageTypeId\" />    <Property Name=\"StorageAccountName\" />    <Property Name=\"StorageAccou"+
"ntKey\" />    <Property Name=\"KeyVaultClientId\" />    <Property Name=\"KeyVaultClientSecret\" />    <Pr"+
"operty Name=\"KeyVaultSecretSufix\" />    <Property Name=\"StorageOutboundContainer\" />    <Property Na"+
"me=\"StorageOutboundFileName\" />  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
