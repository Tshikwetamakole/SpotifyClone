namespace SpotifyClone;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute("mainpage", typeof(Views.MainPage));
        Routing.RegisterRoute("searchpage", typeof(Views.SearchPage));
        Routing.RegisterRoute("librarypage", typeof(Views.LibraryPage));
    }
}