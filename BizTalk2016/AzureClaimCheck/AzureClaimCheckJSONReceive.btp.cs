namespace AzureClaimCheck
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class AzureClaimCheckJSONReceive : Microsoft.BizTalk.PipelineOM.ReceivePipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>f66b9f5e-43ff-4f5f-ba46-885348ae1b4e</CategoryId>  <FriendlyName>Receive</FriendlyName>"+
"  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Decode\" minOccurs=\""+
"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4103-4cce-4536-83fa-4a5040674ad6\" />      <Component"+
"s>        <Component>          <Name>Microsoft.BizTalk.Component.JsonDecoder,Microsoft.BizTalk.Pipel"+
"ine.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Name>          <C"+
"omponentName>JSON decoder</ComponentName>          <Description>JSON decoder component</Description>"+
"          <Version>1.0</Version>          <Properties>            <Property Name=\"RootNode\" />      "+
"      <Property Name=\"RootNodeNamespace\" />          </Properties>          <CachedDisplayName>JSON "+
"decoder</CachedDisplayName>          <CachedIsManaged>true</CachedIsManaged>        </Component>    "+
"  </Components>    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Di"+
"sassemble\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"FirstMatch\" stageId=\"9d0e4105-4cce-4536-83fa-4a5"+
"040674ad6\" />      <Components>        <Component>          <Name>Microsoft.BizTalk.Component.XmlDas"+
"mComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf38"+
"56ad364e35</Name>          <ComponentName>XML disassembler</ComponentName>          <Description>Str"+
"eaming XML disassembler</Description>          <Version>1.0</Version>          <Properties>         "+
"   <Property Name=\"EnvelopeSpecNames\">              <Value xsi:type=\"xsd:string\" />            </Pro"+
"perty>            <Property Name=\"EnvelopeSpecTargetNamespaces\">              <Value xsi:type=\"xsd:s"+
"tring\" />            </Property>            <Property Name=\"DocumentSpecNames\">              <Value "+
"xsi:type=\"xsd:string\" />            </Property>            <Property Name=\"DocumentSpecTargetNamespa"+
"ces\">              <Value xsi:type=\"xsd:string\" />            </Property>            <Property Name="+
"\"AllowUnrecognizedMessage\">              <Value xsi:type=\"xsd:boolean\">false</Value>            </Pr"+
"operty>            <Property Name=\"ValidateDocument\">              <Value xsi:type=\"xsd:boolean\">fal"+
"se</Value>            </Property>            <Property Name=\"RecoverableInterchangeProcessing\">     "+
"         <Value xsi:type=\"xsd:boolean\">false</Value>            </Property>            <Property Nam"+
"e=\"HiddenProperties\">              <Value xsi:type=\"xsd:string\">EnvelopeSpecTargetNamespaces,Documen"+
"tSpecTargetNamespaces</Value>            </Property>          </Properties>          <CachedDisplayN"+
"ame>XML disassembler</CachedDisplayName>          <CachedIsManaged>true</CachedIsManaged>        </C"+
"omponent>      </Components>    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID"+
"=\"3\" Name=\"Validate\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410d-4cce-4536-83fa-"+
"4a5040674ad6\" />      <Components>        <Component>          <Name>Microsoft.BizTalk.Component.Xml"+
"Validator,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31"+
"bf3856ad364e35</Name>          <ComponentName>XML validator</ComponentName>          <Description>XM"+
"L validator component.</Description>          <Version>1.0</Version>          <Properties>          "+
"  <Property Name=\"DocumentSpecName\">              <Value xsi:type=\"xsd:string\" />            </Prope"+
"rty>            <Property Name=\"DocumentSpecTargetNamespaces\">              <Value xsi:type=\"xsd:str"+
"ing\" />            </Property>            <Property Name=\"HiddenProperties\">              <Value xsi"+
":type=\"xsd:string\">DocumentSpecTargetNamespaces</Value>            </Property>            <Property "+
"Name=\"RecoverableInterchangeProcessing\">              <Value xsi:type=\"xsd:boolean\">false</Value>   "+
"         </Property>          </Properties>          <CachedDisplayName>XML validator</CachedDisplay"+
"Name>          <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </S"+
"tage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"4\" Name=\"ResolveParty\" minOccurs="+
"\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e410e-4cce-4536-83fa-4a5040674ad6\" />      <Componen"+
"ts>        <Component>          <Name>Microsoft.BizTalk.Component.PartyRes,Microsoft.BizTalk.Pipelin"+
"e.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Name>          <Com"+
"ponentName>Party resolution</ComponentName>          <Description>Party resolution component.</Descr"+
"iption>          <Version>1.0</Version>          <Properties>            <Property Name=\"AllowBySID\""+
">              <Value xsi:type=\"xsd:boolean\">true</Value>            </Property>            <Propert"+
"y Name=\"AllowByCertName\">              <Value xsi:type=\"xsd:boolean\">true</Value>            </Prope"+
"rty>          </Properties>          <CachedDisplayName>Party resolution</CachedDisplayName>        "+
"  <CachedIsManaged>true</CachedIsManaged>        </Component>      </Components>    </Stage>  </Stag"+
"es></Document>";
        
        private const string _versionDependentGuid = "2dc5edd0-d216-4b2c-95a9-a7af7bda7e09";
        
        public AzureClaimCheckJSONReceive()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4103-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.JsonDecoder,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"RootNode\" />   "+
