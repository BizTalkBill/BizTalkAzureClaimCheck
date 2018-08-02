namespace AzureClaimCheck {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Property)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"ClientId", @"MessageTypeId", @"WorkflowRunId", @"OriginalInboundURL"})]
    public sealed class AzureClaimCheckSBProperties : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AzureClaimCheck.AzureClaimCheckSBProperties"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""https://AzureClaimCheck.AzureClaimCheckSBProperties"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo schema_type=""property"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" />
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""ClientId"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""c582c95c-448b-45f9-8f0b-054ee1b49bd1"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""MessageTypeId"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""d29465ea-6dd9-4089-a31c-45c908e283e5"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""WorkflowRunId"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""c3871401-8ac1-4afa-8813-b060da19528a"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""OriginalInboundURL"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""fdbe7789-ed7d-4734-accd-626a04097a6d"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
</xs:schema>";
        
        public AzureClaimCheckSBProperties() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [4];
                _RootElements[0] = "ClientId";
                _RootElements[1] = "MessageTypeId";
                _RootElements[2] = "WorkflowRunId";
                _RootElements[3] = "OriginalInboundURL";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"ClientId",@"https://AzureClaimCheck.AzureClaimCheckSBProperties","string","System.String")]
    [PropertyGuidAttribute(@"c582c95c-448b-45f9-8f0b-054ee1b49bd1")]
    public sealed class ClientId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"ClientId", @"https://AzureClaimCheck.AzureClaimCheckSBProperties");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"MessageTypeId",@"https://AzureClaimCheck.AzureClaimCheckSBProperties","string","System.String")]
    [PropertyGuidAttribute(@"d29465ea-6dd9-4089-a31c-45c908e283e5")]
    public sealed class MessageTypeId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"MessageTypeId", @"https://AzureClaimCheck.AzureClaimCheckSBProperties");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"WorkflowRunId",@"https://AzureClaimCheck.AzureClaimCheckSBProperties","string","System.String")]
    [PropertyGuidAttribute(@"c3871401-8ac1-4afa-8813-b060da19528a")]
    public sealed class WorkflowRunId : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"WorkflowRunId", @"https://AzureClaimCheck.AzureClaimCheckSBProperties");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [System.SerializableAttribute()]
    [PropertyType(@"OriginalInboundURL",@"https://AzureClaimCheck.AzureClaimCheckSBProperties","string","System.String")]
    [PropertyGuidAttribute(@"fdbe7789-ed7d-4734-accd-626a04097a6d")]
    public sealed class OriginalInboundURL : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"OriginalInboundURL", @"https://AzureClaimCheck.AzureClaimCheckSBProperties");
        
        private static string PropertyValueType {
            get {
                throw new System.NotSupportedException();
            }
        }
        
        public override System.Xml.XmlQualifiedName Name {
            get {
                return _QName;
            }
        }
        
        public override System.Type Type {
            get {
                return typeof(string);
            }
        }
    }
}
