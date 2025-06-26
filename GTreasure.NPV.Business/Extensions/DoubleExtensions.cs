namespace GTreasure.NPV.Service.Extensions
{
    /// <summary>
    /// Added Extensions for the Decimal data type
    /// </summary>
    public static class DecimalExtensions
    {
        public static bool IsNullOrZero(this decimal? value)
        {
            return (value == null || value == 0);
        }
        
        public static decimal[] FillArrayWithRepeatedValues(this decimal value, int len)
        {
            decimal[] repeatedValues = new decimal[len];
            for (int i = 0; i < len; i++)
            {
                repeatedValues[i] = value;
            }
            return repeatedValues;
        }
    }
}
