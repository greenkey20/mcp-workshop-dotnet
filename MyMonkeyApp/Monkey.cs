/// <summary>
/// Represents a monkey with its characteristics and location information.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location where this monkey species is found.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the population count of this monkey species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets additional details about the monkey species.
    /// </summary>
    public string Details { get; set; } = string.Empty;
}