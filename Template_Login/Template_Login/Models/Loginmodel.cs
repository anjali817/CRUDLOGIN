using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template_Login.Models
{
    public class Loginmodel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}