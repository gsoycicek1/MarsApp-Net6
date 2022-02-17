using MarsRovers.Dtos;
using MarsRovers.Enums;
using MarsRovers.HelperExtensions;

namespace MarsRovers.Services
{
    public class CalculateLastCoordinate : ICalculateLastCoordinate
    {
        public async Task<ResponseDto> GetLastCoordinate(InputsFromClientDto inputsFromClient)
        {
            InputDto inputDto = new();

            ResponseDto responseUpper = CheckInputs.CheckAndFillUpperCoordinate(inputsFromClient.UpperRightCoordinates, inputDto);
            if (responseUpper.StatusCode == (int)CustomStatusCodes.Success) inputDto = responseUpper.Data as InputDto;
            else return responseUpper;

            ResponseDto responseInstructions = CheckInputs.CheckAndFillInstructions(inputsFromClient.Instructions, inputDto);
            if (responseInstructions.StatusCode == (int)CustomStatusCodes.Success) inputDto = responseInstructions.Data as InputDto;
            else return responseInstructions;

            ResponseDto responsePosition = CheckInputs.CheckAndFillRoversPositions(inputsFromClient.RoversPosition, inputDto);
            if (responsePosition.StatusCode == (int)CustomStatusCodes.Success) inputDto = responsePosition.Data as InputDto;
            else return responsePosition;

            return Calculations.CheckPossibilities(inputDto);
        }

    }
}
