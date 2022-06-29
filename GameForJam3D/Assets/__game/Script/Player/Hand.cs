using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] Transform playerTr;
    [SerializeField] BoxCollider armColl;
    [SerializeField] Transform armTr;

    Transform objCatchTr;
    BoxCollider objBoxColl;
    Rigidbody objRigid;

    IDamageable _damageable;

    bool objMayCatch;
    bool objCatch;
    bool handAttack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable _damageable))
        {
            _damageable.GetDamage(damage);
        }
    }

    public void ObjectMayCatch(Transform objectTr)
    {
        objMayCatch = true;
        objCatchTr = objectTr;
    }

    public void ObjectCantCatch()
    {
        if (!objCatch)
        {
            objMayCatch = false;
            objCatchTr = null;
        }
    }

    public bool ObjectInHand()
    {
        return objCatch;
    }

    public void CheckHandForActive() // активируется в InputManager
    {
        if (objMayCatch) // поднять
            CatchUpObject();
        else if (objCatch) // опустить
            PutDownObject();
        else // ударить
            HandAttack();
    }

    void HandAttack() // атака рукой
    {
        if (!handAttack)
        {
            handAttack = true;
            armColl.enabled = true;
            armTr.localPosition += new Vector3(0, 0, 0.5f);
            StartCoroutine(armBack());
        }
    }

    IEnumerator armBack()
    {
        yield return new WaitForSeconds(0.2f);
        armTr.localPosition -= new Vector3(0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        armColl.enabled = false;
        handAttack = false;
    }

    void CatchUpObject() // поднять объект
    {
        objMayCatch = false;
        objCatch = true;
        objCatchTr.SetParent(playerTr);
        objBoxColl = objCatchTr.gameObject.GetComponent<BoxCollider>();
        objBoxColl.enabled = false;
        if (objCatchTr.localPosition.y < 0)
            objCatchTr.localPosition = new Vector3(0.25f, 0.33f, 1.5f);
        objRigid = objCatchTr.gameObject.GetComponent<Rigidbody>();
        objRigid.useGravity = false;
        ScriptСontainer.soundManager.ObjectPickUp();
    }

    void PutDownObject() // опустить объект
    {
        objCatch = false;
        objCatchTr.parent = null;
        objBoxColl.enabled = true;
        objRigid.useGravity = true;
        objBoxColl = null;
        objRigid = null;
        ScriptСontainer.soundManager.ObjectPickOff();
    }
}