using CipherSink.Models.GameBoard; // used for OccupationType
using System.ComponentModel; // used for DescriptionAttribute

namespace CipherSink.Helpers;

/// <summary>
/// This class provides an extension method to get the description of an OccupationType enum.
/// </summary>
internal static class OccupationTypeExtension
{
    /// <summary>
    /// This method retrieves the description of an OccupationType enum value.
    /// It uses reflection to look for a <see cref="DescriptionAttribute"/> on the enum member.
    /// If a description is found, it returns the description string.
    /// If no description attribute is present, it falls back to returning the enum member's name as a string.
    /// </summary>
    /// <param name="occupationType">The OccupationType enum value whose description is to be retrieved.</param>
    /// <returns>The description string from the DescriptionAttribute, or the enum name if no description is found.</returns>
    public static string GetDescription(OccupationType occupationType)
    {
        // Get the type of the enum
        // type will be OccupationType
        var type = occupationType.GetType();

        // Get the member information for the enum value
        // does this by finding the member that matches the enum value
        // or in other words, GetMember("Carrier") will return the member info for the Carrier enum value
        var memberInfo = type.GetMember(occupationType.ToString());

        // Check if the memberInfo array has any elements, it will be empty if the enum value is not found
        if (memberInfo.Length > 0)
        {
            // Get the DescriptionAttribute from the member's attributes
            // does this by looking for attributes of type DescriptionAttribute
            // the false is to signal that we do not want to search the base class for attributes
            // 'false' ensures we only retrieve DescriptionAttribute instances directly applied to this enum member (not inherited)
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            // If the attribute is found, return its description
            // cast attributes[0] to DescriptionAttribute to access its Description property
            // which is a string
            if (attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }

        // Fallback if no elements in memberInfo or no DescriptionAttribute found
        return occupationType.ToString();
    }
}
