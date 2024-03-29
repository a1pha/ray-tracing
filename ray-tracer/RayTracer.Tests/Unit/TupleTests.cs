using NUnit.Framework;
using Tuple = RayTracer.Implementation.Tuple;

namespace RayTracer.Tests.Unit;

[TestFixture]
public class TupleTests
{
    [Test]
    public void GetXYZW()
    {
        Tuple tup = new Tuple(1, 2, 3, 1);
        Assert.That(tup.X, Is.EqualTo(1));
        Assert.That(tup.Y, Is.EqualTo(2));
        Assert.That(tup.Z, Is.EqualTo(3));
        Assert.That(tup.W, Is.EqualTo(1));
    }
    
    [Test]
    public void IsPointTrue()
    {
        Tuple point = new Tuple(1, 2, 3, 1);
        Assert.That(point.IsPoint(), Is.True);
    }

    [Test]
    public void IsPointFalse()
    {
        Tuple vector = new Tuple(1, 2, 3, 0);
        Assert.That(vector.IsPoint(), Is.False);
    }
    
    [Test]
    public void IsVectorTrue()
    {
        Tuple vector = new Tuple(1, 2, 3, 0);
        Assert.That(vector.IsVector(), Is.True);
    }
    
    [Test]
    public void IsVectorFalse()
    {
        Tuple point = new Tuple(1, 2, 3, 1);
        Assert.That(point.IsVector(), Is.False);
    }

    [Test]
    public void CreatesPoint()
    {
        Tuple point = Tuple.point(4, -4, 3);
        Assert.That(point.X, Is.EqualTo(4));
        Assert.That(point.Y, Is.EqualTo(-4));
        Assert.That(point.Z, Is.EqualTo(3));
        Assert.That(point.W, Is.EqualTo(1));
    }

    [Test]
    public void CreatesVector()
    {
        Tuple vector = Tuple.vector(4, -4, 3);
        Assert.That(vector.X, Is.EqualTo(4));
        Assert.That(vector.Y, Is.EqualTo(-4));
        Assert.That(vector.Z, Is.EqualTo(3));
        Assert.That(vector.W, Is.EqualTo(0));
    }
    
    [Test]
    public void AreEqualTrueExact()
    {
        Tuple tup1 = new Tuple(1, 2, 3, 1);
        Tuple tup2 = new Tuple(1, 2, 3, 1);
        Assert.That(tup1, Is.EqualTo(tup2));
    }
    
    [Test]
    public void AreEqualTrueNotExact()
    {
        Tuple tup1 = new Tuple(1, 2, 3, 1);
        Tuple tup2 = new Tuple(1.0-Double.Epsilon, 2.0-Double.Epsilon, 3.0-Double.Epsilon, 1);
        Assert.That(tup1, Is.EqualTo(tup2));
    }
    
    [Test]
    public void AreEqualFalseNotExact()
    {
        Tuple tup1 = new Tuple(1, 2, 3, 1);
        Tuple tup2 = new Tuple(0.999999, 1.999999, 2.999999, 1);
        Assert.That(tup1, Is.Not.EqualTo(tup2));
    }
    
    [Test]
    public void AreEqualFalse()
    {
        Tuple tup1 = new Tuple(1, 2, 3, 1);
        Tuple tup2 = new Tuple(1, 5, 3, 1);
        Assert.That(tup1, Is.Not.EqualTo(tup2));
    }

    [Test]
    public void TupleAdditionBasic1()
    {
        Tuple tup1 = new Tuple(1, 2, 3, 1);
        Tuple tup2 = new Tuple(3, 2, 1, 0);
        Tuple expected = new Tuple(4, 4, 4, 1);
        Assert.That(expected, Is.EqualTo(tup1+tup2));
    }
    
    [Test]
    public void TupleAdditionBasic2()
    {
        Tuple tup1 = new Tuple(1, 2, 3, 0);
        Tuple tup2 = new Tuple(3, 2, 1, 0);
        Tuple expected = new Tuple(4, 4, 4, 0);
        Assert.That(expected, Is.EqualTo(tup1+tup2));
    }
    
    [Test]
    public void TupleSubtractionBasic1()
    {
        Tuple tup1 = Tuple.point(3, 2, 1);
        Tuple tup2 = Tuple.point(5, 6, 7);
        Tuple expected = Tuple.vector(-2, -4, -6);
        Assert.That(expected, Is.EqualTo(tup1-tup2));
    }
    
    [Test]
    public void TupleSubtractionBasic2()
    {
        Tuple tup1 = Tuple.point(3, 2, 1);
        Tuple tup2 = Tuple.vector(5, 6, 7);
        Tuple expected = Tuple.point(-2, -4, -6);
        Assert.That(expected, Is.EqualTo(tup1-tup2));
    }
    
