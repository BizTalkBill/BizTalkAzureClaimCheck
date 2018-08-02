using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkBill
{
    public class CloudEventsExtensions
    {
        public string comExampleExtension { get; set; }
    }

    public class CloudEventsStorageDiagnostics
    {
        public string batchId { get; set; }
    }

    public class CloudEventsData
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
        public CloudEventsStorageDiagnostics storageDiagnostics { get; set; }
    }

    public class CloudEventsStorageEvent
    {
        public string cloudEventsVersion { get; set; }
        public string eventType { get; set; }
        public string source { get; set; }
        public string eventID { get; set; }
        public string eventTime { get; set; }
        public CloudEventsExtensions extensions { get; set; }
        public string contentType { get; set; }
        public CloudEventsData data { get; set; }
    }
}
