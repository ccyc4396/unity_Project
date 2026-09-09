using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    


    [Header("Attack details")]
    public Transform attackCheck;
    public float attackCheckRadius;
    [Header("Knockback info")]
    [SerializeField] protected Vector2 knockbackDir;
    protected bool isKnock=false;

    [Header("Collison info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    #region components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public CharacterStates states { get; private set; }
    public EntityHeathBarUI heathBarUI { get; private set; }
    public EntityFX ef { get; private set; }
    #endregion

    public int faceDir = 1;
    protected bool faceRight = true;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        states = GetComponent<CharacterStates>();
        ef = GetComponent<EntityFX>();
        heathBarUI = GetComponentInChildren<EntityHeathBarUI>();
    }

    protected virtual void Update()
    {

    }
    public virtual void Damage(int damagePower)//ÊÜ¹¥»÷
    {

        StartCoroutine(HitKnock());

        ef?.Flash();

        states.BeAttack(damagePower);


    }
    
    protected virtual IEnumerator HitKnock()//»÷ÍË
    {
        isKnock = true;
        rb.velocity = new Vector2(knockbackDir.x * -faceDir, knockbackDir.y);
        yield return new WaitForSeconds(0.07f);
        isKnock = false;
    }

    public virtual void Die()//ËÀÍöº¯Êý
    {

    }
    #region Velocity
    public void ZeroVelocity() => SetVelocity(0, 0);
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        if (isKnock) { return; }

        rb.velocity = new Vector2(xVelocity, yVelocity);
        FlipControllor(xVelocity);

    }
    #endregion

    #region Flip

    public virtual  void Flip()
    {
        faceDir *= -1;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
        heathBarUI.Flip();
    }

    public virtual  void FlipControllor(float _x)
    {
        if (_x > 0 && !faceRight || _x < 0 && faceRight)
        {
            Flip();
        }
    }
    #endregion

    #region conllison
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDdetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius); 
    }

    #endregion




}
