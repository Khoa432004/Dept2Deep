using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage { get; private set; }
    public float AttackRange { get; private set; }
    public float AttackSpeed { get; private set; }
    public string ItemName { get; private set; }
    public Sprite ItemSprite { get; private set; }
    public Player Owner { get; private set; }

    // Khởi tạo vũ khí
    public void Initialize(string name, Sprite image, int damage, float attackRange, float attackSpeed)
    {
        ItemName = name;
        ItemSprite = image;
        Damage = damage;
        AttackRange = attackRange;
        AttackSpeed = attackSpeed;

        // Cấu hình SpriteRenderer nếu cần
        var spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        spriteRenderer.sprite = ItemSprite;
    }

    public void Equip(Player player)
    {
        // Nếu đã có chủ sở hữu, gỡ bỏ vũ khí khỏi người đó
        if (Owner != null)
        {
            Unequip();
        }

        Owner = player;
        Owner.IncreaseDamage(Damage);
        Owner.IncreaseAttackRange(AttackRange);
        Owner.IncreaseAttackSpeed(AttackSpeed);
        Debug.Log($"Weapon '{ItemName}' equipped by {Owner.name}");
    }

    public void Unequip()
    {
        if (Owner != null)
        {
            Owner.DecreaseDamage(Damage);
            Owner.DecreaseAttackRange(AttackRange);
            Owner.DecreaseAttackSpeed(AttackSpeed);
            Debug.Log($"Weapon '{ItemName}' unequipped from {Owner.name}");
            Owner = null;
        }
    }
}
