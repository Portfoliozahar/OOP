using Interfaces;

namespace HomeWork005;

public class WorkerWithFile : IWorkerWithFile
{
    public string FileRead(string path)
    {
        using(StreamReader reader = new StreamReader(path)){
            string? line;
            string result = string.Empty;
            while((line = reader.ReadLine()) != null) result += line + "\n";
            return result;
        }
    }

    public void FileWrite(string text, string path)
    {
        using(StreamWriter writer = new StreamWriter(path)){
            writer.Write(text);
        }
    }
}