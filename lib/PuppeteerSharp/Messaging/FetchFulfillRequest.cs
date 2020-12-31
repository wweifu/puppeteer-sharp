using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace PuppeteerSharp.Messaging
{
    internal class FetchFulfillRequest
    {
        public string RequestId { get; set; }

        public int ResponseCode
        {
            get => _responseCode;
            set
            {
                _responseCode = value;
                var d = new HttpResponseMessage((HttpStatusCode)_responseCode);
                ResponsePhrase = d.ReasonPhrase; // ReasonPhrases.GetReasonPhrase(ResponseCode); TODO:修复不能json序列化的bug  ReasonPhrases.GetReasonPhrase 是 .netCore 项目的 .net FrameWorker 4.8没有
                d.Dispose();
            }
        }

        public string ResponsePhrase { get; set; }// => ReasonPhrases.GetReasonPhrase(ResponseCode); TODO:修复不能json序列化的bug

        public Header[] ResponseHeaders { get; set; }

        public string Body { get; set; }

        private int _responseCode;
    }
}
