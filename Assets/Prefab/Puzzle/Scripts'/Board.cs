using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject NoteCanvas;
    [SerializeField] private Transform tilesParent;
    [SerializeField] private Sprite openedChest;
    [SerializeField] private SpriteRenderer Chest;

    private List<Tile> tileList;
    private Vector2Int puzzleSize=new Vector2Int(3,3);

    private float neighborTileDistance = 102;

    public Vector3 EmptyTilePostition { set; get; }

    private IEnumerator Start()
    {
       
        tileList = new List<Tile>();
        SpawnTiles();

        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());
        yield return new WaitForEndOfFrame();

        tileList.ForEach(x => x.SetCorrectPosition());
        EmptyTilePostition = tileList[0].GetComponent<RectTransform>().localPosition;
        StartCoroutine(OnShuffle());

    }

    private void SpawnTiles()
    {
        for (int y = 0; y < puzzleSize.y; y++)
        {
            for (int x = 0; x < puzzleSize.x; x++)
            {
                GameObject clone =Instantiate(tilePrefab, tilesParent);
                Tile tile =clone.GetComponent<Tile>();

                tile.Setup(this,puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);

                tileList.Add(tile);
            }
        }  
    }

    public IEnumerator OnShuffle()
    {
        float current = 0;
        float percent = 0;
        float time = 1.5f;
        int x = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            while (x <= 8) { 
            if (x == 0)
            {
                int index = 8;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 1)
            {
                int index = 5;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 2)
            {
                int index = 1;
                tileList[index].transform.SetAsLastSibling();
            }
            
            else if (x == 3)
            {
                int index = 4;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 4)
            {
                int index = 2;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 5)
            {
                int index = 6;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 6)
            {
                int index = 3;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 7)
            {
                int index = 7;
                tileList[index].transform.SetAsLastSibling();
            }
            else if (x == 8)
            {
                int index = 0;
                tileList[index].transform.SetAsLastSibling();
            }

                x++;
            }


            yield return null;

        }


        

    }

    public void IsMoveTile(Tile tile)
    {
        if (Vector3.Distance(EmptyTilePostition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
        {

            Vector3 goalPosition = EmptyTilePostition;
            EmptyTilePostition = tile.GetComponent<RectTransform>().localPosition;

            tile.OnMoveTo(goalPosition);
        }
    }


    public void IsGameOver()
    {
        List<Tile> tiles = tileList.FindAll(x => x.IsCorrected == true);

        Debug.Log("Correct Count : " + tiles.Count);

        if (tiles.Count == puzzleSize.x * puzzleSize.y - 1)
        {
            NoteCanvas.SetActive(true);
            Chest.sprite = openedChest;
            gameObject.SetActive(false);
            Debug.Log("GameClear");
        }
    }



    public void Exit()
    {
       canvas.SetActive(false);
    }

    public void Solve()
    {
        NoteCanvas.SetActive(true);
        Chest.sprite = openedChest;
 
        gameObject.SetActive(false);
        Debug.Log("GameClear");
        canvas.SetActive(false);
    }

}
