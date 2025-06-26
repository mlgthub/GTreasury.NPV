using GTreasure.NPV.Service.Models;

namespace GTreasure.NPV.Service.Calculator
{
    /// <summary>
    /// The interface for the NPV Calculator class.
    /// </summary>
    public interface INPVCalculator
    {
        /// <summary>
        /// Calculate the Net Present Value based on the given <see cref="NetPresentValueCalculationModel"/> details.
        /// </summary>
        /// <param name="details">The <see cref="NetPresentValueCalculationModel"/> details provided by the calling function.</param>
        /// <returns>The <see cref="NetPresentValueResultModel"/> with the calculated Cash in flows,
        ///     Total Cash in Flow, and the Net Present Value.</returns>
        public NetPresentValueResultModel CalculateNPV(NetPresentValueCalculationModel details);

        /// <summary>
        /// Returns the calculated Present Value for Year X.
        /// </summary>
        /// <param name="rate">The rate for the given year.</param>
        /// <param name="cashflow">The predicted cashflow for the given year.</param>
        /// <param name="year">The year.</param>
        /// <returns>The Present Value calculation.</returns>
        public decimal CalculatePVforYearX(decimal rate, decimal cashflow, int year);

        /// <summary>
        /// Calculates the Annual Rates with the given parameters.
        /// </summary>
        /// <param name="lowerBoundDiscountRate">The lower bound discount rate.</param>
        /// <param name="upperBoundDiscountRate">The upper bound discount rate.</param>
        /// <param name="increment">The discount rate increment per year.</param>
        /// <param name="years">The number of years. This will serve as the length of the array.</param>
        /// <returns>Returns a decimal[] containing the Annual Rates, with the passed years as the length.</returns>
        public decimal[] GetCalculatedAnnualRates(decimal lowerBoundDiscountRate, decimal upperBoundDiscountRate, decimal increment, int years);
    }
}