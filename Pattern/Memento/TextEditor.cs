using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternClasses
{
    public class TextEditor
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Console.WriteLine($"Current Text: {_text}");
            }
        }

        public Memento Save()
        {
            return new Memento(_text);
        }

        public void Restore(Memento memento)
        {
            _text = memento.Text;
            Console.WriteLine($"Restored Text: {_text}");
        }
    }

    public class Memento
    {
        public string Text { get; }

        public Memento(string text)
        {
            Text = text;
        }
    }

    public class Caretaker
    {
        private readonly Stack<Memento> _mementos = new Stack<Memento>();

        public void AddMemento(Memento memento)
        {
            _mementos.Push(memento);
        }

        public Memento GetMemento()
        {
            if (_mementos.Count == 0)
            {
                throw new InvalidOperationException("No mementos available");
            }

            return _mementos.Pop();
        }
    }
}