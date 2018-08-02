using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkBill
{
    public class EventGridStorageDiagnostics
    {
        public string batchId { get; set; }
    }

    public class EventGridData
    {
        public string api { get; set; }
        public string clientRequestId { get; set; }
        public string requestId { get; set; }
        public string eTag { get; set; }
        public string contentType { get; set; }
        public int contentLength { get; set; }
        public string blobType { get; set; }
        public string url { get; set; }
        public string sequencer { get; set; }
        public EventGridStorageDiagnostics storageDiagnostics { get; set; }
    }
    
    public class EventGridStorageEvent
    {
        public string topic { get; set; }
        public string subject { get; set; }
        public string eventType { get; set; }
        public string eventTime { get; set; }
        public string id { get; set; }
        public EventGridData data { get; set; }
        public string dataVersion { get; set; }
        public string metadataVersion { get; set; }
    }
}
