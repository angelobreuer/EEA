namespace EEA.Calculator;

public sealed record class IntegratedRow(int Remainder, int Factor1, int Quotient1, int Factor2, int Quotient2, int Factor3, int Quotient3) : IRow
{
    public override string ToString() => $"{Remainder} = {(Factor1 is not 1 ? $"{Factor1} * " : "")}{Quotient1} {Helper.Sign(Factor2)} {Math.Abs(Factor2)} * {Quotient2} {Helper.Sign(Factor3)} {Math.Abs(Factor3)} * {Quotient3}";
}
