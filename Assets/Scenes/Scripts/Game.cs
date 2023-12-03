using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using UnityEngine;


public class Game : MonoBehaviour
{

    public GameObject block;
    private static int boardX = 10;
    private static int boardY = 20;
    [SerializeField] private GameObject[,] board = new GameObject[boardX,boardY];

    private int fallSpeed = 600;
    private bool stop = false;

    private string currentBlock;
    private string nextBlock;
    private string nextnextBlock;
    private string nextnextnextBlock;
    
    private int timer = 0;
    
    int block1X; int block1Y; string name1;
    int block2X; int block2Y; string name2;
    int block3X; int block3Y; string name3;
    int block4X; int block4Y; string name4;
    

    void UpdateBlocksDown()
    {
        int count = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player").Reverse())
        {
            Tetrimino tet = obj.GetComponent<Tetrimino>();
            if (tet.GetY() + 1 != 20 && board[tet.GetX(), tet.GetY() + 1] == null)
            {
                tet.SetNextY(tet.GetY() + 1);
                count++;
                
            }
            else if (tet.GetY() + 1 != 20 && !board[tet.GetX(), tet.GetY() + 1].CompareTag("Solid"))
            {
                tet.SetNextY(tet.GetY() + 1);
                count++;
            }
            else
            {
                if (tet.GetY() + 1 >= 20 || board[tet.GetX(), tet.GetY() + 1].CompareTag("Solid"))
                {
                    stop = true;
                    break;
                }
            }
        }

        if (count == 4)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player").Reverse())
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                board[tet.GetX(), tet.GetY()] = null;
                tet.SetY(tet.GetNextY());
                board[tet.GetX(), tet.GetY()] = obj;
                tet.SetCoords();
            }
        }

        if (stop)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                tet.tag = "Solid";
                tet.name = "Solid";
            }
        }

        stop = false;
    }
    
    void UpdateBlocksRight()
    {
        int count = 0;
        bool moved = false;
        while (!moved)
        {

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player").Reverse())
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                if (board[tet.GetX() + 1, tet.GetY()] == null)
                {
                    tet.SetNextX(tet.GetX() + 1);
                    count++;
                    moved = true;
                }
                else if (!board[tet.GetX() + 1, tet.GetY()].CompareTag("Solid"))
                {
                    tet.SetNextX(tet.GetX() + 1);
                    count++;
                    moved = true;
                }
                else break;
            }
        

            if (!moved)
            {
                {
                    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        Tetrimino tet = obj.GetComponent<Tetrimino>();
                        if (tet.GetY() != 19 && board[tet.GetX() + 1, tet.GetY()] == null)
                        {
                            tet.SetNextX(tet.GetX() + 1);
                            count++;
                            moved = true;
                        }
                        else if (!board[tet.GetX() + 1, tet.GetY()].CompareTag("Solid"))
                        {
                            tet.SetNextX(tet.GetX() + 1);
                            count++;
                            moved = true;
                        }
                        else break;
                    }
                }
            }
        }
        if (count == 4)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                board[tet.GetX(), tet.GetY()] = null;
                tet.SetX(tet.GetNextX());
                board[tet.GetX(), tet.GetY()] = obj;
                tet.SetCoords();
            }
        }
    }

    void UpdateBlocksLeft()
    {
        int count = 0;
        bool moved = false;
        while (!moved)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                if (board[tet.GetX() - 1, tet.GetY()] == null)
                {
                    tet.SetNextX(tet.GetX() - 1);
                    count++;
                    moved = true;
                }
                else if (!board[tet.GetX() - 1, tet.GetY()].CompareTag("Solid"))
                {
                    tet.SetNextX(tet.GetX() - 1);
                    count++;
                    moved = true;
                }
                else break;
            }

            if (!moved)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player").Reverse())
                {
                    Tetrimino tet = obj.GetComponent<Tetrimino>();
                    if (tet.GetY() != 19 && board[tet.GetX() - 1, tet.GetY()] == null)
                    {
                        tet.SetNextX(tet.GetX() - 1);
                        count++;
                        moved = true;
                    }
                    else if (!board[tet.GetX() - 1, tet.GetY()].CompareTag("Solid"))
                    {
                        tet.SetNextX(tet.GetX() - 1);
                        count++;
                        moved = true;
                    }
                    else break;
                }
            }
        }
        if (count == 4)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                board[tet.GetX(), tet.GetY()] = null;
                tet.SetX(tet.GetNextX());
                board[tet.GetX(), tet.GetY()] = obj;
                tet.SetCoords();
            }
        }
    }

    void UpdateRotate()
    {
        int count = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Tetrimino tet = obj.GetComponent<Tetrimino>();
            int nextX = tet.GetRotatePositionX();
            int nextY = tet.GetRotatePositionY();
            if ((nextX >= 0 && nextX <= 9) 
                && (nextY >= 0 && nextY <= 19) && board[nextX, nextY] == null) count++;
            else if (!board[nextX, nextY].CompareTag("Solid"))count++;
            else break;
        }

        if (count == 4)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                Tetrimino tet = obj.GetComponent<Tetrimino>();
                board[tet.GetX(), tet.GetY()] = null;
                tet.ExecuteRotation();
                board[tet.GetX(), tet.GetY()] = obj;
            }
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

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (fallSpeed > 300)
            {
                timer++;
                timer++;
            }
            else timer++;

        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) UpdateRotate();
        
        if (Input.GetKeyDown(KeyCode.RightArrow)) UpdateBlocksRight();
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) UpdateBlocksLeft();
        
        if (timer >= fallSpeed)
        {
            UpdateBlocksDown();
            timer = 0;
        }
        timer++;
        
        
        if (GameObject.FindGameObjectsWithTag("Player").Length < 4)
        {
            NewBlock(nextBlock);
            BlockOrder();
        }
    }

    private void BlockOrder()
    {
        currentBlock = nextBlock;
        nextBlock = nextnextBlock;
        nextnextBlock = nextnextnextBlock;
        
        int n = Random.Range(0, 7);
        switch (n)
        {
            case 0:
                nextnextnextBlock = "I";
                break;
            case 1:
                nextnextnextBlock = "L";
                break;
            case 2:
                nextnextnextBlock = "J";
                break;
            case 3:
                nextnextnextBlock = "O";
                break;
            case 4:
                nextnextnextBlock = "S";
                break;
            case 5:
                nextnextnextBlock = "Z";
                break;
            case 6:
                nextnextnextBlock = "T";
                break;
        }
    }
    
    void Start()
    {
        int n = Random.Range(0, 7);
        switch (n)
        {
            case 0:
                nextBlock = "I";
                break;
            case 1:
                nextBlock = "L";
                break;
            case 2:
                nextBlock = "J";
                break;
            case 3:
                nextBlock = "O";
                break;
            case 4:
                nextBlock = "S";
                break;
            case 5:
                nextBlock = "Z";
                break;
            case 6:
                nextBlock = "T";
                break;
        }
        n = Random.Range(0, 7);
        switch (n)
        {
            case 0:
                nextnextBlock = "I";
                break;
            case 1:
                nextnextBlock = "L";
                break;
            case 2:
                nextnextBlock = "J";
                break;
            case 3:
                nextnextBlock = "O";
                break;
            case 4:
                nextnextBlock = "S";
                break;
            case 5:
                nextnextBlock = "Z";
                break;
            case 6:
                nextnextBlock = "T";
                break;
        }
        n = Random.Range(0, 7);
        switch (n)
        {
            case 0:
                nextnextnextBlock = "I";
                break;
            case 1:
                nextnextnextBlock = "L";
                break;
            case 2:
                nextnextnextBlock = "J";
                break;
            case 3:
                nextnextnextBlock = "O";
                break;
            case 4:
                nextnextnextBlock = "S";
                break;
            case 5:
                nextnextnextBlock = "Z";
                break;
            case 6:
                nextnextnextBlock = "T";
                break;
        }
        
    }
    
}
