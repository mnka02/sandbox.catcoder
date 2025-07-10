namespace toolbox.Observables; 

public class Subscriber <TContext> : ISubscriber <TContext> {
    
    private Action <TContext> callback;
    
    // -- constructors
    public Subscriber (Action <TContext> callback)
        => this.callback = callback;
    
    // -- implemented interfaces 
    public void Notify (TContext context)
        => this.callback(context);
}