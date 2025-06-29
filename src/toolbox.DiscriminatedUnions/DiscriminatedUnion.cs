namespace toolbox.DiscriminatedUnions;

/// <summary>
/// Represents a discriminated union pattern implementation, enabling a value to take on one of two
/// defined, distinct types. This approach improves type safety and expressiveness when modeling
/// mutually exclusive result states or event variants.
/// </summary>
/// <typeparam name="TValue"></typeparam>
/// <typeparam name="TError"></typeparam>
public class DiscriminatedUnion <TValue, TError> : IDiscriminatable <TValue, TError> {

    private TError? error;
    private TValue? value;
    private bool isValue;

    // -- constructors
    public DiscriminatedUnion (TValue value) {
        this.value = value;
        this.isValue = true;
    }

    public DiscriminatedUnion (TError error) {
        this.error = error;
        this.isValue = false;
    }

    // -- methods
    public IDiscriminatable <TValue, TError> Then (Action <TValue> action) {
        // checking for null reference is not enough when dealing with primitive data types
        // e.g double default = 0
        if (this.value is not null && this.isValue)
            action(this.value);
        return this;
    }

    public IDiscriminatable <TValue, TError> Then (Action <TError> action) {
        if (this.error is not null && !this.isValue)
            action(this.error);
        return this;
    }

    // -- implicit operators 
    public static implicit operator DiscriminatedUnion <TValue, TError> (TValue value)
        => new(value);

    public static implicit operator DiscriminatedUnion <TValue, TError> (TError error)
        => new(error);
}