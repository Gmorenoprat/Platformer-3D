using UnityEngine;
using Sounds;


public class PlayerController
{
    Player _player;
    Movement _movement;
    BattleMechanics _battle;

    CheckpointMananger _checkpointMananger;

    SoundMananger _soundMananger;
    AnimatorMananger _animatorMananger;
    public PlayerController(Player p, Movement m, BattleMechanics b, CheckpointMananger c, SoundMananger s, AnimatorMananger a)
    {
        _player = p;
        _movement = m;
        _battle = b;
        _checkpointMananger = c;
        _soundMananger = s;
        _animatorMananger = a;
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            if(_player.isGrounded)_soundMananger.SoundPlay((int)sounds.JUMP);
            _movement.Jump();
            }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v != 0 || h != 0) {
            _animatorMananger.Move(true);

            _movement.Move(v, h);
        }
        else _animatorMananger.Move(false);




        if (Input.GetKeyDown(KeyCode.G) && _player.CanAttack)
        {
            _battle.Attack();
            _animatorMananger.Attack();
            _soundMananger.SoundPlay((int)sounds.ATTACK);

        }

        //test SaveLoad
        if (Input.GetKeyDown(KeyCode.F2)) SaveCheckPoint();
        if (Input.GetKeyDown(KeyCode.F3)) LoadCheckPoint();
    }

    public void SaveCheckPoint()
    {
        _checkpointMananger.SaveCheck();
    }
    public void LoadCheckPoint()
    {
        CheckPoint checktoload = _checkpointMananger.LoadCheck();
        _player.transform.position = checktoload.lastCheck.lastCheckPos;
        _player.transform.rotation = checktoload.lastCheck.lastCheckRot;
    }
}