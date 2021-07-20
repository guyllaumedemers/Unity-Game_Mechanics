public class InputKey
{
    public string key { get; private set; }
    public float timeRegistered { get; private set; }

    public InputKey(string key, float time)
    {
        this.key = key;
        this.timeRegistered = time;
    }
}
