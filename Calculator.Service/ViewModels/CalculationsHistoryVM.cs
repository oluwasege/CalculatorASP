
using Calculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clalculator.Service.ViewModels
{
    public class CalculationsHistoryVM
    {
        public int Id { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string? Operation { get; set; }
        public double Result { get; set; }


    }
}
