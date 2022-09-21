namespace EEA.Calculator;
public sealed record class IntegratingRow(LinearRow Row, LinearRow IntegratorRow) : IRow
{
    public int Result => Row.Quotient1;

    public override string ToString() => $"{Row.Remainder} = {(Row.Factor1 is not 1 ? $"{Row.Factor1} * " : "")}{Row.Quotient1} {Helper.Sign(Row.Factor2)} {Math.Abs(Row.Factor2)} * ({(IntegratorRow.Factor1 is not 1 ? $"{IntegratorRow.Factor1} * " : "")}{IntegratorRow.Quotient1} {Helper.Sign(IntegratorRow.Factor2)} {Math.Abs(IntegratorRow.Factor2)} * {IntegratorRow.Quotient2})";
}
