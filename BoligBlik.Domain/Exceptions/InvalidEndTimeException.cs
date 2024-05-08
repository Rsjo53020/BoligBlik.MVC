namespace BoligBlik.Domain.Exceptions;

public class InvalidEndTimeException : Exception
{
  public InvalidEndTimeException(string message) : base(message) { }
  
}