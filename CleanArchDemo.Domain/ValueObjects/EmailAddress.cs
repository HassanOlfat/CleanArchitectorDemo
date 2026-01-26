namespace CleanArchDemo.Domain.ValueObjects;

public record EmailAddress
{
    public string? Value { set; get; }



    public override string ToString() =>string.IsNullOrEmpty( Value)?string.Empty: Value;
}