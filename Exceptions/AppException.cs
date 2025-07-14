// Exceptions/AppException.cs
using System.Globalization;

namespace SistemaCadastroDeHorasApi.Exception;

public class AppException : System.Exception
{
    public AppException() : base() { }

    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}