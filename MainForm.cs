namespace TimeCalculator;

public partial class MainForm : Form
{
    private int _totalMinutes = 0;
    private readonly List<(int minutes, bool isSubtract)> _history = new();

    public MainForm()
    {
        InitializeComponent();
        inputTextBox.KeyDown += InputTextBox_KeyDown;
    }

    private void InputTextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
            case Keys.Add:                        // numpad +
            case Keys.Oemplus when e.Shift:       // main keyboard Shift+=
                ProcessInput();
                e.Handled = true;
                e.SuppressKeyPress = true;
                break;

            case Keys.Escape:
            case Keys.C when string.IsNullOrEmpty(inputTextBox.Text):
                ClearAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
                break;

            case Keys.Back when string.IsNullOrEmpty(inputTextBox.Text):
                UndoLastEntry();
                e.Handled = true;
                e.SuppressKeyPress = true;
                break;
        }
    }

    private void ProcessInput()
    {
        string input = inputTextBox.Text.Trim();
        if (string.IsNullOrEmpty(input))
            return;

        if (!TimeParser.TryParse(input, out int minutes, out bool isSubtract))
        {
            System.Media.SystemSounds.Beep.Play();
            return;
        }

        // Apply to running total
        if (isSubtract)
            _totalMinutes -= minutes;
        else
            _totalMinutes += minutes;

        // Add to history
        _history.Add((minutes, isSubtract));

        // Update UI
        UpdateHistoryDisplay();
        UpdateTotalDisplay();
        inputTextBox.Clear();
    }

    private void ClearAll()
    {
        _totalMinutes = 0;
        _history.Clear();
        historyTextBox.Clear();
        inputTextBox.Clear();
        UpdateTotalDisplay();
    }

    private void UndoLastEntry()
    {
        if (_history.Count == 0)
            return;

        var (minutes, isSubtract) = _history[^1];
        _history.RemoveAt(_history.Count - 1);

        // Reverse the operation
        if (isSubtract)
            _totalMinutes += minutes;
        else
            _totalMinutes -= minutes;

        UpdateHistoryDisplay();
        UpdateTotalDisplay();
    }

    private void UpdateHistoryDisplay()
    {
        var lines = new List<string>();
        for (int i = 0; i < _history.Count; i++)
        {
            var (minutes, isSubtract) = _history[i];
            string formatted = TimeParser.Format(minutes);

            if (i == 0)
            {
                // First entry: show with sign only if subtract
                lines.Add(isSubtract ? $"- {formatted}" : $"  {formatted}");
            }
            else
            {
                // Subsequent entries: show with +/- prefix
                lines.Add(isSubtract ? $"- {formatted}" : $"+ {formatted}");
            }
        }
        historyTextBox.Text = string.Join(Environment.NewLine, lines);

        // Scroll to bottom
        historyTextBox.SelectionStart = historyTextBox.Text.Length;
        historyTextBox.ScrollToCaret();
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        BeginInvoke(() => inputTextBox.Focus());
    }

    private void UpdateTotalDisplay()
    {
        totalLabel.Text = $"Total: {TimeParser.Format(_totalMinutes)}";
    }
}
