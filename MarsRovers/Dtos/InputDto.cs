using MarsRovers.Models;

namespace MarsRovers.Dtos
{
    public class InputDto
    {
        public Instructions Instructions { get; set; } = new Instructions();
        public RoverPosition RoverPosition { get; set; } = new RoverPosition();
        public UpperRight UpperRight { get; set; } = new UpperRight();
    }
}
