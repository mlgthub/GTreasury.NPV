using AutoMapper;
using GTreasury.NPV.API.Models;
using GTreasure.NPV.Service.Models;
using GTreasure.NPV.Service.Extensions;

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
                .ForMember(d => d.AnnualCashFlows,
                    o => o.MapFrom(src => src.FixedCashFlow.IsNullOrZero()
                        ? src.AnnualCashFlows : src.FixedCashFlow.Value.FillArrayWithRepeatedValues(src.Years))
                )
                .ForMember(d => d.IncrementalRate, o => o.MapFrom(src => src.IncrementalPercentage / 100))
                .ForMember(d => d.LowerBoundDiscountRate, o => o.MapFrom(src => src.LowerBoundDiscountPercentage / 100))
                .ForMember(d => d.UpperBoundDiscountRate, o => o.MapFrom(src => src.UpperBoundDiscountPercentage / 100));
            #pragma warning restore CS8629 // Nullable Fixed Rate will not be null here
            CreateMap<NetPresentValueResultModel, NetPresentValueReturnModel>();
        }
    }
}