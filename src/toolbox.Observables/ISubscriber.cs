namespace toolbox.Observables; 

public interface ISubscriber <TContext> {

    public void Notify (TContext context);
}