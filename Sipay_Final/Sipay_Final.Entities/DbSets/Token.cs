﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Final.Entities.DbSets
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
