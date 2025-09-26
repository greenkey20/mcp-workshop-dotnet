/// <summary>
/// Represents a monkey with its basic information
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the location where the monkey is found
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the population count of this monkey species
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets additional details about the monkey
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Returns a string representation of the monkey
    /// </summary>
    /// <returns>A formatted string with monkey information</returns>
    public override string ToString()
    {
        return $"{Name} - {Location} (Population: {Population:N0})";
    }
}