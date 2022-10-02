using ConsoleEventLearning.Navigation.Event;
using ConsoleEventLearning.Navigation.Stack;

namespace ConsoleEventLearning.Navigation;

/// <summary>
/// Represents navigation event subscriber 
/// </summary>
public class NavigationView : IDisposable
{
    private readonly NavigationStack _stack;
    public NavigationPublisher Navigator { get; }

    public NavigationView()
    {
        _stack = new NavigationStack(new ContentPage("/home"));
        Navigator = new NavigationPublisher();
        Navigator.Navigated += OnNavigated;
    }

    private void OnNavigated(object sender, NavigatedEventArgs args)
    {
        try
        {
            _stack.HandleNavigation(args);
        }
        catch (NavigationStackException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Caught exception {nameof(e)}");
            Console.WriteLine(e.Message);
            Console.ResetColor();
        }

        Console.WriteLine($">sender Navigated from sender: {sender}");
        Console.WriteLine($">e Navigation strategy is {args.NavigationStrategy}");
        Console.WriteLine($">e Content page is {args.ContentPage}");
        Console.WriteLine($"Current page is {_stack.Current}");
        Console.WriteLine("Current stack is: ");
        foreach (var page in _stack.Enumerate())
            Console.WriteLine(page);
        Console.WriteLine();
    }

    public void Dispose()
    {
        // не забываем отписаться
        Navigator.Navigated -= OnNavigated;
        GC.SuppressFinalize(this);
    }
}