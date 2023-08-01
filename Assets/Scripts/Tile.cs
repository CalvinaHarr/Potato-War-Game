using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Unit unit = null;
    public GameObject atkHighlight, cuHighlight;
    public Color player1, player2;
    public int xPos,yPos;
    private SpriteRenderer sr;
        
    public void SetColor(bool isPlayer1)
    {
        if(isPlayer1)
        {
            this.GetComponent<Renderer>().material.color = player1;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = player2;
        }
    }

    void OnMouseEnter()
    {
        if(this.hasUnit())
        {
            atkHighlight.SetActive(true);
        }
        else
        {
            atkHighlight.SetActive(false); 
        }
    }

    void OnMouseExit()
    {
        atkHighlight.SetActive(false);
    }

    public bool hasUnit()
    {
        return unit != null;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(this.unit + ": " + this.unit.myTurn);
        if(unit.myTurn)
        {
            cuHighlight.SetActive(true);
        }
        else
        {
            cuHighlight.SetActive(false);
        }
    }
}
