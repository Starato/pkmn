using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemon
{
    pokemonBase _based;
    int level;
    public List<Move> Moves{get; set;}
    public int HP{get; set;}

    public pokemon(pokemonBase pBase, int pLevel)
    {
        _based = pBase;
        level = pLevel;
        HP = _based.MaxHp;

        Moves = new List<Move>();
        foreach(var move in _based.LearnableMoves)
        {
            if(move.Level <= level){
                Moves.Add(new Move(move.Base));
            }
            if(Moves.Count >= 4){
                break;
            }
        }

    }

    public int MaxHp{
        get{return Mathf.FloorToInt((_based.Speed * level) / 100f) + 10;}
    }
    public int Attack{
        get{return Mathf.FloorToInt((_based.Attack * level) / 100f) + 5;}
    }
    public int Defense{
        get{return Mathf.FloorToInt((_based.Defense * level) / 100f) + 5;}
    }
    public int SpAttack{
        get{return Mathf.FloorToInt((_based.SpAttack * level) / 100f) + 5;}
    }
    public int SpDefense{
        get{return Mathf.FloorToInt((_based.SpDefense * level) / 100f) + 5;}
    }
    public int Speed{
        get{return Mathf.FloorToInt((_based.Speed * level) / 100f) + 5;}
    }

}
