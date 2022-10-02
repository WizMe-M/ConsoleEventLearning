using ConsoleEventLearning.Navigation.Event;

namespace ConsoleEventLearning.Navigation;

public class ContentPage : IContentPage
{
    public string RouteUrl { get; }

    public ContentPage(string routeUrl) => RouteUrl = routeUrl;

    public override string ToString() => $"page({RouteUrl})";
}