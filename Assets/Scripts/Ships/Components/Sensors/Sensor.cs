public class Sensor : ShipComponent
{
    protected float range = -1;
    public SensorParameters Parameters
    {
        set
        {
            if (value != null)
            {
                range = value.Range;
                signature = value.Signature;
            }
        }
    }
}
