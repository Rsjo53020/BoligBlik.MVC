namespace BoligBlik.Domain.Shared;

public abstract record ValueWithValidation
{
    protected ValueWithValidation()
    {
        Validate();
    }

    protected virtual void Validate()
    {
    }
}