namespace EEA.Calculator;
public readonly record struct Row(int Result, int Quotient, int Value, int Remainder) : IRow
{
    public override string ToString()
    {
        return $"{Result} = {Quotient} * {Value} {Helper.Sign(Remainder)} {Math.Abs(Remainder)}";
    }

    public string GetLinear()
    {
        return $"{Remainder} = {Result} {Helper.Sign(-Quotient)} {Math.Abs(Quotient)} * {Value}";
    }
}
