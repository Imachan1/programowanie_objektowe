using CalculatorApp;
using Xunit;
//using Xunit;

namespace CalculatorApp.Test;

public class CalculatorTest
{
    [Fact]//USING XUNIT !!!
    public void Add_ShouldReturnCorrectSum()
    {
        // arrange
        var calculator = new Calculator();


        // act
        int result = calculator.Add(3, 5);


        //assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Divide_ShouldReturnCorrectResult()
    {
        // arrange
        var calculator = new Calculator();


        // act
        int result = calculator.Add(20, 5);


        //assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Divide_ByZero_ShouldThrowDividebyZeroException()
    {
        // arrange
        var calculator = new Calculator();


        // act & assert
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10,0));


    }
}
