using MarsRovers.Dtos;

namespace MarsRovers.Services
{
    public interface ICalculateLastCoordinate
    {
        Task<ResponseDto> GetLastCoordinate(InputsFromClientDto inputsFromClient);
    }
}
