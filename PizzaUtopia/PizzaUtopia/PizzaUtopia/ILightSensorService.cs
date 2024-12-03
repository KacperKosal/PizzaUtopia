public interface ILightSensorService
{
    void StartListening();
    void StopListening();
    event EventHandler<float> LightSensorChanged;
}
