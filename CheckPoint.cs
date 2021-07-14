using UnityEngine;
using System;

public class CheckPoint 
{

    public CheckPointStruct lastCheck;
    public CheckPointStruct Check
    {
        get
        {
            return lastCheck;
        }
        set
        {
            lastCheck = value;
        }
    }

}
[Serializable]
public struct CheckPointStruct
{
    public Vector3 lastCheckPos;
    public Quaternion lastCheckRot;
}

