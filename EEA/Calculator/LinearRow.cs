namespace EEA.Calculator;

public sealed record class LinearRow(int Remainder, int Factor1, int Quotient1, int Factor2, int Quotient2) : IRow
{
    public LinearRow(Row row) : this(row.Remainder, 1, row.Result, -row.Quotient, row.Value)
    {
    }

    public override string ToString() => $"{Remainder} = {(Factor1 is not 1 ? $"{Factor1} * " : "")}{Quotient1} {Helper.Sign(Factor2)} {Math.Abs(Factor2)} * {Quotient2}";
}
