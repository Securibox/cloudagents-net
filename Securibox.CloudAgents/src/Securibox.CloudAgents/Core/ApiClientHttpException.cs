﻿using System;
using System.Web;

namespace Securibox.CloudAgents.Core
{
    public class ApiClientHttpException : HttpException
    {
        public ErrorResponse ErrorResponse { get; set; }
        public ApiClientHttpException(int httpCode, string message) : base(httpCode, message)
        {
            try
            {
                this.ErrorResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorResponse>(message);
            }
            catch (Exception)
            {
                this.ErrorResponse = null;
            }
        }
    }
}