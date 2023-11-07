using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string? Operation { get; set; }
        public double Result { get; set; }
    }
}
