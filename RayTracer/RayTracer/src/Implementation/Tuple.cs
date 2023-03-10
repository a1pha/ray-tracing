namespace RayTracer.Implementation;

public class Tuple : IEquatable<Tuple>
{
    public double X;
    public double Y;
    public double Z;
    public double W;

    public Tuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public bool IsPoint()
        => W == 1.0;

    public bool IsVector()
        => W == 0.0;

    public static Tuple point(double x, double y, double z)
        => new Tuple(x, y, z, 1.0);


    public static Tuple vector(double x, double y, double z)
        => new Tuple(x, y, z, 0.0);


    private static bool CompareDoubleEpsilon(double a, double b)
        => Math.Abs(a - b) < 1e-9 ;

    public bool Equals(Tuple other)
    {
        return CompareDoubleEpsilon(this.X, other.X) 
            && CompareDoubleEpsilon(this.Y, other.Y) 
            && CompareDoubleEpsilon(this.Z, other.Z) 
            && this.W == other.W;
    }

    public override bool Equals(Object obj)
    {
        if (obj == null)
            return false;

        Tuple tup = obj as Tuple;
        if (tup == null)
            return false;
        else
            return Equals(tup);
    }
    public static Tuple operator +(Tuple a)
       => a;

   public static Tuple operator -(Tuple a)
       => new Tuple(-a.X, -a.Y, -a.Z, -a.W);
   
   public static Tuple operator +(Tuple a, Tuple b)
       => new Tuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
   
   public static Tuple operator -(Tuple a, Tuple b)
       => new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);

   public static Tuple operator *(Tuple a, double b)
       => new Tuple(b * a.X, b * a.Y, b * a.Z, b * a.W);

   public static Tuple operator *(double b, Tuple a)
       => new Tuple(b * a.X, b * a.Y, b * a.Z, b * a.W);
   
   public static Tuple operator /(Tuple a, double b)
       => new Tuple(a.X/b, a.Y/b, a.Z/b, a.W/b);

   public double Magnitude() 
       => double.Sqrt(X * X + Y * Y + Z * Z + W * W);
   
   public Tuple Normalize()
   {
       double mag = this.Magnitude();
       return new Tuple(X/mag, Y/mag, Z/mag, W/mag);
   }

   public static double DotProduct(Tuple a, Tuple b)
       => a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;

   public static Tuple CrossProduct(Tuple a, Tuple b)
       => vector(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
}