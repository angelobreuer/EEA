namespace EEA.Pages;

using EEA.Calculator;

public partial class Index
{
    private int _x = 99;
    private int _y = 78;

    private Row[]? _basicRows;
    private IRow[]? _advancedRows;

    public int X
    {
        get => _x;

        set
        {
            _x = value;
            Changed();
        }
    }

    public int Y
    {
        get => _y;

        set
        {
            _y = value;
            Changed();
        }
    }

    private void Changed()
    {
        _basicRows = EEACalculator.Compute(X, Y).ToArray();
        _advancedRows = EEACalculator.ComputeAdvanced(_basicRows).ToArray();
        StateHasChanged();
    }
}
