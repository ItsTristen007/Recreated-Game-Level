using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Game : MonoBehaviour
{

    public GameObject block;

    [SerializeField] private GameObject[,] board = new GameObject[10,20];
    
    int block1X; int block1Y; string name1;
    int block2X; int block2Y; string name2;
    int block3X; int block3Y; string name3;
    int block4X; int block4Y; string name4;
    
    
    void Start()
    {
        NewBlock("T");
    }

    void UpdateBlocks()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player").Reverse())
        {
            Tetrimino tet = obj.GetComponent<Tetrimino>();
            Debug.Log(tet.GetX()+", "+tet.GetY());
            if (tet.GetY() != 19 && board[tet.GetX(), tet.GetY() + 1] == null)
            {
                board[tet.GetX(), tet.GetY()] = null;
                board[tet.GetX(), tet.GetY() + 1] = obj;
                tet.SetY(tet.GetY() + 1);
                tet.SetCoords();
            }
            else break;
        }
    }

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(block, new Vector3(0, 0, -1), Quaternion.identity);
        Tetrimino tet = obj.GetComponent<Tetrimino>();
        tet.name = name;
        tet.SetX(x);
        tet.SetY(y);
        tet.Activate();
        return obj;
    }

    public void NewBlock(string block)
    {
        switch (block)
        {
            case "I": 
                block1X = 4; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 2; name2 = block + "2";
                block3X = 4; block3Y = 3; name3 = block + "3";
                block4X = 4; block4Y = 4; name4 = block + "4";
                break;
            case "L":
                block1X = 4; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 2; name2 = block + "2";
                block3X = 4; block3Y = 3; name3 = block + "3";
                block4X = 5; block4Y = 3; name4 = block + "4";
                break;
            case "J":
                block1X = 4; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 2; name2 = block + "2";
                block3X = 4; block3Y = 3; name3 = block + "3";
                block4X = 3; block4Y = 3; name4 = block + "4";
                break;
            case "S":
                block1X = 5; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 1; name2 = block + "2";
                block3X = 4; block3Y = 2; name3 = block + "3";
                block4X = 3; block4Y = 2; name4 = block + "4";
                break;
            case "Z":
                block1X = 3; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 1; name2 = block + "2";
                block3X = 4; block3Y = 2; name3 = block + "3";
                block4X = 5; block4Y = 2; name4 = block + "4";
                break;
            case "O":
                block1X = 4; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 2; name2 = block + "2";
                block3X = 5; block3Y = 1; name3 = block + "3";
                block4X = 5; block4Y = 2; name4 = block + "4";
                break;
            case "T":
                block1X = 3; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 1; name2 = block + "2";
                block3X = 5; block3Y = 1; name3 = block + "3";
                block4X = 4; block4Y = 2; name4 = block + "4";
                break;
        }

        board[block1X, block1Y] = Create(name1,block1X,block1Y);
        board[block2X, block2Y] = Create(name2,block2X,block2Y);
        board[block3X, block3Y] = Create(name3,block3X,block3Y);
        board[block4X, block4Y] = Create(name4,block4X,block4Y);
    }
    
    void Update()
    {
        UpdateBlocks();
    }
}
