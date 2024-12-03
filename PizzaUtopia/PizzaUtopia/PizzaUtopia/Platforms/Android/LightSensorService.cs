using Android.Content;
using Android.Hardware;
using Microsoft.Maui.Controls;
using YourAppNamespace.Droid;
using System;

[assembly: Dependency(typeof(LightSensorService))]
namespace YourAppNamespace.Droid
{
    public class LightSensorService : Java.Lang.Object, ILightSensorService, ISensorEventListener
    {
        private SensorManager _sensorManager;
        private Sensor _lightSensor;

        public event EventHandler<float> LightSensorChanged;

        public LightSensorService()
        {
            _sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
            _lightSensor = _sensorManager.GetDefaultSensor(SensorType.Light);
        }

        public void StartListening()
        {
            if (_lightSensor != null)
            {
                _sensorManager.RegisterListener(this, _lightSensor, SensorDelay.Normal);
            }
        }

        public void StopListening()
        {
            _sensorManager.UnregisterListener(this);
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if (e.Sensor.Type == SensorType.Light)
            {
                float lightLevel = e.Values[0];
                LightSensorChanged?.Invoke(this, lightLevel);
            }
        }

        public void OnAccuracyChanged(Sensor sensor, [Android.Runtime.GeneratedEnum] SensorStatus accuracy)
        {
            // Można zostawić puste
        }
    }
}
