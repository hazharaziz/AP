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
        /// <summary>
        /// PointState Class for initializing the Point state
        /// </summary>
        /// <param name="calc"></param>
        public PointState(Calculator calc) : base(calc) { }


        public override IState EnterEqual() => null;

        /// <summary>
        /// EnterZeroDigit Method adds a zero to the display 
        /// </summary>
        /// <returns></returns>
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');

        /// <summary>
        /// EnterNonZeroDigit Method adds a character to the display
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += c.ToString();
            return new PointState(this.Calc);
        }

        /// <summary>
        /// EnterOperator Method for processing the c operator 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c)
        {
            return Operation(c);
        }

        /// <summary>
        /// Operation Method for calculating the result using the c operator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private IState Operation(char c)
        {
            var accumulation = Calc.Accumulation.ToString();
            var display = Calc.Display;
            Calc.Display = Calc.Display.Substring(accumulation.Length, display.Length - accumulation.Length);
            var result = new PointState(Calc).ProcessOperator(new ComputeState(Calc), c);
            return result;
        }

        /// <summary>
        /// EnterPoint Method for adding the point to the display
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            if (!this.Calc.Display.Contains("."))
            {
                this.Calc.Display += ".";
                return new PointState(this.Calc);
            }
            else
                return new PointState(this.Calc);
        }





    }
}