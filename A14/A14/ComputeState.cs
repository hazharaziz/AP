using System;
using System.Collections.Generic;
using System.Linq;

namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    
    
    public enum OperatorType { Sum,Multiply,Divide,Power,Point,Equal};

    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        public override IState EnterEqual()
        {
            if (Calc.Display.Contains("+"))
                return SumOperation(OperatorType.Equal);
            else if (Calc.Display.Contains("*"))
                return MultiplyOperation(OperatorType.Equal);
            else if (Calc.Display.Contains('.'))
            {
                return new ComputeState(Calc);
            }
            else
            {
                Calc.DisplayError("Syntax Error");
                return new ErrorState(this.Calc);

            }
        }

        private IState MultiplyOperation(OperatorType t)
        {
            if (t == OperatorType.Equal)
                return Multiply('=');
            else if (t == OperatorType.Sum)
                return Multiply('+');
            else if (t == OperatorType.Multiply)
                return Multiply('*');
            else if (t == OperatorType.Divide)
                return Multiply('/');
            else if (t == OperatorType.Power)
                return Multiply('^');
            else
                return Multiply('.');
        }

        private IState Multiply(char c)
        {
            List<int> numbers = Array.ConvertAll(Calc.Display.Split('*'), int.Parse).OfType<int>().ToList();
            double result = 1;
            foreach (int number in numbers)
                result *= number;
            if (c == '=')
                Calc.Display = $"{result}";
            else
                Calc.Display = $"{result}{c}";
            return new ComputeState(Calc);
        }

    

    
        private IState SumOperation(OperatorType t)
        {
            if (t == OperatorType.Equal)
                return Sum('=');
            else if (t == OperatorType.Sum)
                return Sum('+');
            else if (t == OperatorType.Multiply)
                return Sum('*');
            else if (t == OperatorType.Divide)
                return Sum('/');
            else if (t == OperatorType.Power)
                return Sum('^');
            else
                return Sum('.');
        }

        private IState Sum(char c)
        {
            List<int> numbers = Array.ConvertAll(Calc.Display.Split('+'), int.Parse).OfType<int>().ToList();
            if (c == '=')
                Calc.Display = $"{numbers.Sum()}";
            else
                Calc.Display = $"{numbers.Sum()}{c}";
            return new ComputeState(Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display += c;
            return new ComputeState(this.Calc);
        }

        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            this.Calc.Display += "0";
            return new ComputeState(this.Calc);
        }

        // #5 لطفا
        public override IState EnterOperator(char c)
        {
            if (Calc.Display.Contains('+'))
                return SumOperation(OperatorType.Sum);
            else if (Calc.Display.Contains('*'))
                return MultiplyOperation(OperatorType.Multiply);
            else
            {
                Calc.Display += c;
                return new ComputeState(Calc);
            }
        }

        public override IState EnterPoint()
        {
            if (Calc.Display == null || Calc.Display == string.Empty)
            {
                Calc.Display = "0.";
                return new PointState(Calc);
            }
            else if (Calc.Display.Contains('+'))
                return SumOperation(OperatorType.Point);
            else if (Calc.Display.Contains('*'))
                return MultiplyOperation(OperatorType.Multiply);
            else
            {
                Calc.Display += ".";
                return new ComputeState(this.Calc);
            }
        }

    }
}