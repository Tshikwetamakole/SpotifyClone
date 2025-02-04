namespace SpotifyClone
{
    public partial class NowPlayingPage : ContentPage
    {
        public Track CurrentTrack
        {
            get; set;
        }
        public double Progress
        {
            get; set;
        }

        public NowPlayingPage(Track track)
        {
            InitializeComponent();
            CurrentTrack = track;
            Progress = 0;
            BindingContext = this;
        }

        private async void OnMinimizeClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            // Handle previous track
        }

        private void OnPlayPauseClicked(object sender, EventArgs e)
        {
            // Toggle playback
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            // Handle next track
        }
    }
}