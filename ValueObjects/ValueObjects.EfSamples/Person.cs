﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjects.EfSamples
{
    public class Person
    {
        public int Id { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }

    }
}
