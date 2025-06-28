using GTreasure.NPV.Service.Constants;
using GTreasure.NPV.Service.Models;

namespace GTreasure.NPV.Service.Calculator
{
    /// <summary>
    /// This class contains logics used to calculate the Net Present Value.
    /// </summary>
    public class NPVCalculator : INPVCalculator
    {
        /// <inheritdoc />
        public NetPresentValueResultModel CalculateNPV(NetPresentValueCalculationModel details)
        {
            NetPresentValueResultModel result = new (details.Years);
            result.DiscountRates = GetCalculatedAnnualRates(details.LowerBoundDiscountRate,
                                details.UpperBoundDiscountRate,
                                details.IncrementalRate,
                                details.Years);

            for (int i = 0; i < details.Years; i++)
            {
                result.PresentValues[i] = CalculatePVforYearX(
                    result.DiscountRates[i],
                    details.AnnualCashFlows[i],
                    i+1);
            }

            result.NetPresentValue = result.PresentValues.Sum() - details.InitialInvestment;

            return result;
        }

        /// <inheritdoc />
        public decimal CalculatePVforYearX(decimal rate, decimal cashflow, int year)
        {
            double rateRaisedToExponent = Math.Pow(1 + (double)rate, year);
            var presentValue = cashflow / (decimal)rateRaisedToExponent;
            return Math.Round(presentValue, NPVConstants.DecimalPlaces);
        }

        /// <inheritdoc />
        public decimal[] GetCalculatedAnnualRates(decimal lowerBoundDiscountRate, decimal upperBoundDiscountRate, decimal increment, int years)
        {
            decimal[] annualRates = new decimal[years];
            decimal currentRate = lowerBoundDiscountRate;
            int i = 0;
            while (i < years && currentRate < upperBoundDiscountRate)
            {
                annualRates[i++] = currentRate;
                currentRate += increment;
            }
            if (upperBoundDiscountRate < currentRate)
                currentRate = upperBoundDiscountRate;
            while (i < years)
                annualRates[i++] = currentRate;
            return annualRates;
        }
    }
}