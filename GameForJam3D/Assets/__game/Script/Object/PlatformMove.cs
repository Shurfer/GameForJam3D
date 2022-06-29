using DG.Tweening;
using UnityEngine;

public class PlatformMove : MonoBehaviour, ITouchable
{
    [SerializeField] bool stop;

    public void Touch()
    {
        if (!stop)
        {
            MovePlatform();
            Destroy(gameObject, 5);
        }
    }

    void MovePlatform()
    {
        transform.DOMove(transform.position - new Vector3(0, 10, 0), 2).SetEase(Ease.Linear);
    }
}