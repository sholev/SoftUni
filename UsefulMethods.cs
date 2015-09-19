class UsefulSnippets
{

    // Bit Manipulation

    private static long GetBitAtPosition(long number, int position)
    {
        return (number >> position) & 1L;
    }

    private static long SetBitAtPosition(long number, int position, long setBitTo)
    {
        if (setBitTo == 1)
            return number | (1L << position);
        else
            return number & ~(1L << position);
    }

    private static int InvertBitAtPosition (int number, int position)
	{
		return number ^ (1 << position);
	}

	private static int GetThreeBitsAtPosition(long number, int position)
	{
		return (int)(number >> position) & 7; // 7 is 0111 mask
	}

	// Collection manupulation
	
	// http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
	List<int> numbers = new List<int>();
	//fill in the list
    Random rng = new Random();
	var randomNumbers = numbers.OrderBy(a => rng.Next());

	//String manipulation
	
	// Check if string contains only allowed characters
	// http://stackoverflow.com/questions/3293295/string-contains-only-a-given-set-of-characters
	private static bool isHex(string inputStr)
	{
		string allowedChars = "0123456789ABCDEF";

		// .NET 2
		//foreach (var chr in inputStr) 
		//{
		//    if (!allowedChars.Contains(chr.ToString())) 
		//    {
		//        return true;
		//    }
		//}

		//return false;

		// LINQ - .NET 3.5
		return inputStr.ToUpper().All(c => allowedChars.Contains(c)); 
		
	}
	
	// Reverse a string
	// http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
	string input = "Reverse this.";
	char[] forReverse = input.ToCharArray();
	Array.Reverse(forReverse);
	string reversed = new string(forReverse);
	
	// Links

    // Bit Operations
	// http://stackoverflow.com/questions/3587826/is-there-a-built-in-function-to-reverse-bit-order

	// Big numbers:
	// https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.aspx
	// http://stackoverflow.com/questions/2863388/what-is-the-equivalent-of-the-java-bigdecimal-class-in-c

	// Useful links:
	// http://stackoverflow.com/questions/18459307/how-to-use-math-functions-with-biginteger-and-bigrational
	// http://referencesource.microsoft.com/
}