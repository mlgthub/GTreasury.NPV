using AutoMapper;
using GTreasury.NPV.API.Models;
using GTreasure.NPV.Service.Models;
using GTreasure.NPV.Service.Extensions;
using GTreasure.NPV.Service.Constants;

namespace GTreasury.NPV.API.AutoMapper
{
    /// <summary>
    /// The Automapper for the classes.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #pragma warning disable CS8629 // Nullable Fixed Rate will not be null here
            CreateMap<NetPresentValueRequestModel, NetPresentValueCalculationModel>()
                .ForMember(d => d.IncrementalRate, o => o.MapFrom(src => src.IncrementalPercentage / 100))
                .ForMember(d => d.LowerBoundDiscountRate, o => o.MapFrom(src => src.LowerBoundDiscountPercentage / 100))
                .ForMember(d => d.UpperBoundDiscountRate, o => o.MapFrom(src => src.UpperBoundDiscountPercentage / 100));
            #pragma warning restore CS8629 // Nullable Fixed Rate will not be null here
            CreateMap<NetPresentValueResultModel, NetPresentValueReturnModel>()
                .BeforeMap(BeforeMappingNetPresentValueResult);
            
        }

        private void BeforeMappingNetPresentValueResult(NetPresentValueResultModel fromBackEnd, NetPresentValueReturnModel toFrontEnd)
        {
            toFrontEnd.DiscountPercentages = new decimal[fromBackEnd.DiscountRates.Length];
            for (int i = 0; i < fromBackEnd.DiscountRates.Length; i++)
            {
                toFrontEnd.DiscountPercentages[i] = Math.Round(fromBackEnd.DiscountRates[i] * 100.00m, 2);
            }
        }
    }
}