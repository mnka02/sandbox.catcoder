using System.Runtime.CompilerServices;
using Xunit;
namespace toolbox.DiscriminatedUnions.Tests; 

public class DiscriminatablesTests {
    
    // -- test object
    private IDiscriminatable <double, Exception>? testObject;
    
    // -- test setup
    private bool wasHandledAsValue = false;

    private void HandleAsValue (double value)
        => this.wasHandledAsValue = true;

    private void HandleAsError (Exception exception)
        => this.wasHandledAsValue = false;

    public DiscriminatablesTests() {
        this.wasHandledAsValue = false;
    }

    // -- test cases    
    [Fact]
    public void ExpectHandledAsValue() {
        this.testObject = new DiscriminatedUnion <double, Exception> (11.07);
        this.testObject
            .Then((double test) => this.wasHandledAsValue = true)
            .Then((Exception exc) =>  this.wasHandledAsValue = false);
        Assert.True(wasHandledAsValue);
    }

    [Fact]
    public void ExpectHandledAsError() {
        this.testObject = new DiscriminatedUnion <double, Exception> (new Exception("Linz"));
        this.testObject
            .Then((Exception exc) => this.wasHandledAsValue = false)
            .Then((double test) => this.wasHandledAsValue = true);
        Assert.False(wasHandledAsValue);
    }
}