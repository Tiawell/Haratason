using UnityEngine;

public class TestButtonsFunc: MonoBehaviour
{
    public Resource _health;
    public ResourceContainer _card;
    public int _damage;
    public void DealDamage()
    {
        _card.Add(_health, -_damage);
    }
    public void RestoreHealth()
    {
        _card.ToStartingValues(_health);
    }
}
