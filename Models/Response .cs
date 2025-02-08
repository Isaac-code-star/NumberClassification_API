using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberClassification_API.Models
{
    public class Response 
    {
        public string? number {get; set;}
        public bool error {get; set;}
    }
}