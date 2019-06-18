using static System.Console;

namespace A14
{
    /// <summary>
    /// Accumulate Class for accumulating the entered digits and making a whole number 
    /// </summary>
    public class AccumulateState : CalculatorState
    {
        /// <summary>
        /// AccumulateState Class Constructor
        /// </summary>
        /// <param name="calc"></param>
        public AccumulateState(Calculator calc) : base(calc) { }

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
            return new AccumulateState(this.Calc);
        }

        /// <summary>
        /// EnterOperator Method for changing the state to computing state
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c) => new ComputeState(this.Calc).EnterOperator(c);

        /// <summary>
        /// EnterPoint Method for changing the state to the point state
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint() => new PointState(this.Calc).EnterPoint();


    }
}