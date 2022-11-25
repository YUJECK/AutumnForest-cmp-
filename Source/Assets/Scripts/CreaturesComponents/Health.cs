using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    //health indicators
    [SerializeField] protected int currentHealth = 60;
    [SerializeField] protected int maximumHealth = 60;
    [Space]
    //events
    public UnityEvent<int, int> onHealthChange = new UnityEvent<int, int>();
    public UnityEvent<int, int> onHeal = new UnityEvent<int, int>();
    public UnityEvent<int, int> onTakeHit = new UnityEvent<int, int>();
    //getters
    public int CurrentHealth => currentHealth;
    public int MaximumHealth => maximumHealth;

    //abstract methods
    public abstract void TakeHit(int damagePoints);
    public abstract void Heal(int healPoints);
    public abstract void DecreaseMaximumHealth(int damagePoints);
    public abstract void IncreaseMaximumHealth(int healPoints);
}