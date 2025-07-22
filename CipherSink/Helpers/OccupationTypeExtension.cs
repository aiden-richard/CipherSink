using CipherSink.Models;
using System.ComponentModel;

namespace CipherSink.Helpers;

internal static class OccupationTypeExtension
{
    public static string GetDescription(OccupationType occupationType)
    {
        var type = occupationType.GetType();
        var memberInfo = type.GetMember(occupationType.ToString());
        if (memberInfo.Length > 0)
        {
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }
        return occupationType.ToString(); // Fallback to the enum name if no description is found
    }
}
