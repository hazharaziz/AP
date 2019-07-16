namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #2 لطفا!
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual() => null;
        public override IState EnterNonZeroDigit(char c) => null;
        public override IState EnterZeroDigit() => null;
        public override IState EnterOperator(char c) => this;
        public override IState EnterPoint() => null;
    }
}