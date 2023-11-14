using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{

    private int x;
    private int y;

    public Sprite I, L, J, S, Z, O, T;

    public void Activate()
    {
        SetCoords();

        switch (name)
        {
            case "I1": 
            case "I2": 
            case "I3": 
            case "I4": 
                this.GetComponent<SpriteRenderer>().sprite = I; break;
            case "T1": 
            case "T2": 
            case "T3": 
            case "T4": 
                this.GetComponent<SpriteRenderer>().sprite = I; break;
        }
    }

    public void SetCoords()
    {
        float x = this.x;
        float y = this.y;

        x *= 0.3f;
        y *= -0.3f;

        x += -1.35f;
        y += 2.9f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public int GetX()
    {
        return x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public int GetY()
    {
        return y;
    }
}
