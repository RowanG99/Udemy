using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace BMES_API_Project.Messages.Response
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Messages = new List<string>(); 
        }

        public HttpStatusCode StatusCode { get; set; }
        public List<string> Messages { get; set; }
    }
}
