public class CheckpointMananger
{ 
    Player _player;
    CheckPoint _checkpoint;
    public CheckpointMananger(Player p)
    {
        _player = p;
        _checkpoint = new CheckPoint();
    }

    public void SaveCheck()
    {
        CheckPointStruct ch = new CheckPointStruct();
        ch.lastCheckPos = _player.transform.position;
        ch.lastCheckRot = _player.transform.rotation;
        _checkpoint.Check = ch;
    }

    public CheckPoint LoadCheck()
    {
        return _checkpoint;
    }
}
