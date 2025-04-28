namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(int x,int y)
        {
            return x+y;
        }

        public int Divide(int a, int b) 
        { 
            if (b==0)
            {
                throw new DivideByZeroException("Nie mozna dzielicprzez 0");
            }
            return a / b;
        }
    }
}
