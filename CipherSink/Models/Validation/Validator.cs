using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CipherSink.Models.Validation;

/// <summary>
/// This class is used to validate various inputs and conditions within the CipherSink application
/// </summary>
public static class Validator
{
    /// <summary>
    /// Validates if the provided username is in a valid format.
    /// A username is considered valid if it is alphanumeric and between 1 and 32 characters long.
    /// </summary>
    /// <param name="username">The username to check</param>
    /// <returns>True if the provided username is valid; otherwise false.</returns>
    public static bool IsValidUsername(string username)
    {
        if (!Regex.IsMatch(username, @"^[A-Za-z0-9]+$"))
        { 
            return false; // Invalid username format
        }
        
        if (username.Length < 1 || username.Length > 32)
        {
            return false; // Username length is invalid
        }

        return true; // Username is valid
    }

    /// <summary>
    /// Validates if the provided password is in a valid format.
    /// A password is considered valid if it is alphanumeric and between 4 and 32 characters long.
    /// </summary>
    /// <param name="password">The password to check</param>
    /// <returns>True if the provided password is valid; otherwise fasle.</returns>
    public static bool IsValidPassword(string password) 
    {
        if (!Regex.IsMatch(password, @"^[A-Za-z0-9]+$"))
        {
            return false; // Invalid password format
        }

        if (password.Length < 4 || password.Length > 32)
        {
            return false; // Password length is invalid
        }

        return true; // Password is valid
    }

    public static bool IsValidGamePin(string gamePin)
    {
        if (!Regex.IsMatch(gamePin, @"^[A-Za-z0-9]+$"))
        {
            return false; // Game PIN must be alphanumeric
        }
        
        if (gamePin.Length < 4 || gamePin.Length > 32)
        {
            return false; // Game PIN must be between 4 and 32 characters
        }
        
        return true; // Game PIN is valid
    }

    /// <summary>
    /// Validates if the provided byte array is a valid RSA public key.
    /// </summary>
    /// <param name="keyBytes">Byte array to check</param>
    /// <returns>True if bytes are a valid RSA public key; otherwise false.</returns>
    public static bool IsValidRSAPublicKey(byte[] keyBytes)
    {
        try
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(new ReadOnlySpan<byte>(keyBytes), out _);
                rsa.Clear(); // Clear the RSA object to release resources
                return true;
            }
        }
        catch (CryptographicException)
        {
            return false;
        }
    }

    /// <summary>
    /// Validates if the provided byte array is a valid RSA private key.
    /// </summary>
    /// <param name="keyBytes">Byte array to check</param>
    /// <returns>True if bytes are a valid RSA private key; otherwise false.</returns>
    public static bool IsValidRSAPrivateKey(byte[] keyBytes)
    {
        try
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(new ReadOnlySpan<byte>(keyBytes), out _);
                rsa.Clear(); // Clear the RSA object to release resources
                return true;
            }
        }
        catch (CryptographicException)
        {
            return false;
        }
    }

    public static bool IsValidHostIp(string hostIp)
    {
        return IPAddress.TryParse(hostIp, out _);
    }
}
