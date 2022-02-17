using MarsRovers.Dtos;
using MarsRovers.Enums;
using MarsRovers.HelperExtensions;
using System.Linq;
using Xunit;

namespace MarsRovers.Test.CalculationTest
{
    public class CheckPossibilitiesTest
    {
        [Fact]
        public void CheckPossibilites__When_Successfully_East()
        {
            #region Test Data
            InputDto inputDto = new InputDto();
            inputDto.UpperRight.UpperX = 5;
            inputDto.UpperRight.UpperY = 5;
            inputDto.RoverPosition.X = 3;
            inputDto.RoverPosition.Y = 3;
            inputDto.RoverPosition.Direction = "E";
            inputDto.Instructions.InstructionsKeys.AddRange("MMRMMRMRRM".Select(c => c.ToString()));
            #endregion

            ResponseDto response = Calculations.CheckPossibilities(inputDto);

            Assert.Equal("5 1 E", response.Data);
            Assert.Equal((int)CustomStatusCodes.Success, response.StatusCode);
        }

        [Fact]
        public void CheckPossibilites_When_Successfully_North()
        {
            #region Test Data
            InputDto inputDto = new InputDto();
            inputDto.UpperRight.UpperX = 5;
            inputDto.UpperRight.UpperY = 5;
            inputDto.RoverPosition.X = 1;
            inputDto.RoverPosition.Y = 2;
            inputDto.RoverPosition.Direction = "N";
            inputDto.Instructions.InstructionsKeys.AddRange("LMLMLMLMM".Select(c => c.ToString()));
            #endregion

            ResponseDto response = Calculations.CheckPossibilities(inputDto);

            Assert.Equal("1 3 N", response.Data);
            Assert.Equal((int)CustomStatusCodes.Success, response.StatusCode);
        }

        [Fact]
        public void CheckPossibilites_When_Fail_BoundUpperException()
        {
            #region Test Data
            InputDto inputDto = new InputDto();
            inputDto.UpperRight.UpperX = 2;
            inputDto.UpperRight.UpperY = 2;
            inputDto.RoverPosition.X = 1;
            inputDto.RoverPosition.Y = 2;
            inputDto.RoverPosition.Direction = "N";
            inputDto.Instructions.InstructionsKeys.AddRange("LMLMLMLMM".Select(c => c.ToString()));
            #endregion

            ResponseDto response = Calculations.CheckPossibilities(inputDto);

            Assert.Equal((int)CustomStatusCodes.BadRequest, response.StatusCode);
        }
    }
}
