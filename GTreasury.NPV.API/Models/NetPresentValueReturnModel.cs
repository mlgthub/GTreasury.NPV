namespace GTreasury.NPV.API.Models
{
    /// <summary>
    /// The model with the results of the NPV Calculation to be sent back to the UI.
    /// </summary>
    public class NetPresentValueReturnModel
    {
        /// <summary>
        /// The calculated Present Values per annum, index 0 as year 1 and so on.
        /// </summary>
        public decimal[] PresentValues { get; set; } = Array.Empty<decimal>();
        /// <summary>
        /// The calculated Discount Percentages per annum, index 0 as year 1 and so on. 2.95% is defined as 2.95
        /// </summary>
        public decimal[] DiscountPercentages { get; set; } = Array.Empty<decimal>();
        /// <summary>
        /// The Net Present Value
        /// </summary>
        public decimal NetPresentValue { get; set; }
    }
}
