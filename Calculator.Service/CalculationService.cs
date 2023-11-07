using Calculator.Core.Data;
using Calculator.Core.Models;
using Clalculator.Service.Interfaces;
using Clalculator.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clalculator.Service
{
    public class CalculationService : ICalculationService
    {
        private readonly CalculatorDbContext _context;

        public CalculationService(CalculatorDbContext context)
        {
            _context = context;
        }

        public async Task<ResultModel<CalculationResultVM>> PerformCalculation(CalculationVM model)
        {
            var resultModel = new ResultModel<CalculationResultVM>() { Data = new CalculationResultVM() };
            try
            {
                switch (model.Operation?.ToLower())
                {
                    case "add":
                        resultModel.Data.Result = model.Num1 + model.Num2;
                        break;
                    case "subtract":
                        resultModel.Data.Result = model.Num1 - model.Num2;
                        break;
                    case "multiply":
                        resultModel.Data.Result = model.Num1 * model.Num2;
                        break;
                    case "divide":
                        if (model.Num2 == 0)
                        {
                            resultModel.AddError("Cannot divide by zero.");
                            return resultModel;
                        }
                        resultModel.Data.Result = model.Num1 / model.Num2;
                        break;
                    default:
                        resultModel.AddError("Invalid operation.");
                        return resultModel;
                }

                _context.Calculations.Add(new Calculation
                {
                    Num1 = model.Num1,
                    Num2 = model.Num2,
                    Operation = model.Operation?.ToLower(),
                    Result = resultModel.Data.Result
                });

                await _context.SaveChangesAsync();
                return resultModel;

            }
            catch (Exception ex)
            {
                resultModel.AddError($"Invalid operation due to: {ex.Message}");
                return resultModel;
            }

        }

        public async Task<ResultModel<List<CalculationsHistoryVM>>> GetCalculations()
        {
            var resultModel = new ResultModel<List<CalculationsHistoryVM>>() { Data = new List<CalculationsHistoryVM>() };
            var result = await _context.Calculations.OrderByDescending(x => x.Id).Select(x => new CalculationsHistoryVM
            {
                Id = x.Id,
                Num1 = x.Num1,
                Num2 = x.Num2,
                Operation = x.Operation,
                Result = x.Result
            }).ToListAsync();

            resultModel.Data = result;
            return resultModel;
        }

    }
}
