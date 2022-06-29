using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] int health;
    [SerializeField] Hand Hand;

    [SerializeField] private GameObject player;

    bool boss;

    PlayerUI PlayerUI;
    InputManager InputManager;

    // в скрипте FirstPersonController звук прыжка

    private void Start()
    {
        InputManager = GetComponent<InputManager>();
        PlayerUI = GetComponent<PlayerUI>();
        PlayerUI.ChangeHealthText(health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ITouchable touchable))
            touchable.Touch();

        if (other.TryGetComponent(out IUseable useable))
        {
            PlayerUI.CanInteractWithObject(true);
            InputManager.UseableObject(useable);
        }

        if (other.TryGetComponent(out ITakeable takeable))
        {
            if (!Hand.ObjectInHand())
            {
                PlayerUI.CanInteractWithObject(true);
                Hand.ObjectMayCatch(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IUseable useble))
        {
            InputManager.UseableObjectDisable();
        }

        if (other.TryGetComponent(out ITakeable takeable))
        {
            PlayerUI.CanInteractWithObject(false);
            Hand.ObjectCantCatch();
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        PlayerUI.ChangeHealthText(health);
        PlayerUI.DamageUIActivate();
        ScriptСontainer.soundManager.PlayerGetDamage();
        if (!boss && health <= 0)
            Death();
    }

    public int HealthFromBossAttack(int damage)
    {
        boss = true;
        GetDamage(damage);
        return health;
    }
    
    public void PlayerStanFromBoss()
    {
        transform.SetParent(null);
        player.SetActive(false);
        Hand.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Screen.lockCursor = false;
        Cursor.visible = true;
    }

    public void GetHealthUp(int healthUp)
    {
        ScriptСontainer.soundManager.PlayerHealthUp();
        health += healthUp;
        PlayerUI.ChangeHealthText(health);
        PlayerUI.HealthUIActivate();
    }

    void Death()
    {
        EventManager.SendPlayerPositionReset();
        health = 80;
        PlayerUI.ChangeHealthText(health);
        PlayerUI.DamageUIActivate();
    }
}