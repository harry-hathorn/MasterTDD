using FluentAssertions;

namespace MasterTDD.Day1
{
    public class FibonacciShould
    {
        [Fact]
        public void Return_0_When_Given0()
        {
            int result = Calculator.Fibonacci(0);
            result.Should().Be(0);
        }

        [Fact]
        public void Return_1_When_Given1()
        {
            int result = Calculator.Fibonacci(1);
            result.Should().Be(1);
        }

        [Fact]
        public void Return_1_When_Given2()
        {
            int result = Calculator.Fibonacci(2);
            result.Should().Be(1);
        }

        [Fact]
        public void Return_2_When_Given3()
        {
            int result = Calculator.Fibonacci(3);
            result.Should().Be(2);
        }

        [Fact]
        public void Return_3_When_Given4()
        {
            int result = Calculator.Fibonacci(4);
            result.Should().Be(3);
        }

        [Fact]
        public void Return_5_When_Given5()
        {
            int result = Calculator.Fibonacci(5);
            result.Should().Be(5);
        }

        [Fact]
        public void Return_8_When_Given6()
        {
            int result = Calculator.Fibonacci(6);
            result.Should().Be(8);
        }

        [Fact]
        public void Return_13_When_Given7()
        {
            int result = Calculator.Fibonacci(7);
            result.Should().Be(13);
        }

        [Fact]
        public void Return_21_When_Given8()
        {
            int result = Calculator.Fibonacci(8);
            result.Should().Be(21);
        }

        [Fact]
        public void Return_34_When_Given9()
        {
            int result = Calculator.Fibonacci(9);
            result.Should().Be(34);
        }
        [Fact]
        public void Return_2584_When_Given18()
        {
            int result = Calculator.Fibonacci(18);
            result.Should().Be(2584);
        }
        [Fact]
        public void Return_4181_When_Given19()
        {
            int result = Calculator.Fibonacci(19);
            result.Should().Be(4181);
        }
    }

    internal class Calculator
    {
        internal static int Fibonacci(int value)
        {
            int result = value;

            if (value > 4)
            {
                result = Fibonacci(value - 1) + Fibonacci(value - 2);
            }
            else if (value > 1)
            {
                result = value - 1;
            }

            return result;
        }
    }
}
