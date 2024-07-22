using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Sprite swordSprite;
    public int damage;
    public string weaponName;
    public float attackRange;
    public float attackSpeed;
    private Weapon newWeapon;

    void Start()
    {
        // Tạo một vũ khí mới
        newWeapon = CreateWeapon(weaponName, swordSprite, damage, attackRange, attackSpeed);
        // Trang bị vũ khí cho nhân vật ngay khi bắt đầu
        player.EquipWeapon(newWeapon);
    }

    void Update()
    {
        // Kiểm tra người dùng nhấn phím để trang bị vũ khí
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipWeapon();
        }
        // Kiểm tra người dùng nhấn phím để gỡ bỏ vũ khí
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipWeapon();
        }
    }

    public void EquipWeapon()
    {
        if (newWeapon != null)
        {
            player.EquipWeapon(newWeapon);
        }
    }

    public void UnequipWeapon()
    {
        if (newWeapon != null)
        {
            player.UnequipWeapon();
        }
    }

    public Weapon CreateWeapon(string name, Sprite image, int damage, float attackRange, float attackSpeed)
    {
        GameObject weaponObject = new GameObject(name);
        Weapon weapon = weaponObject.AddComponent<Weapon>();
        weapon.Initialize(name, image, damage, attackRange, attackSpeed);
        return weapon;
    }
}
