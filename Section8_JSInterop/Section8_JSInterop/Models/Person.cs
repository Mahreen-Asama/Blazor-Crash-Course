using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Section8_JSInterop.Models
{
    public class Person
    {
        public string Name { get; set; }

        [JSInvokable]       //bcz we want to call this function from js 
        public string SayHello(string data)
        {
            return $"Hello , {Name} and data {data}";
        }
    }
}
