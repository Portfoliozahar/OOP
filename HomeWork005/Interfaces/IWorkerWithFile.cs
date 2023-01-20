namespace Interfaces;

public interface IWorkerWithFile{
    public string FileRead(string path);

    public void FileWrite(string text, string path);
}