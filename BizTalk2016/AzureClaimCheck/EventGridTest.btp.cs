namespace AzureClaimCheck
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class EventGridTest : Microsoft.BizTalk.PipelineOM.ReceivePipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>f66b9f5e-43ff-4f5f-ba46-885348ae1b4e</CategoryId>  <FriendlyName>Receive</FriendlyName>"+
"  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Decode\" minOccurs=\""+
"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4103-4cce-4536-83fa-4a5040674ad6\" />      <Component"+
"s>        <Component>          <Name>Microsoft.Samples.BizTalk.Pipelines.CustomComponent.FixMsg,FixM"+
"sg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=ec51c62c6b3416b7</Name>          <ComponentName"+
">FixMsg Component</ComponentName>          <Description>FixMsg Pipeline Component</Description>     "+
"     <Version>1.0</Version>          <Properties>            <Property Name=\"AppendData\">           "+
"   <Value xsi:type=\"xsd:string\">}</Value>            </Property>            <Property Name=\"PrependD"+
"ata\">              <Value xsi:type=\"xsd:string\">{ \"Events\" : </Value>            </Property>        "+
"  </Properties>          <CachedDisplayName>FixMsg Component</CachedDisplayName>          <CachedIsM"+
"anaged>true</CachedIsManaged>        </Component>        <Component>          <Name>Microsoft.BizTal"+
"k.Component.JsonDecoder,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, Pub"+
"licKeyToken=31bf3856ad364e35</Name>          <ComponentName>JSON decoder</ComponentName>          <D"+
"escription>JSON decoder component</Description>          <Version>1.0</Version>          <Properties"+
">            <Property Name=\"RootNode\">              <Value xsi:type=\"xsd:string\">EventGrid</Value> "+
"           </Property>            <Property Name=\"RootNodeNamespace\">              <Value xsi:type=\""+
"xsd:string\">https://eventgrid</Value>            </Property>            <Property Name=\"AddMessageBo"+
"dyForEmptyMessage\">              <Value xsi:type=\"xsd:boolean\">false</Value>            </Property> "+
"         </Properties>          <CachedDisplayName>JSON decoder</CachedDisplayName>          <Cached"+
"IsManaged>true</CachedIsManaged>        </Component>        <Component>          <Name>Microsoft.Pra"+
"ctices.ESB.Namespace.PipelineComponents.RemoveNamespace,Microsoft.Practices.ESB.Namespace.PipelineCo"+
"mponents, Version=2.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Name>          <Compone"+
"ntName>ESB Remove Namespace</ComponentName>          <Description>Removes all namespaces from the ro"+
"ot node.</Description>          <Version>2.1</Version>          <Properties>            <Property Na"+
"me=\"Encoding\">              <Value xsi:type=\"xsd:string\">ASCII</Value>            </Property>       "+
"     <Property Name=\"RemoveBOM\">              <Value xsi:type=\"xsd:boolean\">true</Value>            "+
"</Property>          </Properties>          <CachedDisplayName>ESB Remove Namespace</CachedDisplayNa"+
"me>          <CachedIsManaged>true</CachedIsManaged>        </Component>        <Component>         "+
" <Name>Microsoft.Practices.ESB.Namespace.PipelineComponents.AddNamespace,Microsoft.Practices.ESB.Nam"+
"espace.PipelineComponents, Version=2.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</Name> "+
"         <ComponentName>ESB Add Namespace</ComponentName>          <Description>Adds specified names"+
"pace to the root node.</Description>          <Version>2.1</Version>          <Properties>          "+
"  <Property Name=\"Separator\" />            <Property Name=\"XPaths\" />            <Property Name=\"Nam"+
"espaceBase\">              <Value xsi:type=\"xsd:string\">http://eventgridtest</Value>            </Pro"+
"perty>            <Property Name=\"NamespacePrefix\">              <Value xsi:type=\"xsd:string\">ns7</V"+
"alue>            </Property>            <Property Name=\"ExtractionNodeXPath\" />          </Propertie"+
"s>          <CachedDisplayName>ESB Add Namespace</CachedDisplayName>          <CachedIsManaged>true<"+
"/CachedIsManaged>        </Component>      </Components>    </Stage>    <Stage>      <PolicyFileStag"+
"e _locAttrData=\"Name\" _locID=\"2\" Name=\"Disassemble\" minOccurs=\"0\" maxOccurs=\"-1\" execMethod=\"FirstMa"+
"tch\" stageId=\"9d0e4105-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>    <Stage>   "+
"   <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name=\"Validate\" minOccurs=\"0\" maxOccurs=\"-1\" exec"+
"Method=\"All\" stageId=\"9d0e410d-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </Stage>    <S"+
"tage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"4\" Name=\"ResolveParty\" minOccurs=\"0\" maxOccu"+
"rs=\"-1\" execMethod=\"All\" stageId=\"9d0e410e-4cce-4536-83fa-4a5040674ad6\" />      <Components />    </"+
"Stage>  </Stages></Document>";
        
        private const string _versionDependentGuid = "f6f90dec-2247-4281-8f4b-74312916bfaa";
        
        public EventGridTest()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4103-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.Samples.BizTalk.Pipelines.CustomComponent.FixMsg,FixMsg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=ec51c62c6b3416b7");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"AppendData\">   "+
"   <Value xsi:type=\"xsd:string\">}</Value>    </Property>    <Property Name=\"PrependData\">      <Valu"+
"e xsi:type=\"xsd:string\">{ \"Events\" : </Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
            IBaseComponent comp1 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.JsonDecoder,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp1 is IPersistPropertyBag)
            {
                string comp1XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"RootNode\">     "+
" <Value xsi:type=\"xsd:string\">EventGrid</Value>    </Property>    <Property Name=\"RootNodeNamespace\""+
">      <Value xsi:type=\"xsd:string\">https://eventgrid</Value>    </Property>    <Property Name=\"AddM"+
"essageBodyForEmptyMessage\">      <Value xsi:type=\"xsd:boolean\">false</Value>    </Property>  </Prope"+
"rties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp1XmlProperties);;
                ((IPersistPropertyBag)(comp1)).Load(pb, 0);
            }
            this.AddComponent(stage, comp1);
            IBaseComponent comp2 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.Practices.ESB.Namespace.PipelineComponents.RemoveNamespace,Microsoft.Practices.ESB.Namespace.PipelineComponents, Version=2.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp2 is IPersistPropertyBag)
            {
                string comp2XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"Encoding\">     "+
" <Value xsi:type=\"xsd:string\">ASCII</Value>    </Property>    <Property Name=\"RemoveBOM\">      <Valu"+
"e xsi:type=\"xsd:boolean\">true</Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp2XmlProperties);;
                ((IPersistPropertyBag)(comp2)).Load(pb, 0);
            }
            this.AddComponent(stage, comp2);
            IBaseComponent comp3 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.Practices.ESB.Namespace.PipelineComponents.AddNamespace,Microsoft.Practices.ESB.Namespace.PipelineComponents, Version=2.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp3 is IPersistPropertyBag)
            {
                string comp3XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"Separator\" />  "+
"  <Property Name=\"XPaths\" />    <Property Name=\"NamespaceBase\">      <Value xsi:type=\"xsd:string\">ht"+
"tp://eventgridtest</Value>    </Property>    <Property Name=\"NamespacePrefix\">      <Value xsi:type="+
"\"xsd:string\">ns7</Value>    </Property>    <Property Name=\"ExtractionNodeXPath\" />  </Properties></P"+
"ropertyBag>";
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
