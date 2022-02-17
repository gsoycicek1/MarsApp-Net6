using MarsRovers.Dtos;
using MarsRovers.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRovers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICalculateLastCoordinate _calculateLastCoordinate;
         
        public HomeController(ICalculateLastCoordinate calculateLastCoordinate)
        {
            _calculateLastCoordinate = calculateLastCoordinate;
        }

        #region Main Service
        [HttpPost]
        public async Task<IActionResult> GetLastCoordinate(InputsFromClientDto inputsFromClient)
        {
            return Ok(await _calculateLastCoordinate.GetLastCoordinate(inputsFromClient));
        }
        #endregion
    }
}
