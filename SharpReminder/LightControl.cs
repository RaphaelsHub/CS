namespace SharpReminder;

public class LightControl
{
    public TrafficLights Light = TrafficLights.Red;

    public void SwitchLight(TrafficLights light)
    {
        this.Light = light;
        ResetLight();
    }

    public void ResetLight(TrafficLights light = TrafficLights.Red)
    {
        Console.WriteLine(this.Light);
        this.Light = light;
        Console.WriteLine(this.Light);
        LightNext();
    }

    public void LightNext()
    {
        Light= (this.Light == TrafficLights.Red) ? TrafficLights.Green : (TrafficLights)(((int)Light+1) % 3); 
    
        if (Light != TrafficLights.Red)
        {
            LightNext();
        }
    }
}