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
            Calc.DisplayError("Syntax Error");
            return new ErrorState(this.Calc);
        }

        public override IState EnterNonZeroDigit(char c)
        {
            // #3 لطفا!
            return null;
        }

        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            return null;
        }

        // #5 لطفا
        public override IState EnterOperator(char c)
        {
            return new ComputeState(this.Calc);
        }

        public override IState EnterPoint()
        {
            Calc.Display = "0.";
            return new PointState(this.Calc);
        }

    }
}