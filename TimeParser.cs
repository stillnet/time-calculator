namespace TimeCalculator;

public static class TimeParser
{
    /// <summary>
    /// Parses a time string in HHMM format (no colon).
    /// Last 2 digits are minutes, everything before is hours.
    /// Supports optional +/- prefix.
    /// </summary>
    /// <param name="input">Input string like "120", "-45", "+30"</param>
    /// <param name="totalMinutes">Parsed value in total minutes</param>
    /// <param name="isSubtract">True if the value should be subtracted</param>
    /// <returns>True if parsing succeeded</returns>
    public static bool TryParse(string input, out int totalMinutes, out bool isSubtract)
    {
        totalMinutes = 0;
        isSubtract = false;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        input = input.Trim();

        // Handle +/- prefix
        if (input.StartsWith('-'))
        {
            isSubtract = true;
            input = input[1..];
        }
        else if (input.StartsWith('+'))
        {
            input = input[1..];
        }

        if (!int.TryParse(input, out int value) || value < 0)
            return false;

        // Last 2 digits are minutes, everything before is hours
        int minutes = value % 100;
        int hours = value / 100;

        // Validate minutes (0-59)
        if (minutes >= 60)
            return false;

        totalMinutes = hours * 60 + minutes;
        return true;
    }

    /// <summary>
    /// Formats total minutes as H:MM string.
    /// </summary>
    public static string Format(int totalMinutes)
    {
        bool negative = totalMinutes < 0;
        int absMinutes = Math.Abs(totalMinutes);
        int hours = absMinutes / 60;
        int mins = absMinutes % 60;

        string formatted = $"{hours}:{mins:D2}";
        return negative ? $"-{formatted}" : formatted;
    }
}
