namespace CleanArchDemo.Domain.ValueObjects;

public record Quantity
{

    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Quantity must be greater than zero");
            _value = value;
        }
    }




    public override string ToString() => _value.ToString();
}

