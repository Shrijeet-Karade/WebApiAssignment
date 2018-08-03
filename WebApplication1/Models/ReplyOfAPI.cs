using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ReplyOfAPI
    {
        public string ApiStatus { get; set; }
        public StatusNumber StatusCode { get; set; }
        public string Message { get; set; }
    }
    public enum ApiStatus
    {
        Successful,
        Failed,
        NotFound
    }
    public enum StatusNumber
    {
        Successful = 200,
        Failed = 500,
        NotFound = 404
        

    }
}
