namespace A14
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        public PointState(Calculator calc) : base(calc) { }

        //#1 لطفا!
        public override IState EnterEqual() => null;
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += c.ToString();
            return new PointState(this.Calc);
        }

        public override IState EnterOperator(char c) => null;

        public override IState EnterPoint()
        {
            if (!this.Calc.Display.Contains("."))
            {
                this.Calc.Display += ".";
                return new PointState(this.Calc);
            }
            else
            {
                this.Calc.Display += string.Empty;
                return new PointState(this.Calc);
            }
        }





    }
}