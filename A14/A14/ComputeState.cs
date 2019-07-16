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
        /// <summary>
        /// ComputeState Class Construtor initializing the computing state
        /// </summary>
        /// <param name="calc"></param>
        public ComputeState(Calculator calc) : base(calc) { }

        /// <summary>
        /// EnterEqual Method for calculating the final result
        /// </summary>
        /// <returns></returns>
        public override IState EnterEqual()
            => Calc.PendingOperator != null ? Operation() : new ErrorState(this.Calc);

        /// <summary>
        /// Operation Method for processing the operation with the c operator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private IState Operation(char? c = null)
        {
            var accumulation = Calc.Accumulation.ToString();
            var display = Calc.Display;
            Calc.Display = Calc.Display.Substring(accumulation.Length, display.Length - accumulation.Length);
            var result = new ComputeState(Calc).ProcessOperator(new ComputeState(Calc),c);
            return result;
        }

        public override IState EnterNonZeroDigit(char c)
        {
            Calc.Display += c;
            return new ComputeState(this.Calc);
        }

        public override IState EnterZeroDigit()
        {
            this.Calc.Display += "0";
            return new ComputeState(this.Calc);
        }
        
        /// <summary>
        /// EnterOperator Method for entering a new operator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public override IState EnterOperator(char c)
            => Calc.PendingOperator != null ? Operation()
            : new ComputeState(Calc).ProcessOperator(new ComputeState(Calc), c);


        /// <summary>
        /// EnterPoint Method for switching to the point state
        /// </summary>
        /// <returns></returns>
        public override IState EnterPoint()
        {
            if (Calc.Display != null)
            {
                var result = Operation(Calc.PendingOperator);
                Calc.Display += ".";
                return result;
            }
            else
            {
                Calc.Display = "0.";
                return new PointState(Calc);
            }
        }

    }

}
