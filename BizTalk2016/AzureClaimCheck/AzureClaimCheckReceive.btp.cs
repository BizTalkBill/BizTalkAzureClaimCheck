namespace AzureClaimCheck
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class AzureClaimCheckReceive : Microsoft.BizTalk.PipelineOM.ReceivePipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>f66b9f5e-43ff-4f5f-ba46-885348ae1b4e</CategoryId>  <FriendlyName>Receive</FriendlyName>"+
"  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Decode\" minOccurs=\""+
"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4103-4cce-4536-83fa-4a5040674ad6\" />      <Component"+
"s>        <Component>          <Name>BizTalkBill.AzureClaimCheckPipelineComponent,AzureClaimCheckPip"+
"elineComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=84e46c92401ee8dd</Name>          <C"+
"omponentName>AzureClaimCheckPipelineComponent</ComponentName>          <Description>Azure Claim Chec"+
"k Pipeline Component</Description>          <Version>1.0</Version>          <Properties>            "+
"<Property Name=\"Enabled\">              <Value xsi:type=\"xsd:boolean\">true</Value>            </Prope"+
"rty>            <Property Name=\"ClientId\" />            <Property Name=\"MessageTypeId\" />           "+
" <Property Name=\"StorageAccountName\" />            <Property Name=\"StorageAccountKey\" />            "+
"<Property Name=\"KeyVaultClientId\" />            <Property Name=\"KeyVaultClientSecret\" />            "+
"<Property Name=\"KeyVaultSecretSufix\" />            <Property Name=\"StorageOutboundContainer\" />     "+
"       <Property Name=\"StorageOutboundFileName\" />          </Properties>          <CachedDisplayNam"+
"e>AzureClaimCheckPipelineComponent</CachedDisplayName>          <CachedIsManaged>true</CachedIsManag"+
"ed>        </Component>      </Components>    </Stage>    <Stage>      <PolicyFileStage _locAttrData"+
"=\"Name\" _locID=\"2\" Name=\"Disassemble\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"FirstMatch\" stageId=\""+
"9d0e4105-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>    <Stage>      <PolicyFile"+
"Stage _locAttrData=\"Name\" _locID=\"3\" Name=\"Validate\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" s"+
"tageId=\"9d0e410d-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>    <Stage>      <Po"+
"licyFileStage _locAttrData=\"Name\" _locID=\"4\" Name=\"ResolveParty\" minOccurs=\"0\" maxOccurs=\"-1\" execMe"+
"thod=\"All\" stageId=\"9d0e410e-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>  </Stag"+
"es></Document>";
        
        private const string _versionDependentGuid = "fcae2efd-35d5-45c8-99d0-563392f2df87";
        
        public AzureClaimCheckReceive()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4103-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
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
