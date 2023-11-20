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
                this.GetComponent<SpriteRenderer>().sprite = T; break;
            case "Z1": 
            case "Z2": 
            case "Z3": 
            case "Z4": 
                this.GetComponent<SpriteRenderer>().sprite = Z; break;
            case "S1": 
            case "S2": 
            case "S3": 
            case "S4": 
                this.GetComponent<SpriteRenderer>().sprite = S; break;
            case "L1": 
            case "L2": 
            case "L3": 
            case "L4": 
                this.GetComponent<SpriteRenderer>().sprite = L; break;
            case "J1": 
            case "J2": 
            case "J3": 
            case "J4": 
                this.GetComponent<SpriteRenderer>().sprite = J; break;
            case "O1": 
            case "O2": 
            case "O3": 
            case "O4": 
                this.GetComponent<SpriteRenderer>().sprite = O; break;
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
