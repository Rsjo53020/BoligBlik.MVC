namespace BoligBlik.Domain.Exceptions;

public class BookingIsOverlappingException : Exception
{
  public BookingIsOverlappingException(string message) : base(message) { }
}