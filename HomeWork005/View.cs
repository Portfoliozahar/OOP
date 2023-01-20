using Interfaces;

namespace HomeWork005;

public class View : IView
{
    public void ShowError()
    {
        Console.WriteLine("Вы ввели некоректные данные");
    }

    public void ShowText(string text)
    {
        Console.WriteLine(text);
    }
}