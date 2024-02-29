﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = "";
        public object? Data { get; set; }

        public async static Task<Response> SuccessAsync(object data, string message)
        {
            Response response = new Response()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };

            return response;
        }
        public async static Task<Response> SuccessAsync(object data)
        {
            Response response = new Response()
            {
                IsSuccess = true,
                Data = data
            };

            return response;
        }
        public async static Task<Response> SuccessAsync(string message)
        {
            Response response = new Response()
            {
                IsSuccess = true,
                Message = message
            };

            return response;
        }
        public async static Task<Response> FailureAsync(object data, string message)
        {
            Response response = new Response()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = message,
                Data = data
            };

            return response;
        }
        public async static Task<Response> FailureAsync(string message)
        {
            Response response = new Response()
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Message = message
            };

            return response;
        }
    }
}

