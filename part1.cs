using System;

struct Vector
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Vector(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector operator *(Vector v1, Vector v2)
    {
        return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
    }

    public static Vector operator *(Vector v, int scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z) != Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z) != Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vector vector1 = new Vector(1, 2, 3);
        Vector vector2 = new Vector(4, 5, 6);

        Vector sum = vector1 + vector2;
        Console.WriteLine($"Sum: ({sum.X}, {sum.Y}, {sum.Z})");

        Vector product = vector1 * vector2;
        Console.WriteLine($"Product: ({product.X}, {product.Y}, {product.Z})");

        Vector scaled = vector1 * 2;
        Console.WriteLine($"Scaled: ({scaled.X}, {scaled.Y}, {scaled.Z})");

        bool isEqual = vector1 == vector2;
        Console.WriteLine($"Equal: {isEqual}");

        bool isNotEqual = vector1 != vector2;
        Console.WriteLine($"Not Equal: {isNotEqual}");
    }
}
