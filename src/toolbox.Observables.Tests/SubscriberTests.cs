using Moq;
using Xunit;


namespace toolbox.Observables.Tests; 

public class SubscriberTests {

    // -- test setup
    private ISubscriber <string> testObject;
    
    // -- test cases
    [Fact]
    public void Notify_ExpectCallbackAfterNotification() {

        bool callbackWasCalled = false;

        this.testObject = new Subscriber <string>(context => callbackWasCalled = true);
        this.testObject.Notify("Hello, World");
        
        Assert.True(callbackWasCalled);
        
    }
}