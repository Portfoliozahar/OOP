
namespace task001
{
    public class WorkWithFile{

        public string ReadFile(string path){
            string text = string.Empty;
            using (StreamReader reader = new StreamReader(path)){
                string? line;
                while((line = reader.ReadLine()) != null){
                    if (line.StartsWith("a") || line.StartsWith("b")) text += $"{line}:";
                }
                Console.WriteLine(text);
            }
            return text;

        }

        public void WriteFile(string path, string text){
            using (StreamWriter writer = new StreamWriter(path)){
                writer.WriteLine(text);
            }
        }
    }
}