using System;
using System.Collections.Generic;
using System.Linq;

namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }

        public override IState EnterEqual()
        {
            if (Calc.Display.Contains("+"))
                return SumOperation();
            else if (Calc.Display.Contains("*"))
                return MultiplyOperation();
            
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        private IState MultiplyOperation()
        {
            List<int> numbers = Array.ConvertAll(Calc.Display.Split('*'), int.Parse).OfType<int>().ToList();
            double result = 1;
            foreach (int number in numbers)
                result *= number;
            Calc.Display = $"{result}";
            return new ComputeState(Calc);

        }

        private IState SumOperation()
        {
            List<int> numbers = Array.ConvertAll(Calc.Display.Split('+'), int.Parse).OfType<int>().ToList();
            Calc.Display = $"{numbers.Sum()}";
            return new ComputeState(Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            // #3 لطفا!
            this.Calc.Display += c;
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
            this.Calc.Display += c;
            return new ComputeState(this.Calc);
        }

        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}