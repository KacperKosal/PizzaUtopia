using Plugin.Maui.Biometric;

namespace PizzaUtopia
{
    public partial class MainPage : ContentPage
    {
        private ILightSensorService _lightSensorService;

        public MainPage()
        {
            InitializeComponent();
            _lightSensorService = DependencyService.Get<ILightSensorService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_lightSensorService != null)
            {
                _lightSensorService.LightSensorChanged += OnLightSensorChanged;
                _lightSensorService.StartListening();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (_lightSensorService != null)
            {
                _lightSensorService.LightSensorChanged -= OnLightSensorChanged;
                _lightSensorService.StopListening();
            }
        }

        private void OnLightSensorChanged(object sender, float lightLevel)
        {
            // Przykład reakcji na zmianę światła
            if (lightLevel < 10)
            {
                Application.Current.UserAppTheme = AppTheme.Dark; // Zmiana na ciemny motyw
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light; // Zmiana na jasny motyw
            }
        }
    }


}
