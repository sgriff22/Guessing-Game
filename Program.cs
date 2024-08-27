Console.WriteLine("🔢 Welcome to the Number Guessing Game!❓");

const int secretNumber = 42;
   
int guess = GetValidIntegerInput("Guess a Secret number ");

if (guess == secretNumber)
{
    Console.WriteLine("🎉 Congratulations! You guessed the correct number!");
}
else
{
    Console.WriteLine("😢 Sorry, that's not the correct number. Try again!"); 
}


int GetValidIntegerInput(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        // Take the user's guess as input
        string? input = Console.ReadLine();

        // Handle null input by setting to an empty string
        input ??= string.Empty;

        try
        {
            return int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Invalid input. Please enter a valid integer.");
        }
    }
}