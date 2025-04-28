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
}
