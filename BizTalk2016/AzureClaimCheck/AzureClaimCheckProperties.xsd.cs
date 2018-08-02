namespace AzureClaimCheck {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Property)]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"OriginalStoragePath", @"EventGridSubscriptionResponse"})]
    public sealed class AzureClaimCheckProperties : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns=""http://AzureClaimCheck.AzureClaimCheckProperties"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" targetNamespace=""https://AzureClaimCheck.AzureClaimCheckProperties"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo schema_type=""property"" xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" />
    </xs:appinfo>
  </xs:annotation>
  <xs:element name=""OriginalStoragePath"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""f7700c70-d0a3-42c6-806f-67f230130662"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name=""EventGridSubscriptionResponse"" type=""xs:string"">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid=""7c63d755-c956-4e5a-8f07-2e5af158b8c2"" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
</xs:schema>";
        
        public AzureClaimCheckProperties() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [2];
                _RootElements[0] = "OriginalStoragePath";
                _RootElements[1] = "EventGridSubscriptionResponse";
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
    [PropertyType(@"OriginalStoragePath",@"https://AzureClaimCheck.AzureClaimCheckProperties","string","System.String")]
    [PropertyGuidAttribute(@"f7700c70-d0a3-42c6-806f-67f230130662")]
    public sealed class OriginalStoragePath : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"OriginalStoragePath", @"https://AzureClaimCheck.AzureClaimCheckProperties");
        
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
    [PropertyType(@"EventGridSubscriptionResponse",@"https://AzureClaimCheck.AzureClaimCheckProperties","string","System.String")]
    [PropertyGuidAttribute(@"7c63d755-c956-4e5a-8f07-2e5af158b8c2")]
    public sealed class EventGridSubscriptionResponse : Microsoft.XLANGs.BaseTypes.MessageDataPropertyBase {
        
        [System.NonSerializedAttribute()]
        private static System.Xml.XmlQualifiedName _QName = new System.Xml.XmlQualifiedName(@"EventGridSubscriptionResponse", @"https://AzureClaimCheck.AzureClaimCheckProperties");
        
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
