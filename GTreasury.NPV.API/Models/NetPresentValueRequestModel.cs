namespace GTreasury.NPV.API.Models
{
    public class NetPresentValueRequestModel
    {
        /// <summary>
        /// The Initial Investment.
        /// </summary>
        public decimal InitialInvestment { get; set; }
        /// <summary>
        /// The Lower Bound Discount Percentage, 5% is defined as 5
        /// </summary>
        public decimal LowerBoundDiscountPercentage { get; set; }
        /// <summary>
        /// The Upper Bound Discount Percentage, 10% is defined as 10
        /// </summary>
        public decimal UpperBoundDiscountPercentage { get; set; }
        /// <summary>
        /// The Incremental Rate per annum, 0.95% is defined as 0.95
        /// </summary>
        public decimal IncrementalPercentage { get; set; }
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
