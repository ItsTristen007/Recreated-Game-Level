using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimino : MonoBehaviour
{

    private int x;
    private int y;
    private int nextX;
    private int nextY;

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

    public int GetRotatePositionX()
    {
        nextX = x;
        string id = name.Substring(0, 1);
        switch (id)
        {
            case "I":
                GameObject I = GameObject.Find("I2");
                Tetrimino I2 = I.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "I1":
                        if (I2.GetX() == x && I2.GetY() == y + 1) nextX = x - 1;
                        if (I2.GetX() == x + 1 && I2.GetY() == y) nextX = x + 1;
                        break;
                    case "I2":
                        nextX = x;
                        break;
                    case "I3":
                        if (I2.GetX() == x && I2.GetY() == y - 1) nextX = x + 1;
                        if (I2.GetX() == x - 1 && I2.GetY() == y) nextX = x - 1;
                        break;
                    case "I4":
                        if (I2.GetX() == x && I2.GetY() == y - 2) nextX = x + 2;
                        if (I2.GetX() == x - 2 && I2.GetY() == y) nextX = x - 2;
                        break;
                }
                break;
            case "T":
                GameObject T = GameObject.Find("T2");
                Tetrimino T2 = T.GetComponent<Tetrimino>();
                switch (name)
                {
                    
                    case "T1":
                        if (T2.GetX() == x + 1 && T2.GetY() == y) nextX = x + 1;
                        if (T2.GetX() == x && T2.GetY() == y + 1) nextX = x + 1;
                        if (T2.GetX() == x - 1 && T2.GetY() == y) nextX = x - 1;
                        if (T2.GetX() == x && T2.GetY() == y - 1) nextX = x - 1;
                        break;
                    case "T2":
                        nextX = x;
                        break;
                    case "T3":
                        if (T2.GetX() == x - 1 && T2.GetY() == y) nextX = x - 1;
                        if (T2.GetX() == x && T2.GetY() == y - 1) nextX = x - 1;
                        if (T2.GetX() == x + 1 && T2.GetY() == y) nextX = x + 1;
                        if (T2.GetX() == x && T2.GetY() == y + 1) nextX = x + 1;
                        break;
                    case "T4":
                        if (T2.GetX() == x && T2.GetY() == y - 1) nextX = x - 1;
                        if (T2.GetX() == x + 1 && T2.GetY() == y) nextX = x + 1;
                        if (T2.GetX() == x && T2.GetY() == y + 1) nextX = x + 1;
                        if (T2.GetX() == x - 1 && T2.GetY() == y) nextX = x - 1;
                        break;
                }
                break;
            
            case "O":
                
                switch (name)
                {
                    case "O1":
                    case "O2":
                    case "O3":
                    case "O4":
                        nextX = x;
                        break;
                }
                break;
            
            case "L":
                GameObject L = GameObject.Find("L3");
                Tetrimino L3 = L.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "L1":
                        if (L3.GetX() == x && L3.GetY() == y + 2) nextX = x + 2;
                        if (L3.GetX() == x - 2 && L3.GetY() == y) nextX = x - 2;
                        if (L3.GetX() == x && L3.GetY() == y - 2) nextX = x - 2;
                        if (L3.GetX() == x + 2 && L3.GetY() == y) nextX = x + 2;
                        break;
                    case "L2":
                        if (L3.GetX() == x && L3.GetY() == y + 1) nextX = x + 1;
                        if (L3.GetX() == x - 1 && L3.GetY() == y) nextX = x - 1;
                        if (L3.GetX() == x && L3.GetY() == y - 1) nextX = x - 1;
                        if (L3.GetX() == x + 1 && L3.GetY() == y) nextX = x + 1;
                        break;
                    case "L3":
                        nextX = x;
                        break;
                    case "L4":
                        if (L3.GetX() == x - 1 && L3.GetY() == y) nextX = x - 1;
                        if (L3.GetX() == x && L3.GetY() == y - 1) nextX = x - 1;
                        if (L3.GetX() == x + 1 && L3.GetY() == y) nextX = x + 1;
                        if (L3.GetX() == x && L3.GetY() == y + 1) nextX = x + 1;
                        break;
                }
                break;
            
            case "J":
                GameObject J = GameObject.Find("J3");
                Tetrimino J3 = J.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "J1":
                        if (J3.GetX() == x && J3.GetY() == y + 2) nextX = x + 2;
                        if (J3.GetX() == x - 2 && J3.GetY() == y) nextX = x - 2;
                        if (J3.GetX() == x && J3.GetY() == y - 2) nextX = x - 2;
                        if (J3.GetX() == x + 2 && J3.GetY() == y) nextX = x + 2;
                        break;
                    case "J2":
                        if (J3.GetX() == x && J3.GetY() == y + 1) nextX = x + 1;
                        if (J3.GetX() == x - 1 && J3.GetY() == y) nextX = x - 1;
                        if (J3.GetX() == x && J3.GetY() == y - 1) nextX = x - 1;
                        if (J3.GetX() == x + 1 && J3.GetY() == y) nextX = x + 1;
                        break;
                    case "J3":
                        nextX = x;
                        break;
                    case "J4":
                        if (J3.GetX() == x + 1 && J3.GetY() == y) nextX = x + 1;
                        if (J3.GetX() == x && J3.GetY() == y + 1) nextX = x + 1;
                        if (J3.GetX() == x - 1 && J3.GetY() == y) nextX = x - 1;
                        if (J3.GetX() == x && J3.GetY() == y - 1) nextX = x - 1;
                        break;
                }
                break;
            
            case "S":
                GameObject S = GameObject.Find("S2");
                Tetrimino S2 = S.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "S1":
                        if (S2.GetX() == x - 1 && S2.GetY() == y) nextX = x - 1;
                        if (S2.GetX() == x && S2.GetY() == y + 1) nextX = x + 1;
                        break;
                    case "S2":
                        nextX = x;
                        break;
                    case "S3":
                        if (S2.GetX() == x && S2.GetY() == y - 1) nextX = x + 1;
                        if (S2.GetX() == x - 1 && S2.GetY() == y) nextX = x - 1;
                        break;
                    case "S4":
                        if (S2.GetX() == x + 1 && S2.GetY() == y - 1) nextX = x + 2;
                        if (S2.GetX() == x - 1 && S2.GetY() == y - 1) nextX = x - 2;
                        break;
                }
                break;
            
            case "Z":
                GameObject Z = GameObject.Find("Z2");
                Tetrimino Z2 = Z.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "Z1":
                        if (Z2.GetX() == x + 1 && Z2.GetY() == y) nextX = x + 1;
                        if (Z2.GetX() == x && Z2.GetY() == y + 1) nextX = x - 1;
                        break;
                    case "Z2":
                        nextX = x;
                        break;
                    case "Z3":
                        if (Z2.GetX() == x && Z2.GetY() == y - 1) nextX = x - 1;
                        if (Z2.GetX() == x + 1 && Z2.GetY() == y) nextX = x + 1;
                        break;
                    case "Z4":
                        if (Z2.GetX() == x - 1 && Z2.GetY() == y - 1) nextX = x - 2;
                        if (Z2.GetX() == x + 1 && Z2.GetY() == y - 1) nextX = x + 2;
                        break;
                }
                break;
            
        }

        return nextX;
    }
    
    public int GetRotatePositionY()
    {
        nextY = y;
        string id = name.Substring(0, 1);
        switch (id)
        {
            case "I":
                GameObject I = GameObject.Find("I2");
                Tetrimino I2 = I.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "I1":
                        if (I2.GetX() == x && I2.GetY() == y + 1) nextY = y + 1;
                        if (I2.GetX() == x + 1 && I2.GetY() == y) nextY = y - 1;
                        break;
                    case "I2":
                        nextY = y;
                        break;
                    case "I3":
                        if (I2.GetX() == x && I2.GetY() == y - 1) nextY = y - 1;
                        if (I2.GetX() == x - 1 && I2.GetY() == y) nextY = y + 1;
                        break;
                    case "I4":
                        if (I2.GetX() == x && I2.GetY() == y - 2) nextY = y - 2;
                        if (I2.GetX() == x - 2 && I2.GetY() == y) nextY = y + 2;
                        break;
                }
                break;
            
            case "T":
                GameObject T = GameObject.Find("T2");
                Tetrimino T2 = T.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "T1":
                        if (T2.GetX() == x + 1 && T2.GetY() == y) nextY = y - 1;
                        if (T2.GetX() == x && T2.GetY() == y + 1) nextY = y + 1;
                        if (T2.GetX() == x - 1 && T2.GetY() == y) nextY = y + 1;
                        if (T2.GetX() == x && T2.GetY() == y - 1) nextY = y - 1;
                        break;
                    case "T2":
                        nextY = y;
                        break;
                    case "T3":
                        if (T2.GetX() == x - 1 && T2.GetY() == y) nextY = y + 1;
                        if (T2.GetX() == x && T2.GetY() == y - 1) nextY = y - 1;
                        if (T2.GetX() == x + 1 && T2.GetY() == y) nextY = y - 1;
                        if (T2.GetX() == x && T2.GetY() == y + 1) nextY = y + 1;
                        break;
                    case "T4":
                        if (T2.GetX() == x && T2.GetY() == y - 1) nextY = y - 1;
                        if (T2.GetX() == x + 1 && T2.GetY() == y) nextY = y - 1;
                        if (T2.GetX() == x && T2.GetY() == y + 1) nextY = y + 1;
                        if (T2.GetX() == x - 1 && T2.GetY() == y) nextY = y + 1;
                        break;
                }
                break;
            case "O":
                switch (name)
                {
                    case "O1":
                    case "O2":
                    case "O3":
                    case "O4":
                        nextY = y;
                        break;
                }
                break;
            
            case "L":
                GameObject L = GameObject.Find("L3");
                Tetrimino L3 = L.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "L1":
                        if (L3.GetX() == x && L3.GetY() == y + 2) nextY = y + 2;
                        if (L3.GetX() == x - 2 && L3.GetY() == y) nextY = y + 2;
                        if (L3.GetX() == x && L3.GetY() == y - 2) nextY = y - 2;
                        if (L3.GetX() == x + 2 && L3.GetY() == y) nextY = y - 2;
                        break;
                    case "L2":
                        if (L3.GetX() == x && L3.GetY() == y + 1) nextY = y + 1;
                        if (L3.GetX() == x - 1 && L3.GetY() == y) nextY = y + 1;
                        if (L3.GetX() == x && L3.GetY() == y - 1) nextY = y - 1;
                        if (L3.GetX() == x + 1 && L3.GetY() == y) nextY = y - 1;
                        break;
                    case "L3":
                        nextY = y;
                        break;
                    case "L4":
                        if (L3.GetX() == x - 1 && L3.GetY() == y) nextY = y + 1;
                        if (L3.GetX() == x && L3.GetY() == y - 1) nextY = y - 1;
                        if (L3.GetX() == x + 1 && L3.GetY() == y) nextY = y - 1;
                        if (L3.GetX() == x && L3.GetY() == y + 1) nextY = y + 1;
                        break;
                }
                break;
            
            case "J":
                GameObject J = GameObject.Find("J3");
                Tetrimino J3 = J.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "J1":
                        if (J3.GetX() == x && J3.GetY() == y + 2) nextY = y + 2;
                        if (J3.GetX() == x - 2 && J3.GetY() == y) nextY = y + 2;
                        if (J3.GetX() == x && J3.GetY() == y - 2) nextY = y - 2;
                        if (J3.GetX() == x + 2 && J3.GetY() == y) nextY = y - 2;
                        break;
                    case "J2":
                        if (J3.GetX() == x && J3.GetY() == y + 1) nextY = y + 1;
                        if (J3.GetX() == x - 1 && J3.GetY() == y) nextY = y + 1;
                        if (J3.GetX() == x && J3.GetY() == y - 1) nextY = y - 1;
                        if (J3.GetX() == x + 1 && J3.GetY() == y) nextY = y - 1;
                        break;
                    case "J3":
                        nextY = y;
                        break;
                    case "J4":
                        if (J3.GetX() == x + 1 && J3.GetY() == y) nextY = y - 1;
                        if (J3.GetX() == x && J3.GetY() == y + 1) nextY = y + 1;
                        if (J3.GetX() == x - 1 && J3.GetY() == y) nextY = y + 1;
                        if (J3.GetX() == x && J3.GetY() == y - 1) nextY = y - 1;
                        break;  
                }
                break;
            
            case "S":
                GameObject S = GameObject.Find("S2");
                Tetrimino S2 = S.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "S1":
                        if (S2.GetX() == x - 1 && S2.GetY() == y) nextY = y - 1;
                        if (S2.GetX() == x && S2.GetY() == y + 1) nextY = y + 1;
                        break;
                    case "S2":
                        nextY = y;
                        break;
                    case "S3":
                        if (S2.GetX() == x && S2.GetY() == y - 1) nextY = y - 1;
                        if (S2.GetX() == x - 1 && S2.GetY() == y) nextY = y + 1;
                        break;
                    case "S4":
                        if (S2.GetX() == x + 1 && S2.GetY() == y - 1) nextY = y;
                        if (S2.GetX() == x - 1 && S2.GetY() == y - 1) nextY = y;
                        break; 
                }
                break;
            
            case "Z":
                GameObject Z = GameObject.Find("Z2");
                Tetrimino Z2 = Z.GetComponent<Tetrimino>();
                switch (name)
                {
                    case "Z1":
                        if (Z2.GetX() == x + 1 && Z2.GetY() == y) nextY = y - 1;
                        if (Z2.GetX() == x && Z2.GetY() == y + 1) nextY = y + 1;
                        break;
                    case "Z2":
                        nextY = y;
                        break;
                    case "Z3":
                        if (Z2.GetX() == x && Z2.GetY() == y - 1) nextY = y - 1;
                        if (Z2.GetX() == x + 1 && Z2.GetY() == y) nextY = y + 1;
                        break;
                    case "Z4":
                        if (Z2.GetX() == x - 1 && Z2.GetY() == y - 1) nextY = y;
                        if (Z2.GetX() == x + 1 && Z2.GetY() == y - 1) nextY = y;
                        break;
                }
                break;
            
        }
        return nextY;
    }

    public void ExecuteRotation()
    {
        SetX(nextX);
        SetY(nextY);
        SetCoords();
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

    public void SetNextY(int y)
    {
        nextY = y;
    }
    
    public int GetNextY()
    {
        return nextY;
    }
    
    public void SetNextX(int x)
    {
        nextX = x;
    }
    
    public int GetNextX()
    {
        return nextX;
    }
}
