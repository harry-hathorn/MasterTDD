public interface IRandomGenerator { 
	int GetRandomBetween1And100(); 
} 

public class RandomGenerator : IRandomGenerator 
{ 
	private static Random _random = new Random(); 

	public int GetRandomBetween1And100() { 
		return _random.Next(1, 101); // Returns a random number between 1 and 100 
	}
}

Odd or Even Detector
Your task is to implement a class OddOrEvenDetector with a method bool IsRandomNumberOdd(). 
The method should return true if the random number is odd and false if it is even.

Use the RandomGenerator class's method GetBetween1And100() to generate the random number.
Follow TDD practices: start by writing a failing test, then implement the code to make the test pass, and finally, refactor if necessary.