﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Models.Helpers
{
    public class SucceedResponse : Response
    {
        public string Message { get; set; }
        public SucceedResponse(string message) : base(true)
        {
            Message = message;
        }
    }
}
