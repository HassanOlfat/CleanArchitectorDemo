namespace CleanArchDemo.Domain.ValueObjects;

public record Address
{
    public string? Street { set; get; }
    public string? City { set; get; }
    public string? PostalCode { set; get; }



    public override string ToString() => $"{Street}, {City}, {PostalCode}";
}