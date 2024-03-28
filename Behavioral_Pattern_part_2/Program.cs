using MementoPatternClasses;

namespace MementoPatternMain
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            Caretaker caretaker = new Caretaker();

            editor.Text = "First Line";
            caretaker.AddMemento(editor.Save());

            editor.Text = "Second Line";
            caretaker.AddMemento(editor.Save());

            editor.Text = "Third Line";

            editor.Restore(caretaker.GetMemento());
        }
    }
}