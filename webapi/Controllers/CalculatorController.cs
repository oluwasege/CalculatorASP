using Clalculator.Service.Interfaces;
using Clalculator.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculationService _calculatorService;

        public CalculatorController(ICalculationService calculationService)
        {
            _calculatorService = calculationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CalculationResultVM), 200)]
        public async Task<IActionResult> PerformCalculation([FromBody] CalculationVM model)
        {
            try
            {
                var result = await _calculatorService.PerformCalculation(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CalculationsHistoryVM), 200)]
        public async Task<IActionResult> GetCalculations()
        {
            try
            {
                var result = await _calculatorService.GetCalculations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
