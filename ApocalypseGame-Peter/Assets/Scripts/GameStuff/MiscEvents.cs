using System;

public class MiscEvents
{
    public event Action onMatsCollected;

    public void MatCollected()
    {
        if (onMatsCollected != null)
        {
            onMatsCollected();
        }
    }

}
