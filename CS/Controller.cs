using task001;

namespace Task001
{
    public class Controller
    {
        public static void Run()
        {
            string pathRead = "Data\\input.txt";
            string pathWrite = "Data\\output.txt";
            int [] numbers = new int [2];
            MathOperations operations = new MathOperations();
            WorkWithFile file = new WorkWithFile();
            WorkWithString forString = new WorkWithString();
            numbers = forString.Parse(file.ReadFile(pathRead));
            string result = Convert.ToString(operations.exponentiation(numbers[0], numbers[1]));
            result = (result != "-1") ? result : "Произошло переполнение";
            file.WriteFile(pathWrite, result);
        }
    }

}