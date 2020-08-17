using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebMotors.Framework.Models
{
    public class ErrorModel
    {
        public ErrorModel(string msg)
        {
            Message = msg;
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
