namespace toolbox.Observables; 

public class Publisher <TContext> : IPublisher <TContext> {

    private readonly HashSet <ISubscriber <TContext>> subscribers;
    private TContext? mainState;
    
    // -- constructors
    public Publisher()
        => this.subscribers = new();

    public Publisher (ISubscriber <TContext> subscriber)
        => this.subscribers = new() {subscriber};

    public Publisher (ICollection <ISubscriber <TContext>> subscribers)
        => this.subscribers = new(subscribers);
    
    // -- implemented interfaces 
    public void Subscribe (ISubscriber <TContext> subscriber)
        => this.subscribers.Add(subscriber);

    public void Unsubscribe (ISubscriber <TContext> subscriber)
        => this.subscribers.Remove(subscriber);

    public void NotifySubscribers (TContext context) {
        this.mainState = context;
        this.subscribers
            .ToList()
            .ForEach(subscriber => subscriber.Notify(this.mainState));
    }
}