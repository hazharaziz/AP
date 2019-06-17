using System;
namespace A14
{
    /// <summary>
    ///  این کلاس وضعیت مادر است 
    ///  برای هر وضعیتی اگر یکی از 
    ///  Event ها
    ///  مثلا
    ///  EnterEqual/...
    ///  را 
    ///  override
    ///  نکنیم به طور پیش فرض کاری انجام نمیدهد و در وضعیت فعلی باقی میماند.
    ///  #6 لطفا!
    /// </summary>
    public abstract class CalculatorState : IState
    {
        public Calculator Calc { get;  }
        public CalculatorState(Calculator calc) => this.Calc = calc;
        public virtual IState EnterEqual() => null;
        public virtual IState EnterZeroDigit() => null;
        public virtual IState EnterNonZeroDigit(char c) => null;        
        public virtual IState EnterOperator(char c) => null;
        public virtual IState EnterPoint() => null;

        protected IState ProcessOperator(IState nextState, char? op = null)
        {
            try
            {
                this.Calc.Evalute();
                this.Calc.UpdateDisplay();
                this.Calc.PendingOperator = op;
                return nextState;
            }
            catch (Exception e)
            {
                this.Calc.DisplayError(e.Message);
                return new ErrorState(this.Calc);
            }
        }
    }
}