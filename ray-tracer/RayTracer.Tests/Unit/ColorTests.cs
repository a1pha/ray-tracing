using NUnit.Framework;
using RayTracer.Implementation;
using Tuple = RayTracer.Implementation.Tuple;

namespace RayTracer.Tests.Unit;

[TestFixture]
public class ColorTests
{
    [Test]
    public void CreateColor()
    {
        Color col = new Color(0, 0, 0);
        Tuple tup = new Tuple(0, 0, 0, 0);
        Assert.That(tup, Is.EqualTo(col));
    }

    [Test]
    public void GetRGB()
    {
        Color col = new Color(0.1, 0.2, 0.3);
        Assert.That(col.Red, Is.EqualTo(0.1));
        Assert.That(col.Green, Is.EqualTo(0.2));
        Assert.That(col.Blue, Is.EqualTo(0.3));
    }

    [Test]
    public void ColorAddition()
    {
        Color col1 = new Color(0.9, 0.6, 0.75);
        Color col2 = new Color(0.7, 0.1, 0.25);
        Color exp = new Color(1.6, 0.7, 1.0);
        Assert.That(exp, Is.EqualTo(col1+col2));
    }
    
    [Test]
    public void ColorSubtraction()
    {
        Color col1 = new Color(0.6, 0.6, 0.75);
        Color col2 = new Color(0.1, 0.1, 0.25);
        Color exp = new Color(0.5, 0.5, 0.5);
        Assert.That(exp, Is.EqualTo(col1-col2));
    }
    
    [Test]
    public void ScalarColorMultiplication()
    {
        Color col = new Color(0.1, 0.2, 0.3);
        Color exp = new Color(0.3, 0.6, 0.9);
        Assert.That(exp, Is.EqualTo(3*col));
    }
    
    [Test]
    public void HadamardColorMultiplication()
    {
        Color col1 = new Color(0.1, 0.2, 0.3);
        Color col2 = new Color(0.3, 0.6, 0.9);
        Color exp = new Color(0.03, 0.12, 0.27);
        Assert.That(exp, Is.EqualTo(col1*col2));
    }
    
}