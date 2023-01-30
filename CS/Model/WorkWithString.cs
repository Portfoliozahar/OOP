namespace Task001
{
    public class WorkWithString{
        public int [] Parse(string text){
           string [] temp = text.Split(":");
           int [] numbers = new int [2];
           foreach (string item in temp)
           {
                if (item.StartsWith("a")) numbers[0] = Convert.ToInt32(item.Split(" ")[1]);
                if (item.StartsWith("b")) numbers[1] = Convert.ToInt32(item.Split(" ")[1]);
           }
           return numbers;
        }
    }
}