using System;
using System.Text;

try
{
    IBinary1 number = new Binary1();
    number.Input();
    number.Output();
    Binary1 number2 = new Binary1();
    number2.Input();
    number2.Output();
    number.Sum(number2);
    number.Mult(number2);
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
interface IBinary1
{
    void Input();
    void Output();
    void Sum(Binary1 binary1);
    void Mult(Binary1 binary1);
}
abstract class AbstrBinary1 : IBinary1
{
    protected string integerPart;
    protected string fractionalPart;
    public abstract void Input();
    public abstract void Output();
    public abstract void Sum(Binary1 binary1);
    public abstract void Mult(Binary1 binary1);
}
class Binary1 : AbstrBinary1
{
    public override void Input()
    {
        Console.WriteLine("Enter the integer part of the number using 0, 1");
        integerPart = Console.ReadLine();
        Console.WriteLine("Enter the fractional part of the number using 0, 1");
        fractionalPart = Console.ReadLine();
    }
    public override void Output()
    {
        Console.WriteLine($"Binary number: {integerPart}.{fractionalPart}");
    }
    public override void Sum(Binary1 binary1)
    {
        int int1 = Convert.ToInt32(integerPart, 2);
        double frac1 = Convert.ToInt32(fractionalPart, 2) / Math.Pow(2, fractionalPart.Length);
        double num1 = int1 + frac1;

        int int2 = Convert.ToInt32(binary1.integerPart, 2);
        double frac2 = Convert.ToInt32(binary1.fractionalPart, 2) / Math.Pow(2, binary1.fractionalPart.Length);
        double num2 = int2 + frac2;

        double result = num1 + num2;
        int resultInt = (int)Math.Truncate(result);
        double resultFrac = result - resultInt;
        Console.WriteLine($"The result of the sum: {Convert.ToString((int)(result), 2)}.{FPTBS(result - Math.Truncate(result))}");
    }
    public override void Mult(Binary1 binary1)
    {
        int int1 = Convert.ToInt32(integerPart, 2);
        int int2 = Convert.ToInt32(binary1.integerPart, 2);
        double frac1 = Convert.ToInt32(fractionalPart, 2) / Math.Pow(2, fractionalPart.Length);
        double frac2 = Convert.ToInt32(binary1.fractionalPart, 2) / Math.Pow(2, binary1.fractionalPart.Length);

        double num1 = int1 + frac1;
        double num2 = int2 + frac2;

        double result = num1 * num2;
        int resultInt = (int)Math.Truncate(result);
        double resultFrac = result - resultInt;
        Console.WriteLine($"The result of the multiplication: {Convert.ToString((int)(result), 2)}.{FPTBS(result - Math.Truncate(result))}");
    }
    private static string FPTBS (double number)
    {
        StringBuilder binaryString = new StringBuilder();
        int precision = 3;
        while (number > 0 && precision > 0)
        {
            number *= 2;
            if (number >= 1)
            {
                binaryString.Append("1");
                number -= 1;
            }
            else
            {
                binaryString.Append("0");
            }
            precision--;
        }
        return binaryString.ToString();
    }
}