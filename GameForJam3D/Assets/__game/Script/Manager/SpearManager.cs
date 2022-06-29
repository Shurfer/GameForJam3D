using System.Collections;
using UnityEngine;

public class SpearManager : MonoBehaviour
{
    [SerializeField] Spear[] spearLeft;
    [SerializeField] Spear[] spearRight;
    private int spearCountLeft;
    int spearCountRight;

    private void Start()
    {
        spearCountLeft = spearLeft.Length-1;
        spearCountRight= spearRight.Length-1;
    }

    public void ActivateSpear()
    {
        StartCoroutine(leftActivate());
        StartCoroutine(rightActivate());
    }

    IEnumerator leftActivate()
    {
        yield return new WaitForSeconds(0.05f);
        spearLeft[spearCountLeft].Activate(1);
        spearCountLeft--;
        if (spearCountLeft >= 0)
            StartCoroutine(leftActivate());
    }

    IEnumerator rightActivate()
    {
        yield return new WaitForSeconds(0.05f);
        spearRight[spearCountRight].Activate(-1);
        spearCountRight--;
        if (spearCountRight >= 0)
            StartCoroutine(rightActivate());
    }
}