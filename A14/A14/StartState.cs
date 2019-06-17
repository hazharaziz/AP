using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }

        public override IState EnterEqual() => 
            ProcessOperator(new ComputeState(this.Calc));

        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }

        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }

        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}