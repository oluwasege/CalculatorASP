using Clalculator.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clalculator.Service.Interfaces
{
    public interface ICalculationService
    {
        Task<ResultModel<CalculationResultVM>> PerformCalculation(CalculationVM model);
        Task<ResultModel<List<CalculationsHistoryVM>>> GetCalculations();
    }
}
