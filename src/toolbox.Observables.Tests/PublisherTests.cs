using Moq;
using Xunit;


namespace toolbox.Observables.Tests; 

public class PublisherTests {
    
    // -- test setup
    private readonly Publisher <string> testObject = new();
    
    
    // -- test cases
    [Fact]
    public void Subscribe_ExpectUniqueEntries() {

        var mockedSubscribers = Enumerable.Range(0, 2)
            .Select(i => new Mock <ISubscriber <string>>())
            .ToList();
        
        mockedSubscribers
            .ForEach(mocked => this.testObject.Subscribe(mocked.Object));
        
        this.testObject.NotifySubscribers("Hello, World!");
        mockedSubscribers
            .ForEach(mocked => mocked.Verify(
                sub => sub.Notify(It.IsAny<string>()), Times.Once()));
    }

    [Fact]
    public void Subscribe_ExpectFailureDueCommonEntries() {
        
        var mockedSubscribers = Enumerable.Range(0, 2)
            .Select(i => new Mock <ISubscriber <string>>())
            .ToList();
        
        mockedSubscribers
            .ForEach(mocked => this.testObject.Subscribe(mocked.Object));
        // break integrity of subscriber list
        this.testObject.Subscribe(mockedSubscribers.First().Object);
        
        this.testObject.NotifySubscribers("Hello, World!");
        mockedSubscribers
            .ForEach(mocked => mocked.Verify(
                sub => sub.Notify(It.IsAny<string>()), Times.Exactly(1)));
    }
    
    
    
    
}