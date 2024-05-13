using BoligBlik.Domain.Exceptions;
using BoligBlik.Domain.Shared;
using System;

namespace BoligBlik.Domain.Value;

public record BookingDates(DateOnly creationDate, DateTime startTime, DateTime endTime) : ValueWithValidation
{
    protected override void Validate()
    {
        if (startTime < endTime) throw new InvalidEndTimeException("Start time must be before End time");
    }
}