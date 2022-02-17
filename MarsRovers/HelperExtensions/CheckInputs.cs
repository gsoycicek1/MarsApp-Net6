using MarsRovers.Dtos;
using MarsRovers.Enums;

namespace MarsRovers.HelperExtensions
{
    public static class CheckInputs
    {
        #region Upper Coordinate Control
        public static ResponseDto CheckAndFillUpperCoordinate(string upperRightCoordinates, InputDto inputDto)
        {
            string[] upperRightCoordinatesList = upperRightCoordinates.ToUpper().Split(" ");

            if (upperRightCoordinatesList.Length != 2) return ResponseDto.Fail((int)CustomStatusCodes.BadRequest, "You must enter 2 data with a space.");
            else
            {
                inputDto.UpperRight.UpperX = Convert.ToInt32(upperRightCoordinatesList[0]);
                inputDto.UpperRight.UpperY = Convert.ToInt32(upperRightCoordinatesList[1]);
            }
            return ResponseDto.Success((int)CustomStatusCodes.Success, inputDto);
        }
        #endregion

        #region Instructions Control
        public static ResponseDto CheckAndFillInstructions(string instructions, InputDto inputDto)
        {
            instructions = instructions.ToUpper().Replace(" ", "");
            if (instructions.Length < 1) return ResponseDto.Fail((int)CustomStatusCodes.BadRequest, "You must enter at least one data.");
            else
            {
                inputDto.Instructions.InstructionsKeys.AddRange(instructions.Select(c => c.ToString()));
            }
            return ResponseDto.Success((int)CustomStatusCodes.Success, inputDto);
        }
        #endregion

        #region Rover Position Control
        public static ResponseDto CheckAndFillRoversPositions(string positions, InputDto inputDto)
        {
            string[] positionsList = positions.ToUpper().Split(" ");

            if (positionsList.Length != 3) return ResponseDto.Fail((int)CustomStatusCodes.BadRequest, "You must enter 2 data with a space.");
            else
            {
                inputDto.RoverPosition.X = Convert.ToInt32(positionsList[0]);
                inputDto.RoverPosition.Y = Convert.ToInt32(positionsList[1]);
                inputDto.RoverPosition.Direction = positionsList[2];
            }
            return ResponseDto.Success((int)CustomStatusCodes.Success, inputDto);
        }
        #endregion
    }
}
