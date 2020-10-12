namespace MarsRover.Core.Models
{
    public class Coordinate
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }

        public Coordinate(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public void IncreaseX() => X += 1;
        public void IncreaseY() => Y += 1;
        public void DecreaseX() => X -= 1;
        public void DecreaseY() => Y -= 1;

        public Coordinate GetClone() => (Coordinate)MemberwiseClone();

        public override string ToString() => $"({X},{Y})";
    }
}
