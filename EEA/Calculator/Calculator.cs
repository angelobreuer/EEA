namespace EEA.Calculator;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static partial class EEACalculator
{
    public static IEnumerable<Row> Compute(int x, int y)
    {
        // x >= y
        (x, y) = (Math.Max(x, y), Math.Min(x, y));

        static Row Compute(int x, int y) // x >= y
        {
            var (quotient, remainder) = Math.DivRem(x, y);
            return new Row(x, quotient, y, remainder);
        }

        var row = Compute(x, y);
        yield return row;

        while (row.Remainder is not 0)
        {
            yield return row = Compute(row.Value, row.Remainder);
        }
    }

    public static IEnumerable<IRow> ComputeAdvanced(IEnumerable<Row> rows)
    {
        // a = b * q + r
        using var enumerator = rows.Reverse().Skip(1).GetEnumerator();

        var result = enumerator.MoveNext();
        Debug.Assert(result);

        var remainder = enumerator.Current.Remainder;
        var linearRow = new LinearRow(enumerator.Current);

        yield return linearRow;

        while (enumerator.MoveNext())
        {
            var mutatingRow = new LinearRow(enumerator.Current);

            yield return new IntegratingRow(
                Row: linearRow,
                IntegratorRow: mutatingRow);

            yield return new IntegratedRow(
                Remainder: remainder,
                Factor1: linearRow.Factor1,
                Quotient1: linearRow.Quotient1,
                Factor2: mutatingRow.Factor1 * linearRow.Factor2,
                Quotient2: mutatingRow.Quotient1,
                Factor3: mutatingRow.Factor2 * linearRow.Factor2,
                Quotient3: mutatingRow.Quotient2);

            Debug.Assert(linearRow.Quotient1 == mutatingRow.Quotient2);

            yield return linearRow = new LinearRow(
                Remainder: remainder,
                Factor1: mutatingRow.Factor1 * linearRow.Factor2,
                Quotient1: mutatingRow.Quotient1,
                Factor2: mutatingRow.Factor2 * linearRow.Factor2 + linearRow.Factor1,
                Quotient2: mutatingRow.Quotient2);
        }
    }
}
