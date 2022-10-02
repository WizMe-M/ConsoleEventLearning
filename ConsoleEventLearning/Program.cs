using ConsoleEventLearning.Navigation;
using ConsoleEventLearning.Navigation.Event;

Console.WriteLine("Program starts...");
Task.Delay(1000);

using (var navView = new NavigationView())
{
    // pop
    var sender = "sender 1";
    var e = NavigatedEventArgs.Pop();
    navView.Navigator.RaiseNavigated(sender, e);

    // push
    sender = "sender 2";
    e = NavigatedEventArgs.Push(new ContentPage("/some/route?i=1"));
    navView.Navigator.RaiseNavigated(sender, e);

    // push
    e = NavigatedEventArgs.Push(new ContentPage("/some/route?i=2"));
    navView.Navigator.RaiseNavigated(sender, e);

    // push
    e = NavigatedEventArgs.Push(new ContentPage("/some/route?i=3"));
    navView.Navigator.RaiseNavigated(sender, e);
    
    // replace
    sender = "sender 3";
    e = NavigatedEventArgs.ReplaceLast(new ContentPage("/another_route"));
    navView.Navigator.RaiseNavigated(sender, e);

    // pop
    sender = "sender 4";
    e = NavigatedEventArgs.Pop();
    navView.Navigator.RaiseNavigated(sender, e);

    // clear
    sender = "sender 5";
    e = NavigatedEventArgs.ClearAndPush(new ContentPage("/the_only_route"));
    navView.Navigator.RaiseNavigated(sender, e);
}

Console.WriteLine("Program ends...");