" <Property Name=\"RootNodeNamespace\" />  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
            stage = this.AddStage(new System.Guid("9d0e4105-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.firstRecognized);
            IBaseComponent comp1 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.XmlDasmComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp1 is IPersistPropertyBag)
            {
                string comp1XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"EnvelopeSpecNam"+
"es\">      <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"EnvelopeSpecTargetNamesp"+
"aces\">      <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"DocumentSpecNames\">   "+
"   <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"DocumentSpecTargetNamespaces\"> "+
"     <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"AllowUnrecognizedMessage\">   "+
"   <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name=\"ValidateDocument\"> "+
"     <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name=\"RecoverableInterc"+
"hangeProcessing\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>    <Property Name="+
"\"HiddenProperties\">      <Value xsi:type=\"xsd:string\">EnvelopeSpecTargetNamespaces,DocumentSpecTarge"+
"tNamespaces</Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp1XmlProperties);;
                ((IPersistPropertyBag)(comp1)).Load(pb, 0);
            }
            this.AddComponent(stage, comp1);
            stage = this.AddStage(new System.Guid("9d0e410d-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp2 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.XmlValidator,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp2 is IPersistPropertyBag)
            {
                string comp2XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"DocumentSpecNam"+
"e\">      <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"DocumentSpecTargetNamespa"+
"ces\">      <Value xsi:type=\"xsd:string\" />    </Property>    <Property Name=\"HiddenProperties\">     "+
" <Value xsi:type=\"xsd:string\">DocumentSpecTargetNamespaces</Value>    </Property>    <Property Name="+
"\"RecoverableInterchangeProcessing\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property> "+
" </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp2XmlProperties);;
                ((IPersistPropertyBag)(comp2)).Load(pb, 0);
            }
            this.AddComponent(stage, comp2);
            stage = this.AddStage(new System.Guid("9d0e410e-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp3 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.PartyRes,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp3 is IPersistPropertyBag)
            {
                string comp3XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"AllowBySID\">   "+
"   <Value xsi:type=\"xsd:boolean\">true</Value>    </Property>    <Property Name=\"AllowByCertName\">   "+
"   <Value xsi:type=\"xsd:boolean\">true</Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp3XmlProperties);;
                ((IPersistPropertyBag)(comp3)).Load(pb, 0);
            }
            this.AddComponent(stage, comp3);
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
