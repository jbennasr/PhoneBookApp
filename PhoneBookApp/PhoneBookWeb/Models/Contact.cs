﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PhoneBookWeb.Models
{
    public class Contact
    {
        public int ContactId { get; set; }



        public string Name { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}