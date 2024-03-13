/* Author: Zachary Walker
* Course: COMP-003A-L01
* Purpose: Code for Final
*/
namespace COMP003A.Final
{
    /// This program collects information and asks questions to build a dating profile
    class Program
    {
        /// <summary>
        /// Stores questions in a dictionary data structure along with the answers for each question. 
        /// Each question is associated with whatever is answered for that question.
        /// </summary>
        static Dictionary<int, string> questionnaire = new Dictionary<int, string>
        {
            { 1, "What's your idea of a perfect date?" },
            { 2, "If you could have dinner with any three people, dead or alive, who would they be and why?" },
            { 3, "What's a book, movie, or TV show that left a lasting impression on you?" },
            { 4, "What's your favorite way to spend a lazy Sunday afternoon?" },
            { 5, "If you could travel anywhere in the world, where would you go first and why?" },
            { 6, "What's a skill or hobby you've always wanted to learn but haven't had the chance to yet?" },
            { 7, "What's your favorite type of music, and do you have a go-to song that always puts you in a good mood?" },
            { 8, "Are you more of a city explorer or a nature enthusiast?" },
            { 9, "What's the most adventurous thing you've ever done or would like to do?" },
            { 10, "If you had to describe yourself in three words, what would they be?" }
        };

        static void Main(string[] args)
        {
            // User Input Section
            string divisionLine = new string('*', 50); // Division Line init
            Console.WriteLine(divisionLine);
            string firstName = GetUserInput("Enter First Name: ");
            string lastName = GetUserInput("Enter Last Name: ");
            int birthYear = GetBirthYear();
            char gender = GetGender();
            Dictionary<int, string> questionnaireResponses = GetQuestionnaireResponses(); // Prompts each question so the dictionary can be filled with the responses

            // Profile Summary Section
            Console.Write("\n");
            Console.WriteLine(divisionLine);
            Console.WriteLine("Profile Summary:");
            Console.WriteLine($"Full Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetGenderDescription(gender)}");
            Console.WriteLine(divisionLine);

            Console.WriteLine("\nQuestionnaire Responses: \n ");
            Console.WriteLine(divisionLine);
            foreach (var question in questionnaire)
            {
                Console.WriteLine($"Question {question.Key}: {question.Value}"); // Question number is stated with the question
                Console.Write("Answer: ");
                Console.WriteLine(questionnaireResponses[question.Key]);
                Console.WriteLine(); // Add a new line for better readability
            }

        }

        /// <summary>
        /// Gets user input with a specified prompt and validates for null/empty/numeric/special characters.
        /// </summary>
        /// <param name="prompt">The prompt message for the user.</param>
        /// <returns>Validated user input.</returns>
        static string GetUserInput(string prompt)
        {
            string userInput;
            bool isValidInput = false;

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput) || !userInput.All(char.IsLetter))
                {
                    Console.WriteLine("Invalid input. Please enter a valid value for the name.");
                }
                else
                {
                    isValidInput = true;
                }

            } while (!isValidInput);

            return userInput; // Code is worried about possible null, seems to work fine though and puts out error if null or blank
        }

        /// <summary>
        /// Gets and validates the user's birth year.
        /// </summary>
        /// <returns>Validated birth year.</returns>
        static int GetBirthYear()
        {
            int currentYear = DateTime.Now.Year;
            int birthYear;
            bool isValidInput = false;

            do
            {
                Console.Write("Enter Birth Year: ");

                if (int.TryParse(Console.ReadLine(), out birthYear) && birthYear >= 1900 && birthYear <= currentYear) // Try to parse user input into an integer using the "out" parameter
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid birth year. Please enter a valid year.");
                }
            } while (!isValidInput);

            return birthYear;
        }

        /// <summary>
        /// Gets and validates the user's gender.
        /// </summary>
        /// <returns>Validated gender.</returns>
        static char GetGender()
        {
            char gender;
            bool isValidInput = false;

            do
            {
                Console.Write("Enter Gender (M/F/O): ");
                gender = Char.ToUpper(Console.ReadKey().KeyChar);

                if (gender == 'M' || gender == 'F' || gender == 'O')
                {
                    Console.WriteLine(); // Move to the next line after user input
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid gender. Please enter M, F, or O.");
                }
            } while (!isValidInput); // Checks for valid input instead of infinite loop

            return gender;
        }

        /// <summary>
        /// Gets responses to a questionnaire.
        /// </summary>
        /// <returns>Array of user responses to the questionnaire.</returns>
        static Dictionary<int, string> GetQuestionnaireResponses()
        {
            string divisionLine = new string('*', 50); // Re-declare the divisionLine string so it can be used
            Console.WriteLine(divisionLine);
            Console.WriteLine("\nQuestionnaire:");

            Dictionary<int, string> responses = new Dictionary<int, string>();

            foreach (var question in questionnaire)
            {
                Console.Write($"{question.Key}. {question.Value}\n");

                string response;
                bool isValidInput = false;

                do
                {
                    response = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        Console.WriteLine("Invalid input. Please provide a response.");
                        Console.Write($"{question.Key}. ");
                    }
                    else
                    {
                        isValidInput = true;
                    }

                } while (!isValidInput);

                responses.Add(question.Key, response); // Also trippin about null here but I cannot find any way to break it
            }

            return responses;
        }

        /// <summary>
        /// States the full description of the gender based on user input
        /// </summary>
        /// <param name="gender">The gender code (M/F/O).</param>
        /// <returns>Full gender description.</returns>
        static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other";
                default:
                    return "Unknown"; // Necessary return statement even though it is unreachable, handles error.
                                      // Could just make it default to "Other" in case of error but would rather see that there is an issue
            }
        }
    }
}