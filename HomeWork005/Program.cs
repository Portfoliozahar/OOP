
using Interfaces;

namespace HomeWork005;

public class Program{
    public static void Main(){
        IWorkerWithFile file = new WorkerWithFile();
        Model model = new Model();
        IView view = new View();
        Path path = new Path();

        new Controller(model, view, file, path).Start();

    }
}
