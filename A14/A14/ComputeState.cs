using System;

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
            {
                int[] numbers = Array.ConvertAll(Calc.Display.Split('+'), int.Parse);
                int result = 0;
                foreach (int i in numbers)
                    result += i;
                Calc.Display = $"{result}";
                return new ComputeState(Calc);
            }
            return new ComputeState(Calc);

            //Calc.DisplayError("Syntax Error");
            //return new ErrorState(this.Calc);
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