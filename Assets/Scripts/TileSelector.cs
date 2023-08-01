using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    private static int gridWidth = 10;
    private static int gridHeight = 6;
    public Unit[] units = new Unit[60];
    public Tile tile;
    private Transform camera;
    private int turnCount, currentUnit;
    public Move skip;

    void GenerateMap()
    {
        int spacer = 2;
        int unitIndex = 0;
        for(int x = 0; x < gridWidth * spacer; x += spacer)
        {
            for(int y = 0; y < gridHeight * spacer; y += spacer)
            {
                Tile t = Instantiate(tile, new Vector3(x,y), Quaternion.identity);
                t.name = "Tile-" + (x/spacer) + "-" + (y/spacer);
                t.xPos = (x/spacer);
                t.yPos = (y/spacer);
                bool p1 = x < (gridWidth / 2);
                bool offset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                
                // Puts unit at their assigned tile
                if(units[unitIndex] != null && (t.xPos == units[unitIndex].xPos && t.yPos == units[unitIndex].yPos))
                {
                    // What side will it face?
                    if(units[unitIndex].xPos < gridWidth / 2)
                    {
                        Unit newUnit = Instantiate(units[unitIndex], new Vector3(x,y), Quaternion.identity);
                        unitIndex++;
                        t.unit = newUnit;
                    }
                    else
                    {
                        Unit newUnit = Instantiate(units[unitIndex], new Vector3(x,y), Quaternion.Euler(0, 180f, 0));
                        unitIndex++;
                        t.unit = newUnit;
                    }
                }
                // t.Init(offset, p1);
            }
        }
    }

    Unit[] SortBySpeed(Unit[] original)
    {
        int len = 0;
        do
        {
            len++;
        }
        while(original[len] != null);

        float[] speeds = new float[len];
        for(int i = 0; i < len; i++)
        {
            speeds[i] = original[i].speed;
        }

        SortArray(speeds, len);
        Unit[] result = new Unit[len];
        int rIndex = 0;
        for(int i = 0; i < len; i++)
        {
            for(int k = 0; k < len; k++)
            {
                if(original[i].speed == speeds[k])
                {
                    result[rIndex] = original[i];
                    rIndex++;
                    break;
                }
            }
        }
        return result;
    }

    float[] SortArray(float[] array, int length)
    {
        for (int i = 1; i < length; i++)
        {
            var key = array[i];
            var flag = 0;
            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (key < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                    array[j + 1] = key;
                }
                else flag = 1;
            }
        }
        return array;
    }
    
    void OnGUI() 
    {
        GUI.Label(new Rect(15, 15, 200, 40), "Turn " + turnCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GenerateMap();      
        turnCount = 0; 
        units = this.SortBySpeed(units);
        skip = Instantiate(skip,new Vector3(10,0), Quaternion.identity);
        units[0].StartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if(units[units.Length - 1].used)
        {
            turnCount++;
        }
    }
}