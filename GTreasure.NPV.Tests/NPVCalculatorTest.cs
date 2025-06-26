using GTreasure.NPV.Service.Calculator;
using GTreasure.NPV.Service.Constants;
using GTreasure.NPV.Service.Models;

namespace GTreasure.NPV.Tests
{
    /// <summary>
    /// The Test Class for the NPV Calculator
    /// Sources include: https://www.cuemath.com/net-present-value-formula/ & https://www.vedantu.com/maths/net-present-value
    /// However, some calculations in the website were off by some decimal points so they were recalculated manually
    /// using a calculator to get the actual values.
    /// </summary>
    public class NPVCalculatorTest
    {
        private readonly NPVCalculator _npvCalculator;

        public NPVCalculatorTest()
        {
            _npvCalculator = new();
        }

        [Fact]
        public void TestCalculateNPV()
        {
            //Arrange
            decimal expectedNPV = 788.19m;
            NetPresentValueCalculationModel mockData = new()
            {
                AnnualCashFlows = new decimal[4] { 5000, 4000, 3000, 1000 },
                InitialInvestment = 10000.00m,
                LowerBoundDiscountRate = 0.10m,
                IncrementalRate = 0.00m,
                UpperBoundDiscountRate = 0.10m,
                Years = 4
            };

            //Act
            var result = _npvCalculator.CalculateNPV(mockData);

            //Assert
            Assert.Equal(expectedNPV, result.NetPresentValue);
        }

        [Theory]
        [InlineData(0.10, 570, 1, 518.18)]
        [InlineData(0.05, 990000, 1, 942857.14)]
        [InlineData(0.05, 45000, 1, 42857.14)]
        [InlineData(0.10, 1000, 1, 909.09)]
        [InlineData(0.10, 3000, 2, 2479.34)]
        [InlineData(0.10, 4000, 3, 3005.26)]
        [InlineData(0.10, 6750, 4, 4610.34)]
        public void TestCalculatePVforYearXs(decimal rate, decimal cashflow, int year, decimal expected)
        {
            //Act
            var result = _npvCalculator.CalculatePVforYearX(rate, cashflow, year);

            //Assert
            Assert.Equal(expected, result, NPVConstants.DecimalPlaces);
        }

        [Theory]
        [MemberData(nameof(ExpectedAnnualRatesAndNoOfYears))]
        public void TestCalculatedAnnualRatesBasedOnYears(decimal[] expectedAnnualRates, int years)
        {
            //Arrange
            decimal lowerBoundDiscountRate = 0.01m;
            decimal upperBoundDiscountRate = 0.019m;
            decimal increment = 0.0025m;

            //Act
            var result = _npvCalculator.GetCalculatedAnnualRates(lowerBoundDiscountRate, upperBoundDiscountRate, increment, years);

            //Assert
            Assert.Equal(expectedAnnualRates, result);
        }

        public static List<object[]> ExpectedAnnualRatesAndNoOfYears => new List<object[]>
        {
            new object[] {
                new decimal[4] { 0.01m, 0.0125m, 0.015m, 0.0175m },
                4
            },
            new object[] {
                new decimal[5] { 0.01m, 0.0125m, 0.015m, 0.0175m, 0.019m },
                5
            },
            new object[] {
                new decimal[6] { 0.01m, 0.0125m, 0.015m, 0.0175m, 0.019m, 0.019m },
                6
            },
        };
    }
}
