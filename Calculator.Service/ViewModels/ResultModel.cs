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
        public string? Message { get; set; }

        public T Data { get; set; }
        public string? Code { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();

        public ResultModel() { }

        public bool GetHasError()
        {
            if (ValidationErrors.Count > 0)
            {
                return true;
            }

            return false;
        }

        public void AddError(string error)
        {
            ValidationErrors.Add(new ValidationResult(error));
        }
    }
}
