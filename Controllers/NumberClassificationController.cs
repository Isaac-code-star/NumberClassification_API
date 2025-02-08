using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NumberClassification_API.Models;

namespace NumberClassification_API.Controllers
{
    [ApiController]
    [Route("api/classify-number")]
    public class NumberClassificationController : ControllerBase
    {
        public NumberClassification GetNumberClassification(int number ){
            return new NumberClassification{
                Number = number,
                Is_prime = Is_prime(number),
                Is_perfect = Is_perfect(number),
                Digit_sum = DigitSum(number),
                Properties = GetProperties(number, new List<string> {"armstrong", "odd"}),
                Fun_fact= FunFact(number)
                

            };
        }

        

        private bool Is_prime(int number){
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
                if (number % i == 0) return false;
            return true;
        }

        private bool Is_perfect(int number){
            if (number < 1) return false;
            int sum = 0; 
            for (int i = 1; i <= number / 2; i++){
                if (sum % i == 0)
                    sum += i;
            }
            return sum == number;
        }

        private bool is_armstrong(int number){
            int sum = 0, temp = number, digits = number.ToString().Length;
            while (temp > 0){
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, digits);
                temp /= 10;
            }
            return sum == number;
        }



        

        static int DigitSum(int number){
            int sum = 0;
            while(number > 0){
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        private List<string> GetProperties(int number, List<string> properties){
            var result = new List<string>();
            if (properties.Contains("armstrong") && is_armstrong(number)) result.Add("armstrong");
            if (properties.Contains("odd") && number % 2 != 0) result.Add("odd");
            return result;
        }

        private string FunFact(int number){
            if (is_armstrong(number)){
                var digit = number.ToString().Select(d => int.Parse(d.ToString()));
                string power = string.Join(" + ", digit.Select(d => $"{d}^{digit.Count()}"));

                return $"{number} is an Armstrong number because {power} = {number}";
            }

            return "No special fun fact available";
                
        }
        

        //fetching data by id(number)
        [HttpGet("{id}")]
        public IActionResult GetSingle(string id)
        {
            if( Regex.IsMatch(id, "[a-zA-Z]")){
                return BadRequest(new Response{
                    number = "alphabet",
                    error = true
                });
            }
            else{
                var number = int.Parse(id);
                var result = GetNumberClassification(number);
                return Ok(result);
            }            
            
        }


        //creating method to handle all checks
        // private bool Isprime(int num){
        //     if (num < 2) return false;
        //     for(int i = 2; i * i <= num; i++)
        //         if (num % i == 0) return false;
        //     return true;
        // }
    }
}