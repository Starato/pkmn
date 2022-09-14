using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public moveBase Base{get; set;}
    public int PP{get; set;}

    public Move(moveBase pBase)
    {
        Base = pBase;
        PP = pBase.Pp;
    }

}
