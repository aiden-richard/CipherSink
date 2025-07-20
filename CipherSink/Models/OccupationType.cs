// use Description attribute on enum values, if we need to print
// the grid, these will be used. Might be useful for debugging
using System.ComponentModel;

namespace CipherSink.Models;

/// <summary>
/// Enumeration representing the occupation type of a cell in the grid.
/// For now it only has three values: Empty, Hit, and Miss. Once Ships are implemented,
/// we can add more values to this enum.
/// </summary>
public enum  OccupationType
{
    [Description("o")]
    Empty,

    [Description("X")]
    Hit,
    
    [Description("M")]
    Miss
}