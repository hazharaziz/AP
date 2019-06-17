using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A14
{
    public class Calculator
    {
        public Calculator(Action clearScreen)
        {
            this.State = new StartState(this);
            this.ClearScreen = clearScreen;
        }

        public static readonly Dictionary<char, Func<double, double, double>> Operators =
            new Dictionary<char, Func<double, double, double>>()
            {
                ['+'] = (x, y) => x + y,
                ['-'] = (x, y) => x - y,
                ['/'] = (x, y) => x / y,
                ['*'] = (x, y) => x * y
            };

        public void PrintDisplay()
        {
            this.ClearScreen();
            Console.Write(this.Display);
        }

        public string Display { get; set; } = "0";
        public double Accumulation { get; set; }
        public char? PendingOperator { get; set; } = null;
        public IState State { get; protected set; }
        public Action ClearScreen { get; }

        public void Evalute()
        {
            Accumulation = PendingOperator.HasValue ? 
                    Operators[PendingOperator.Value](Accumulation, double.Parse(Display)) :
                    double.Parse(Display);
        }

        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
            Thread.Sleep(500);
        }

        public void UpdateDisplay() => Display = Accumulation.ToString();
        public void EnterPoint() => State = State.EnterPoint();

        public void EnterZeroDigit() => State = State.EnterZeroDigit();
        public void EnterNonZeroDigit(char c) => State = State.EnterNonZeroDigit(c);

        public void EnterOperator(char op)
        {
            State = State.EnterOperator(op);
            PendingOperator = op;
        }

        public void EnterEqual() => State = State.EnterEqual();

        public void Clear()
        {
            Accumulation = 0;
            State = new StartState(this);
            PendingOperator = null;
            Display = "0";
        }
    }
}
