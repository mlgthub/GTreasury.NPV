using AutoMapper;
using GTreasure.NPV.Service.Calculator;
using GTreasure.NPV.Service.Models;
using GTreasury.NPV.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GTreasury.NPV.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NetPresentValueController : ControllerBase
{
    private IMapper _mapper;
    private INPVCalculator _npvCalculator;

    public NetPresentValueController(IMapper mapper, INPVCalculator npvCalculator)
    {
        _mapper = mapper;
        _npvCalculator = npvCalculator;
    }

    /// <summary>
    /// The controller action to calculate the NPV based on the given details.
    /// </summary>
    /// <param name="requestModel">The <see cref="NetPresentValueRequestModel"/> containing the details from the UI.</param>
    /// <returns>The <see cref="NetPresentValueReturnModel"/> with the calculated results.</returns>
    [HttpPost(Name = "CalculateNPV")]
    public IActionResult CalculateNPV(NetPresentValueRequestModel requestModel)
    {
        try
        {
            var result = _npvCalculator.CalculateNPV(_mapper.Map<NetPresentValueCalculationModel>(requestModel));
            return Ok(_mapper.Map<NetPresentValueReturnModel>(result));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
