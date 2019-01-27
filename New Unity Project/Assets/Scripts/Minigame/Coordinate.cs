using System;

[Serializable]
public struct Coordinate : IEquatable<Coordinate>
{
    public int X;
    public int Y;

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj is Coordinate) { return Equals((Coordinate)obj); }
        else { return false; }
    }

    public bool Equals(Coordinate other)
    {
        return other.X == X
            && other.Y == Y;
    }

    public override int GetHashCode()
    {
        var hashCode = 1861411795;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + X.GetHashCode();
        hashCode = hashCode * -1521134295 + Y.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(Coordinate coordinate1, Coordinate coordinate2)
    {
        return coordinate1.Equals(coordinate2);
    }

    public static bool operator !=(Coordinate coordinate1, Coordinate coordinate2)
    {
        return !(coordinate1 == coordinate2);
    }
}