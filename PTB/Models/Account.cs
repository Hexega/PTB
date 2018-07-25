﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public TribeType Tribe { get; set; }
        public int Speed { get; set; }
    }
}
