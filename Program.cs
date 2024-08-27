Console.WriteLine("🔢 Welcome to the Number Guessing Game!❓");
int level = GetValidIntegerInput(@"What difficulty level do you want?
1. Easy (8 Chances)
2. Medium (6 Chances)
3. Hard (4 Chances)", 1, 3);

int maxTries;
switch (level)
{
    case 1:
        maxTries = 8;
        break;
    case 2:
        maxTries = 6;
        break;
    case 3:
        maxTries = 4;
        break;  
    default:
        throw new ArgumentOutOfRangeException();  
}

Random random = new Random();
int secretNumber = random.Next(1, 101);
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
        // Provide hints only if there are remaining chances
        if (tries < maxTries)
        {
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
            Console.WriteLine($"You have {maxTries - tries} {(maxTries - tries > 1 ? "chances" : "chance")} left.");

        }
    }
}

// If the guess was never correct
if (!isCorrect)
{
    Console.WriteLine($"🔚 Out of attempts! The secret number was {secretNumber}. Better luck next time!");
}

int GetValidIntegerInput(string prompt, int? min = null, int? max = null)
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
            if (min != null && min !=null)
            {
                if (int.Parse(input) >= min && int.Parse(input) <= 3)
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("❌ Invalid input. Please enter a number between 1 and 3.");
                }
            }
            else
            {
                return int.Parse(input);

            }
        }
        catch (FormatException)
        {
            Console.WriteLine("❌ Invalid input. Please enter a valid integer.");
        }
    }
}