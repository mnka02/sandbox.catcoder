namespace toolbox.Observables; 

public interface IPublisher <TContext> {

    public void Subscribe (ISubscriber <TContext> subscriber);
    public void Unsubscribe (ISubscriber <TContext> subscriber);
    public void NotifySubscribers (TContext context);
}