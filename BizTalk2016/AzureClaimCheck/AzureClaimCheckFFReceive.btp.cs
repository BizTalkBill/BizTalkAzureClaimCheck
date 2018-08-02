namespace AzureClaimCheck
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class AzureClaimCheckFFReceive : Microsoft.BizTalk.PipelineOM.ReceivePipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>f66b9f5e-43ff-4f5f-ba46-885348ae1b4e</CategoryId>  <FriendlyName>Receive</FriendlyName>"+
"  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Decode\" minOccurs=\""+
"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4103-4cce-4536-83fa-4a5040674ad6\" />      <Component"+
"s />    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Disassemble\" "+
"minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"FirstMatch\" stageId=\"9d0e4105-4cce-4536-83fa-4a5040674ad6\" "+
"/>      <Components>        <Component>          <Name>Microsoft.BizTalk.Component.FFDasmComp,Micros"+
"oft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</"+
"Name>          <ComponentName>Flat file disassembler</ComponentName>          <Description>Streaming"+
" flat file disassembler component</Description>          <Version>1.0</Version>          <Properties"+
">            <Property Name=\"HeaderSpecName\" />            <Property Name=\"DocumentSpecName\">       "+
"       <Value xsi:type=\"xsd:string\">Microsoft.XLANGs.BaseTypes.Any, Microsoft.XLANGs.BaseTypes, Vers"+
"ion=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Value>            </Property>        "+
"    <Property Name=\"TrailerSpecName\" />            <Property Name=\"PreserveHeader\">              <Va"+
"lue xsi:type=\"xsd:boolean\">false</Value>            </Property>            <Property Name=\"ValidateD"+
"ocumentStructure\">              <Value xsi:type=\"xsd:boolean\">false</Value>            </Property>  "+
"          <Property Name=\"RecoverableInterchangeProcessing\">              <Value xsi:type=\"xsd:boole"+
"an\">false</Value>            </Property>          </Properties>          <CachedDisplayName>Flat fil"+
"e disassembler</CachedDisplayName>          <CachedIsManaged>true</CachedIsManaged>        </Compone"+
"nt>      </Components>    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" N"+
"ame=\"Validate\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410d-4cce-4536-83fa-4a5040"+
"674ad6\" />      <Components>        <Component>          <Name>Microsoft.BizTalk.Component.XmlValida"+
"tor,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856"+
"ad364e35</Name>          <ComponentName>XML validator</ComponentName>          <Description>XML vali"+
"dator component.</Description>          <Version>1.0</Version>          <Properties>            <Pro"+
"perty Name=\"DocumentSpecName\">              <Value xsi:type=\"xsd:string\" />            </Property>  "+
"          <Property Name=\"DocumentSpecTargetNamespaces\">              <Value xsi:type=\"xsd:string\" /"+
">            </Property>            <Property Name=\"HiddenProperties\">              <Value xsi:type="+
"\"xsd:string\">DocumentSpecTargetNamespaces</Value>            </Property>            <Property Name=\""+
"RecoverableInterchangeProcessing\">              <Value xsi:type=\"xsd:boolean\">false</Value>         "+
"   </Property>          </Properties>          <CachedDisplayName>XML validator</CachedDisplayName> "+
"         <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage> "+
"   <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"4\" Name=\"ResolveParty\" minOccurs=\"0\" ma"+
"xOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410e-4cce-4536-83fa-4a5040674ad6\" />      <Components>   "+
"     <Component>          <Name>Microsoft.BizTalk.Component.PartyRes,Microsoft.BizTalk.Pipeline.Comp"+
"onents, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Name>          <Component"+
"Name>Party resolution</ComponentName>          <Description>Party resolution component.</Description"+
">          <Version>1.0</Version>          <Properties>            <Property Name=\"AllowBySID\">     "+
"         <Value xsi:type=\"xsd:boolean\">true</Value>            </Property>            <Property Name"+
"=\"AllowByCertName\">              <Value xsi:type=\"xsd:boolean\">true</Value>            </Property>  "+
"        </Properties>          <CachedDisplayName>Party resolution</CachedDisplayName>          <Cac"+
"hedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage>  </Stages></D"+
"ocument>";
        
        private const string _versionDependentGuid = "6a22d12e-f750-4339-a06d-fed375be0fad";
        
        public AzureClaimCheckFFReceive()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4105-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.firstRecognized);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.FFDasmComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"HeaderSpecName\""+
" />    <Property Name=\"DocumentSpecName\">      <Value xsi:type=\"xsd:string\">Microsoft.XLANGs.BaseTyp"+
"es.Any, Microsoft.XLANGs.BaseTypes, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e3"+
"5</Value>    </Property>    <Property Name=\"TrailerSpecName\" />    <Property Name=\"PreserveHeader\"> "+
"     <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name=\"ValidateDocumentS"+
"tructure\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name=\"Recove"+
"rableInterchangeProcessing\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>  </Prop"+
"erties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
            stage = this.AddStage(new System.Guid("9d0e410d-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp1 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.XmlValidator,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp1 is IPersistPropertyBag)
            {
                string comp1XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"DocumentSpecNam"+
"e\">      <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"DocumentSpecTargetNamespa"+
"ces\">      <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"HiddenProperties\">     "+
" <Value xsi:type=\"xsd:string\">DocumentSpecTargetNamespaces</Value>    </Property>    <Property Name="+
"\"RecoverableInterchangeProcessing\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property> "+
" </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp1XmlProperties);;
                ((IPersistPropertyBag)(comp1)).Load(pb, 0);
            }
            this.AddComponent(stage, comp1);
            stage = this.AddStage(new System.Guid("9d0e410e-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp2 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.PartyRes,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp2 is IPersistPropertyBag)
            {
                string comp2XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"AllowBySID\">   "+
"   <Value xsi:type=\"xsd:boolean\">true</Value>    </Property>    <Property Name=\"AllowByCertName\">   "+
"   <Value xsi:type=\"xsd:boolean\">true</Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp2XmlProperties);;
                ((IPersistPropertyBag)(comp2)).Load(pb, 0);
            }
            this.AddComponent(stage, comp2);
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
