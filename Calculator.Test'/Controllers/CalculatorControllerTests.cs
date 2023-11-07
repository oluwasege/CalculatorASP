namespace Calculator.Test_.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clalculator.Service.Interfaces;
    using Clalculator.Service.ViewModels;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using webapi.Controllers;
    using Xunit;

    public class CalculatorControllerTests
    {
        private readonly CalculatorController _testClass;
        private readonly ICalculationService _calculationService;

        public CalculatorControllerTests()
        {
            _calculationService = A.Fake<ICalculationService>();
            _testClass = new CalculatorController(_calculationService);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CalculatorController(_calculationService);

            // Assert
            instance.Should().NotBeNull();
        }

        [Fact]
        public async Task CanCallPerformCalculation()
        {
            // Arrange
            var model = new CalculationVM
            {
                Num1 = 1750942831.77,
                Num2 = 49473315.54,
                Operation = "add"
            };

            A.CallTo(() => _calculationService.PerformCalculation(A<CalculationVM>._)).Returns(new ResultModel<CalculationResultVM>() { Data = new CalculationResultVM() });

            // Act
            var result = await _testClass.PerformCalculation(model) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task CanCallPerformCalculationHasException()
        {
            // Arrange
            var model = new CalculationVM
            {
                Num1 = 1750942831.77,
                Num2 = 49473315.54,
                Operation = "add"
            };

            A.CallTo(() => _calculationService.PerformCalculation(A<CalculationVM>._)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _testClass.PerformCalculation(model) as OkObjectResult;

            // Assert
            result.Should().BeNull();
        }


        [Fact]
        public async Task CanCallGetCalculations()
        {
            // Arrange
            A.CallTo(() => _calculationService.GetCalculations()).Returns(new ResultModel<List<CalculationsHistoryVM>>());

            // Act
            var result = await _testClass.GetCalculations();

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task CanCallGetCalculationsHasException()
        {
            // Arrange
            A.CallTo(() => _calculationService.GetCalculations()).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _testClass.GetCalculations() as OkObjectResult;

            // Assert
            result.Should().BeNull();
        }
    }
}