using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuePiece : MonoBehaviour
{
    public Sprite I, L, J, S, Z, O, T;
    private string block = "";
    
    public void Activate()
    {
        switch (block)
        {
            case "I":
                this.GetComponent<SpriteRenderer>().sprite = I; break;
            case "T":
                this.GetComponent<SpriteRenderer>().sprite = T; break;
            case "L":
                this.GetComponent<SpriteRenderer>().sprite = L; break;
            case "J":
                this.GetComponent<SpriteRenderer>().sprite = J; break;
            case "S":
                this.GetComponent<SpriteRenderer>().sprite = S; break;
            case "Z":
                this.GetComponent<SpriteRenderer>().sprite = Z; break;
            case "O":
                this.GetComponent<SpriteRenderer>().sprite = O; break;
        }
    }

    public void SetBlock(string block)
    {
        this.block = block;
        Activate();
    }

    public string GetBlock()
    {
        return block;
    }
}
