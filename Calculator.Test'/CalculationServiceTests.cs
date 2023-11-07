namespace Calculator.Test
{
    using System;
    using System.Threading.Tasks;
    using Calculator.Core.Data;
    using Calculator.Core.Models;
    using Clalculator.Service;
    using Clalculator.Service.ViewModels;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CalculationServiceTests
    {
        private readonly CalculationService _testClass;
        private readonly CalculatorDbContext _context;

        public CalculationServiceTests()
        {
            _context = new CalculatorDbContext(new DbContextOptionsBuilder<CalculatorDbContext>()
                 .UseInMemoryDatabase(databaseName: "Oluwasegun")
                 .Options);
            _testClass = new CalculationService(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CalculationService(_context);

            // Assert
            instance.Should().NotBeNull();
        }

        [Theory]
        [InlineData("add")]
        [InlineData("subtract")]
        [InlineData("multiply")]
        [InlineData("divide")]
        [InlineData("")]
        public async Task CanCallPerformCalculation(string operations)
        {
            // Arrange
            var model = new CalculationVM
            {
                Num1 = 1764492311.34,
                Num2 = 1895834754.5,
                Operation = operations
            };

            // Act
            var result = await _testClass.PerformCalculation(model);

            // Assert
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task CanCallPerformCalculationDivideByZero()
        {
            // Arrange
            var model = new CalculationVM
            {
                Num1 = 1764492311.34,
                Num2 = 0,
                Operation = "divide"
            };

            // Act
            var result = await _testClass.PerformCalculation(model);

            // Assert
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task CanCallGetCalculations()
        {
            // Act
            var result = await _testClass.GetCalculations();

            // Assert
            result.Data.Should().NotBeNull();
        }
    }
}