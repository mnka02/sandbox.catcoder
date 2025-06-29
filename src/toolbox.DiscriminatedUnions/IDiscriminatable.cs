namespace toolbox.DiscriminatedUnions; 

public interface IDiscriminatable <TOne, TTwo> {

    public IDiscriminatable <TOne, TTwo> Then (Action <TOne> action);
    public IDiscriminatable <TOne, TTwo> Then (Action <TTwo> action);
}

public interface IDiscriminatable <TOne, TTwo, TThree> {

    public IDiscriminatable <TOne, TTwo, TThree> Then (Action <TOne> action);
    public IDiscriminatable <TOne, TTwo, TThree> Then (Action <TTwo> action);
    public IDiscriminatable <TOne, TTwo, TThree> Then (Action <TThree> action);
}