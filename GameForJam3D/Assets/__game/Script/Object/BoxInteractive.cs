
using UnityEngine;

public class BoxInteractive : MonoBehaviour, ITakeable
{
    private bool box;
    public void Take()
    {
        box = true;
    }
}
