using System.Collections.ObjectModel;

namespace SpotifyClone
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Track> RecentTracks
        {
            get; set;
        }
        public ObservableCollection<Playlist> Playlists
        {
            get; set;
        }
        public Track CurrentTrack
        {
            get; set;
        }

        public MainPage()
        {
            InitializeComponent();
            InitializeData();
            BindingContext = this;
        }

        private void InitializeData()
        {
            RecentTracks = new ObservableCollection<Track>
            {
                new Track { Title = "Song 1", Artist = "Artist 1", AlbumArt = "album1.jpg" },
                new Track { Title = "Song 2", Artist = "Artist 2", AlbumArt = "album2.jpg" },
                // Add more tracks
            };

            Playlists = new ObservableCollection<Playlist>
            {
                new Playlist { Name = "Top Hits", Description = "Popular right now", PlaylistArt = "playlist1.jpg" },
                new Playlist { Name = "Chill Mix", Description = "Relaxing tunes", PlaylistArt = "playlist2.jpg" },
                // Add more playlists
            };

            CurrentTrack = RecentTracks [0];

            RecentlyPlayedList.ItemsSource = RecentTracks;
            PopularPlaylists.ItemsSource = Playlists;
        }

        private async void OnSongSelected(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection.FirstOrDefault() is Track track)
            {
                CurrentTrack = track;
                await Navigation.PushAsync(new NowPlayingPage(track));
            }
        }

        private async void OnPlaylistSelected(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection.FirstOrDefault() is Playlist selectedPlaylist)
            {
                // Clear the selection
                ((CollectionView)sender).SelectedItem = null;

                // Show a message or navigate to playlist details
                await DisplayAlert("Playlist Selected", $"Opening playlist: {selectedPlaylist.Name}", "OK");

                // Here you could navigate to a playlist detail page:
                // await Navigation.PushAsync(new PlaylistDetailPage(selectedPlaylist));
            }
        }

        private void OnPlayPauseClicked(object sender, EventArgs e)
        {
            // Toggle playback
        }
    }

    public class Track
    {
        public string Title
        {
            get; set;
        }
        public string Artist
        {
            get; set;
        }
        public string AlbumArt
        {
            get; set;
        }
    }

    public class Playlist
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public string PlaylistArt
        {
            get; set;
        }
    }
}