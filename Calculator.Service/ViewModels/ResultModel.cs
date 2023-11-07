using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clalculator.Service.ViewModels
{
    public class ResultModel<T>
    {
        public T Data { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();

        public ResultModel() { }


        public void AddError(string error)
        {
            ValidationErrors.Add(new ValidationResult(error));
        }
    }
}
