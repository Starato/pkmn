using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new move")]
public class moveBase : ScriptableObject
{
    [SerializeField] string names;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Names{
        get{return names;}
    }
    public string Description{
        get{return description;}
    }
    public PokemonType Type{
        get{return type;}
    }
    public int Power{
        get{return power;}
    }
    public int Accuracy{
        get{return accuracy;}
    }
    public int Pp{
        get{return pp;}
    }

}
