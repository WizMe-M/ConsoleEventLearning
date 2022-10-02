namespace ConsoleEventLearning.Navigation.Event;

public class NavigationPublisher
{
    public delegate void NavigatedEventHandler(object sender, NavigatedEventArgs args);
    
    public event NavigatedEventHandler Navigated = delegate { };

    public void RaiseNavigated(object sender, NavigatedEventArgs args) => Navigated(sender, args);
}