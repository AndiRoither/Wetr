﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Wetr.Web.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
    }
}