    [Test]
    public void TupleSubtractionBasic3()
    {
        Tuple tup1 = Tuple.vector(3, 2, 1);
        Tuple tup2 = Tuple.vector(5, 6, 7);
        Tuple expected = Tuple.vector(-2, -4, -6);
        Assert.That(expected, Is.EqualTo(tup1-tup2));
    }
    
    [Test]
    public void TupleSubtractFromZero()
    {
        Tuple zero = Tuple.vector(0, 0, 0);
        Tuple tup2 = Tuple.vector(5, -6, 7);
        Tuple expected = Tuple.vector(-5, 6, -7);
        Assert.That(expected, Is.EqualTo(zero-tup2));
    }
    
    [Test]
    public void NegatingTuple()
    {
        Tuple actual = new Tuple(-1, 2, -3, 4);
        Tuple expected = new Tuple(1, -2, 3, -4);
        Assert.That(expected, Is.EqualTo(-actual));
    }
    
    [Test]
    public void ScalarMultiplication1()
    {
        Tuple actual = new Tuple(-1, 2, -3, 4);
        Tuple expected = new Tuple(-2, 4, -6, 8);
        Assert.That(expected, Is.EqualTo(2*actual));
    }
    
    [Test]
    public void ScalarMultiplication2()
    {
        Tuple actual = new Tuple(-1, 2, -3, 4);
        Tuple expected = new Tuple(-0.5, 1.0, -1.5, 2.0);
        Assert.That(expected, Is.EqualTo(0.5*actual));
    }

    [Test] 
    public void ScalarDivision()
    {
        Tuple actual = new Tuple(1, -2, -3, -4);
        Tuple expected = new Tuple(0.5, -1, -1.5, -2);
        Assert.That(expected, Is.EqualTo(actual/2));
    }
    
    [Test] 
    public void Magnitude1()
    {
        Tuple i = Tuple.vector(1,0,0);
        Assert.That(i.Magnitude(), Is.EqualTo(1));
    }
    
    [Test] 
    public void Magnitude2()
    {
        Tuple j = Tuple.vector(0,1,0);
        Assert.That(j.Magnitude(), Is.EqualTo(1));
    }
    
    [Test] 
    public void Magnitude3()
    {
        Tuple k = Tuple.vector(0,0,1);
        Assert.That(k.Magnitude(), Is.EqualTo(1));
    }
    
    [Test] 
    public void Magnitude4()
    {
        Tuple pos = Tuple.vector(1,2,3);
        Assert.That(pos.Magnitude(), Is.EqualTo(Double.Sqrt(14)));
    }
    
    [Test] 
    public void Magnitude5()
    {
        Tuple neg = Tuple.vector(-1,-2,-3);
        Assert.That(neg.Magnitude(), Is.EqualTo(Double.Sqrt(14)));
    }
    
    [Test] 
    public void Normalize1()
    {
        Tuple orig = Tuple.vector(4,0,0);
        Tuple norm = Tuple.vector(1,0,0);
        Assert.That(norm, Is.EqualTo(orig.Normalize()));
    }
    
    [Test] 
    public void Normalize2()
    {
        Tuple orig = Tuple.vector(1,2,3);
        Tuple norm = Tuple.vector(1.0/Double.Sqrt(14),2.0/Double.Sqrt(14),3/Double.Sqrt(14));
        Assert.That(norm, Is.EqualTo(orig.Normalize()));
    }
    
    [Test] 
    public void Magnitude6()
    {
        Tuple orig = Tuple.vector(1,2,3);
        Tuple norm = orig.Normalize();
        Assert.That(norm.Magnitude(), Is.EqualTo(1));
    }
    
    [Test] 
    public void DotProduct()
    {
        Tuple a = Tuple.vector(1,2,3);
        Tuple b = Tuple.vector(2,3,4);
        Assert.That(Tuple.DotProduct(a, b), Is.EqualTo(20));
    }
    
    [Test] 
    public void CrossProduct1()
    {
        Tuple a = Tuple.vector(1,2,3);
        Tuple b = Tuple.vector(2,3,4);
        Tuple res = Tuple.vector(-1, 2, -1);
        Assert.That(res, Is.EqualTo(Tuple.CrossProduct(a, b)));
    }
    
    [Test] 
    public void CrossProduct2()
    {
        Tuple a = Tuple.vector(1,2,3);
        Tuple b = Tuple.vector(2,3,4);
        Tuple res = Tuple.vector(1, -2, 1);
        Assert.That(res, Is.EqualTo(Tuple.CrossProduct(b, a)));
    }

}