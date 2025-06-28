namespace GTreasure.NPV.Service.Models
{
    /// <summary>
    /// The model holding the results of the NPV Calculation
    /// </summary>
    public class NetPresentValueResultModel
    {
        /// <summary>
        /// The constructor of <see cref="NetPresentValueResultModel"/> which accepts the years of the NPV as length.
        /// </summary>
        /// <param name="length">The length of the array, set by the time of period / years by the NPV.</param>
        public NetPresentValueResultModel(int length)
        {
            PresentValues = new decimal[length];
            DiscountRates = new decimal[length];
        }
        /// <summary>
        /// The calculated Present Values per annum, index 0 as year 1 and so on.
        /// </summary>
        public decimal[] PresentValues { get; set; }
        /// <summary>
        /// The calculated Discount Rates per annum, index 0 as year 1 and so on. 2.95% is defined as 0.0295
        /// </summary>
        public decimal[] DiscountRates { get; set; }
        /// <summary>
        /// The Net Present Value
        /// </summary>
        public decimal NetPresentValue { get; set; }
    }
}
