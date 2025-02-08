using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberClassification_API.Models
{
    public class NumberClassification
    {
        public int Number {get; set;}
        public bool Is_prime {get; set;}
        public bool Is_perfect {get; set;}
        public List<string>? Properties {get; set;}
        public int Digit_sum {get; set;}
        public string? Fun_fact {get; set;}
    }
}