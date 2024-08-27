Console.WriteLine("🔢 Welcome to the Number Guessing Game!❓");

Random random = new Random();
int secretNumber = random.Next(1, 101);
int maxTries = 4;
int tries = 0;
bool isCorrect = false;

while (tries < maxTries && !isCorrect)
{
    int guess = GetValidIntegerInput("Guess a Secret number ");
    tries++;
    if (guess == secretNumber)
    {
        Console.WriteLine("🎉 Congratulations! You guessed the correct number!");
        isCorrect = true;
    }
    else
    {
        Console.WriteLine("😢 Sorry, that's not the correct number."); 
        // Display a message indicating if the guess is too high or too low
        if (guess < secretNumber)
        {
            Console.WriteLine("⬆️ Your guess is too low. Try a higher number!");
        }
        else
        {
            Console.WriteLine("⬇️ Your guess is too high. Try a lower number!");
        }

        // Show remaining attempts
        if (tries < maxTries)
        {
            Console.WriteLine($"You have {maxTries - tries} {(maxTries - tries > 1 ? "chances" : "chance")} left.");
        }
    }
}

// If the guess was never correct
if (!isCorrect)
{
    Console.WriteLine($"🔚 Out of attempts! The secret number was {secretNumber}. Better luck next time!");
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