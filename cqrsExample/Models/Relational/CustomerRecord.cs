﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Models.Relational
{
    public class CustomerRecord
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<PhoneRecord> Phones { get; set; }
    }
}
