using AutumnForest;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerDash))]
public class PlayerController : MonoBehaviour
{
    //variables
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private int damage;
    [SerializeField] private float attackRate = 1f;
    public bool isStopped = false;
    private bool canAttack = true;

    //components
    [SerializeField] GameObject attackAnimation;
    private Rigidbody2D playerRigidbody;
    [SerializeField] private AreaHit areaHit;
    private Animator animator;
    private PlayerInput playerInput;
    private PlayerDash playerDash;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerDash = GetComponent<PlayerDash>();

        playerInput.OnAttackInput.AddListener(Attack);
        playerInput.OnDashInput.AddListener(playerDash.Dash);
    }

    //movement
    private void FixedUpdate()
    {
        if(!playerDash.NowDashing)
        {
            playerRigidbody.velocity = playerInput.Movement * moveSpeed;

            if (!isStopped && playerInput.Movement != Vector2.zero)
            {
                if (playerInput.Movement.x < 0 && transform.localScale.x == -1)
                    transform.localScale = new Vector3(1, 1, 1);
                if (playerInput.Movement.x > 0 && transform.localScale.x == 1)
                    transform.localScale = new Vector3(-1, 1, 1);

                animator.SetBool("IsRunning", true);
            }
            else animator.SetBool("IsRunning", false);
        }
    }
    //methods
    public void SetStop(bool active) => isStopped = active;
    private void Attack()
    {
        if (canAttack && !isStopped)
        {
            areaHit.Hit(damage);
            Instantiate(attackAnimation, areaHit.transform.position, areaHit.transform.rotation);
            StartCoroutine(AttackCulldown());
        }
        //local method
        IEnumerator AttackCulldown()
        {
            canAttack = false;
            yield return new WaitForSeconds(attackRate);
            canAttack = true;
        }
    }
}