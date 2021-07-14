using System.Collections;
using UnityEngine;

/// <summary>
/// @Author: Gonzalo Moreno Prat
/// </summary>
public class Player : MonoBehaviour ,ICollector , IHittable
{
    public float baseSpeed = 7f;
    public float baseJumpForce = 15f;
    public bool isGrounded;
    public bool canAttack;
    public bool shieldOn = false;
    public float shieldTime = 10f;
    public GameObject prefabShield;
    public Collider AttackRange;
    public float life = 5;
    int _maxLifes = 5;
    public bool invencibility = false;
    public Vector3 normalScale = new Vector3(1, 1, 1);
    public Vector3 smashedScale = new Vector3(1, 0.1f, 1);
    public int apples = 0;
    float canAttackTimer = 0f;
    PlayerController _control;
    Movement _movement;
    BattleMechanics _battleMechanics;
    CheckpointMananger _checkpointMananger;
    SoundMananger _soundMananger;
    AnimatorMananger _animatorMananger;
    public AudioClip[] ClipsAudio;

    private void Start()
    {
        _movement = new Movement(this);
        _battleMechanics = new BattleMechanics(this);
        _checkpointMananger = new CheckpointMananger(this);
        _soundMananger = new SoundMananger(this);
        _animatorMananger = new AnimatorMananger(this);
        _control = new PlayerController(this, _movement, _battleMechanics, _checkpointMananger, _soundMananger, _animatorMananger);
        SaveCheckPoint();
    }

    private void Update()
    {
        _control.OnUpdate();

        if (canAttackTimer <= 0) { canAttack = true; AttackRange.enabled = false; }
            canAttackTimer -= Time.deltaTime;
    }

    #region Properties
    public bool IsGrounded{
        get {return isGrounded; }
        set {isGrounded = value; } 
    }

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }
    #endregion
    public void ResetTimerAttack()
    {
        canAttackTimer = 0.6f;

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") { IsGrounded = true; }
    }

    public void GetHit(float damage)
    {
        if (shieldOn) return;
        _soundMananger.SoundPlay((int)2);
        if (life <= 0)
        {
            _animatorMananger.Die();
            this.enabled = false;
        }
        if (!invencibility) life -= damage;
        StartCoroutine(Invencibility(1f));
        _animatorMananger.GetHit();

    }

    public IEnumerator GetSmashedAndLoadCheckAfterSeconds(float seconds)
    {
        _soundMananger.SoundPlay((int)2);
        RemoveShield();
        if (!invencibility) life -= 1;
        StartCoroutine(Invencibility(1f));
        if (life <= 0)
        {
            _animatorMananger.Die();
            this.enabled = false;
        }

        this.transform.localScale = smashedScale;
        this.enabled = false;
        yield return new WaitForSeconds(seconds);
        
        this.enabled = true;
        this.transform.localScale = normalScale;
        this.LoadCheckPoint();
    }


    public IEnumerator Invencibility(float seconds)
    {
        invencibility = true;
        yield return new WaitForSeconds(seconds);
        invencibility = false;
        yield return null;
    }

    public void ChangeMovementSpeed(float speed)
    {
        _movement.SetSpeed = speed;
    }

    public void ChangeJumpForce(float jumpForce)
    {
        _movement.SetJumpForce = jumpForce;
    }

    #region CollectableGetters
    public void GetHp(int hp)
    {
        this.life += hp;
        if (life > _maxLifes) life = _maxLifes;
    }

    public void GetShield()
    {
        StartCoroutine(Invencibility(shieldTime));
        shieldOn = true;
        prefabShield.gameObject.SetActive(true);
        Invoke("RemoveShield", shieldTime);
    } 

    public void RemoveShield()
    {
        prefabShield.gameObject.SetActive(false);
        shieldOn = false;
    }
    public void GetApple()
    {
        this.apples += 1;
    }
    #endregion
    #region Checkpoint
    internal void SaveCheckPoint()
    {
        _control.SaveCheckPoint();
    }
    internal void LoadCheckPoint()
    {
        _control.LoadCheckPoint();
    }
    #endregion

}