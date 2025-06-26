namespace GTreasure.NPV.Service.Models
{
    /// <summary>
    /// The Model for calculating the Net Present Value
    /// </summary>
    public class NetPresentValueCalculationModel
    {
        /// <summary>
        /// The Initial Investment.
        /// </summary>
        public decimal InitialInvestment { get; set; }
        /// <summary>
        /// The Lower Bound Discount Rate, 5% is defined as 0.05
        /// </summary>
        public decimal LowerBoundDiscountRate { get; set; }
        /// <summary>
        /// The Upper Bound Discount Rate, 10% is defined as 0.10
        /// </summary>
        public decimal UpperBoundDiscountRate { get; set; }
        /// <summary>
        /// The Incremental Rate per annum, 0.95% is defined  as 0.0095
        /// </summary>
        public decimal IncrementalRate { get; set; }
        /// <summary>
        /// The Net Cash Flows during each period, index 0 as year 1 and so on.
        /// </summary>
        public decimal[] AnnualCashFlows { get; set; } = Array.Empty<decimal>();
        /// <summary>
        /// The years represent the time period of the NPV
        /// </summary>
        public int Years { get; set; }
    }
}
