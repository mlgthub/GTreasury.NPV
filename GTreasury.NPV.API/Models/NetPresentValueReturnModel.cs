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
        /// The sum of the Present Values / Cash Inflows
        /// </summary>
        public decimal TotalCashInflow { get; set; }
        /// <summary>
        /// The Net Present Value
        /// </summary>
        public decimal NetPresentValue { get; set; }
    }
}
