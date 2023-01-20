using Interfaces;

namespace HomeWork005;


public class Controller{
    Model model;
    IView view;
    IWorkerWithFile file;

    Path path;

    public Controller(Model model, IView view, IWorkerWithFile file, Path path){
        this.model = model;
        this.view = view;
        this.file = file;
        this.path = path;
    }


    public void Start(){
        string pathOutPut = path.PathOutPut;
        string pathInPut = path.PathInPut;
        view.ShowText($"файл содержащий исходные данные\n {pathOutPut}");
        view.ShowText($"файл в который будут записаны результаты\n {pathInPut}");
        view.ShowText($"Начало расчета");

        string data = file.FileRead(pathOutPut);
        string result = model.getResult(data);
        view.ShowText($"исходное уровнение {result}");
        file.FileWrite(result, pathInPut);
    }


}