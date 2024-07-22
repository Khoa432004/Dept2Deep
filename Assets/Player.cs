using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public int Health;
    public int CurrentHealth;
    public int Mana;
    public int CurrentMana;
    public int ManaConsumption;
    public int Damage;
    public int Def;
    public int Crit;
    public float AttackSpeed;
    public float AttackRange;
    private Vector2 Diadiem;

    //Roll
    protected int BoostSpeed = 3;
    protected float Cd = 0.5f;
    float CurrentTime;
    bool CheckRoll = false;

    public bool IsAlive = true;

    //HP
    public HealthBar healthBar;
    public HealthBar manaBar;
    private Weapon equippedWeapon;

    void Update()
    {
        if (Health <= 0)
        {
            IsAlive = false;
        }
        else
        {
            IsAlive = true;
        }
    }

    public void MoveChar(Rigidbody2D myRigidBody2D)
    {
        if (IsAlive)
        {
            Diadiem = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Diadiem.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            myRigidBody2D.velocity = Diadiem * MovementSpeed;

            Roll();
        }
    }

    public void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CurrentTime <= 0)
        {
            MovementSpeed += BoostSpeed;
            CurrentTime = Cd;
            CheckRoll = true;
        }
        else if (CurrentTime <= 0 && CheckRoll == true)
        {
            MovementSpeed -= BoostSpeed;
            CheckRoll = false;
        }
        else
        {
            CurrentTime -= Time.deltaTime;
        }
    }

    public void IncreaseDamage(int amount)
    {
        Damage += amount;
    }

    public void IncreaseAttackRange(float amount)
    {
        AttackRange += amount;
    }

    public void IncreaseAttackSpeed(float amount)
    {
        AttackSpeed += amount;
    }

    public void DecreaseDamage(int amount)
    {
        Damage -= amount;
    }

    public void DecreaseAttackRange(float amount)
    {
        AttackRange -= amount;
    }

    public void DecreaseAttackSpeed(float amount)
    {
        AttackSpeed -= amount;
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (equippedWeapon != null)
        {
            UnequipWeapon();
        }
        equippedWeapon = weapon;
        weapon.Equip(this);
        weapon.gameObject.SetActive(true);
    }

    public void UnequipWeapon()
    {
        if (equippedWeapon != null)
        {
            equippedWeapon.Unequip();
            equippedWeapon = null;
        }
        equippedWeapon.gameObject.SetActive(false); // Vô hiệu hóa vũ khí
    }
}
