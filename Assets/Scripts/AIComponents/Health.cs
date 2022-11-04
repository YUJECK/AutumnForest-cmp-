using System.Collections;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth = 30;
    [SerializeField] private int maxHealth = 30;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public UnityEvent onDie = new UnityEvent();
    public UnityEvent<int, int> onHealthChange = new UnityEvent<int, int>();

    private void Start() { if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>(); }

    public void Destroy() => Destroy(gameObject);
    public void Instiate(GameObject obj) => Instantiate(obj, transform.position, Quaternion.identity);
    public void TakeHit(int hit)
    {
        currentHealth -= hit;
        StartCoroutine(Vizualization(Color.red));

        if (currentHealth <= 0)
            onDie.Invoke();

        onHealthChange.Invoke(currentHealth, maxHealth);
    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        StartCoroutine(Vizualization(Color.green));

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        onHealthChange.Invoke(currentHealth, maxHealth);
    }
    private IEnumerator Vizualization(Color color)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }
}