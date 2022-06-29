
using UnityEngine;

public class TabletArtefact : Artefact
{
    [SerializeField] private GameObject boss;
    
    public override void Touch()
    {
        boss.SetActive(true);
        base.Touch();
    }
}
