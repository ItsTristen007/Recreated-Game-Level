using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class Game : MonoBehaviour
{

    public GameObject block;
    private static int boardX = 10;
    private static int boardY = 20;
    
    int player = 1;

    private string holding = "";

    private bool held = false;
    
    [SerializeField] private GameObject[,] board = new GameObject[boardX,boardY];

    private int fallSpeed = 25;
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

    private int clearedLines = 0;
    private int score = 0;
    private int level = 1;

    private bool gameOver = false;
    private int endGameTimer = 0;

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI levelText;
    
    
    // Audio 
    [SerializeField] private AudioSource lineClearSfx;
    [SerializeField] private AudioSource blockPlacedSfx;
    [SerializeField] private AudioSource blockHeldSfx;
    [SerializeField] private AudioSource moveSfx;
    
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
                blockPlacedSfx.Play();
            }

            held = false;
            if (player == 1) player = 2;
            else player = 1;
        }

        
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
            moveSfx.Play();
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
            moveSfx.Play();
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
                && (nextY >= 0 && nextY <= 19) && board[nextX, nextY] == null)
            {
                count++;
                moveSfx.Play();
            }
            else if (!board[nextX, nextY].CompareTag("Solid"))
            {
                count++;
                moveSfx.Play();
            }
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
    
    void LineClear()
    {
        int count;
        int full = 0;
        
        
        for (int y = 0; y < boardY; y++)
        {
            count = 0;
            for (int x = 0; x < boardX; x++)
            {
                if (board[x, y] != null) count++;
            }
            
            if (count == 10)
            {
                full++;
                Debug.Log(full);
                for (int x = 0; x < boardX; x++)
                {
                    Destroy(board[x, y]);
                    board[x, y] = null;
                    lineClearSfx.Play();
                }

                for (int a = y; a > 0; a--)
                {
                    for (int x = 0; x < boardX; x++)
                    {
                        if (board[x, a] != null)
                        {
                            Tetrimino tet = board[x, a].GetComponent<Tetrimino>();
                            if (tet.GetY() + 1 != 20 && board[tet.GetX(), tet.GetY() + 1] == null)
                            {
                                board[tet.GetX(), tet.GetY()+1] = board[x, a];
                                board[tet.GetX(), tet.GetY()] = null;
                                tet.SetY(tet.GetY() + 1);
                                tet.SetCoords();
                            }
                        }

                    } 
                }
            }
        }
        if (full == 1) score += 100 * level;
        else if (full == 2) score += 300 * level;
        else if (full == 3) score += 500 * level;
        else if (full == 4) score += 800 * level;
        clearedLines += full;
    }
    
    void Insurance()
    {
        for (int y = 0; y < boardY; y++)
        {
            for (int x = 0; x < boardX; x++)
            {
                board[x, y] = null;
            }

        }
        
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            Tetrimino tet = obj.GetComponent<Tetrimino>();
            board[tet.GetX(), tet.GetY()] = obj;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Solid"))
        {
            Tetrimino tet = obj.GetComponent<Tetrimino>();
            board[tet.GetX(), tet.GetY()] = obj;
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
                block1X = 5; block1Y = 1; name1 = block + "1";
                block2X = 5; block2Y = 2; name2 = block + "2";
                block3X = 5; block3Y = 3; name3 = block + "3";
                block4X = 5; block4Y = 4; name4 = block + "4";
                break;
            case "L":
                block1X = 4; block1Y = 1; name1 = block + "1";
                block2X = 4; block2Y = 2; name2 = block + "2";
                block3X = 4; block3Y = 3; name3 = block + "3";
                block4X = 5; block4Y = 3; name4 = block + "4";
                break;
            case "J":
                block1X = 5; block1Y = 1; name1 = block + "1";
                block2X = 5; block2Y = 2; name2 = block + "2";
                block3X = 5; block3Y = 3; name3 = block + "3";
                block4X = 4; block4Y = 3; name4 = block + "4";
                break;
            case "S":
                block1X = 6; block1Y = 1; name1 = block + "1";
                block2X = 5; block2Y = 1; name2 = block + "2";
                block3X = 5; block3Y = 2; name3 = block + "3";
                block4X = 4; block4Y = 2; name4 = block + "4";
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
                block1X = 4; block1Y = 1; name1 = block + "1";
                block2X = 5; block2Y = 1; name2 = block + "2";
                block3X = 6; block3Y = 1; name3 = block + "3";
                block4X = 5; block4Y = 2; name4 = block + "4";
                break;
        }

        board[block1X, block1Y] = Create(name1,block1X,block1Y);
        board[block2X, block2Y] = Create(name2,block2X,block2Y);
        board[block3X, block3Y] = Create(name3,block3X,block3Y);
        board[block4X, block4Y] = Create(name4,block4X,block4Y);
    }
    
    void Update()
    {

        currentScore.text = score.ToString();
        levelText.text = "Level: " + level;

        if (!gameOver)
        {
            Insurance();
            Levels();

            if (player == 1)
            {
                if (Input.GetKey(KeyCode.DownArrow)) timer++;

                if (Input.GetKeyDown(KeyCode.UpArrow)) UpdateRotate();

                if (Input.GetKeyDown(KeyCode.RightArrow)) UpdateBlocksRight();

                if (Input.GetKeyDown(KeyCode.LeftArrow)) UpdateBlocksLeft();
            }
            else
            {
                if (Input.GetKey(KeyCode.S)) timer++;

                if (Input.GetKeyDown(KeyCode.W)) UpdateRotate();

                if (Input.GetKeyDown(KeyCode.D)) UpdateBlocksRight();

                if (Input.GetKeyDown(KeyCode.A)) UpdateBlocksLeft();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                HoldBlock();
                held = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                while (!stop)
                {
                    UpdateBlocksDown();
                    Insurance();
                }
            }

            if (stop)
            {
                for (int y = 0; y <= 3; y++)
                {
                    for (int x = 0; x < boardX; x++)
                    {
                        if (board[x, y] != null)
                        {
                            if (board[x, y].CompareTag("Solid")) gameOver = true;
                        }
                    }
                }
                LineClear();
            }

            stop = false;

            if (GameObject.FindGameObjectsWithTag("Player").Length < 4)
            {
                NewBlock(nextBlock);
                BlockOrder();
            }
        }
        else GameOver();
    }
    
    private void FixedUpdate()
    {
        if (timer >= fallSpeed)
        {
            UpdateBlocksDown();
            timer = 0;
        }
        timer++;
    }

    private void GameOver()
    {
        if (endGameTimer >= 100) gameOverText.text = "GAME OVER";
        GameObject obj = GameObject.Find("board");
        SaveScore sav = obj.GetComponent<SaveScore>();
        if (score > sav.GetScore()) sav.SetScore(score);
        endGameTimer++;
        if (endGameTimer >= 200)
        {
            SceneManager.LoadScene("HighScoreScreen");
        }
    }

    private void HoldBlock()
    {
        string limbo;
        GameObject obj = GameObject.Find("Held");
        QueuePiece hpi = obj.GetComponent<QueuePiece>();
        if (!held)
        {
            if (holding.Equals(""))
            {
                blockHeldSfx.Play();
                ClearPlayer();
                holding = currentBlock;
                NewBlock(nextBlock);
                BlockOrder();
                hpi.SetBlock(holding);
            }
            else
            {
                blockHeldSfx.Play();
                ClearPlayer();
                limbo = holding;
                holding = currentBlock;
                currentBlock = limbo;
                NewBlock(currentBlock);
                hpi.SetBlock(holding);
            }
        }
    }

    private void ClearPlayer()
    {
        for (int y = 0; y < boardY; y++)
        {
            for (int x = 0; x < boardX; x++)
            {
                if (board[x, y] != null)
                {
                    if (board[x, y].CompareTag("Player"))
                    {
                        Destroy(board[x, y]);
                        board[x, y] = null;
                    }
                }
            }

        }
    }

    private void BlockOrder()
    {
        GameObject obj = GameObject.Find("Queue");
        QueuePiece qpi = obj.GetComponent<QueuePiece>();
        currentBlock = nextBlock;
        nextBlock = nextnextBlock;
        nextnextBlock = nextnextnextBlock;
        qpi.SetBlock(nextBlock);
        
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
    
    private void Levels()
    {
        if (clearedLines > 10)
        {
            fallSpeed = 20;
            level = 2;
        }
        
        if (clearedLines > 15)
        {
            fallSpeed = 15;
            level = 3;
        }

        if (clearedLines > 25)
        {
            fallSpeed = 12;
            level = 4;
        }

        if (clearedLines > 40)
        {
            fallSpeed = 8;
            level = 5;
        }

        if (clearedLines > 60)
        {
            fallSpeed = 2;
            level = 6;
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
