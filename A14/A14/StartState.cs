using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        /// <summary>
        /// StartState Class Constructor for initializing the calculator
        /// </summary>
        /// <param name="calc"></param>
        public StartState(Calculator calc) : base(calc) { }

        /// <summary>
        /// EnterEqual Method for calculating the final result 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// EnterOperator Method for entering a new operator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => 
            ProcessOperator(new ComputeState(this.Calc), c);

        /// <summary>
        /// EnterPoint Method for switching to the point state
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}