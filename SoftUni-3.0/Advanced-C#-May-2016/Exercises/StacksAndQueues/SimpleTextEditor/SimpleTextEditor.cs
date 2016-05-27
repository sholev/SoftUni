using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var commandNumber = int.Parse(Console.ReadLine());
            var textHistory = new Stack<string>();

            textHistory.Push(string.Empty);
            for (int i = 0; i < commandNumber; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (int.Parse(parameters[0]))
                {
                    case 1:
                        var textToAppend = parameters[1];
                        var currentText = textHistory.Peek();
                        currentText += textToAppend;
                        textHistory.Push(currentText);
                        break;
                    case 2:
                        var elementsToRemove = int.Parse(parameters[1]);
                        currentText = textHistory.Peek();
                        currentText = currentText.Remove(currentText.Length - elementsToRemove, elementsToRemove);
                        textHistory.Push(currentText);
                        break;
                    case 3:
                        var elementToReturn = int.Parse(parameters[1]);
                        currentText = textHistory.Peek();
                        Console.WriteLine(currentText[elementToReturn - 1]);
                        break;
                    case 4:
                        textHistory.Pop();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
