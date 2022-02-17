using MarsRovers.Dtos;
using MarsRovers.Enums;

namespace MarsRovers.HelperExtensions
{
    public static class Calculations
    {
        public static ResponseDto CheckPossibilities(InputDto inputDto)
        {
            string position = inputDto.RoverPosition.Direction;
            int x = (int)Positions.InitialLimitX;
            int y = (int)Positions.InitialLimitY;

            foreach (var item in inputDto.Instructions.InstructionsKeys)
            {
                if (item == "M")
                {
                    if (position == "N") y++;
                    if (position == "E") x++;
                    if (position == "S") y--;
                    if (position == "W") x--;
                }

                if (item == "R")
                {
                    if (position == "N") position = "E";
                    else if (position == "E") position = "S";
                    else if (position == "S") position = "W";
                    else if (position == "W") position = "N";
                }

                if (item == "L")
                {
                    if (position == "N") position = "W";
                    else if (position == "E") position = "N";
                    else if (position == "S") position = "E";
                    else if (position == "W") position = "S";
                }
            }

            int lastX = inputDto.RoverPosition.X + x;
            int lastY = inputDto.RoverPosition.Y + y;

            if (lastX < (int)Positions.InitialLimitX || lastY < (int)Positions.InitialLimitY)
            {
                return ResponseDto.Fail((int)CustomStatusCodes.BadRequest, "Entered commands are out of initial bounds.");
            }

            if (lastX > inputDto.UpperRight.UpperX || lastY > inputDto.UpperRight.UpperY)
            {
                return ResponseDto.Fail((int)CustomStatusCodes.BadRequest, "Entered commands are out of upper bounds.");
            }

            return ResponseDto.Success((int)CustomStatusCodes.Success, lastX + " " + lastY + " " + position);
        }
    }
}
