using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float health;
    public float defense;//Percentage
    public float speed;
    public int xPos, yPos;
    // public static int moveSlots; 
    public Move[] moveSet;
    public bool used, myTurn;
    public Move currentMove;
    public Unit opponent;

    void OnMouseDown()
    {
        if(!myTurn)
        {
            this.TakeDamage(currentMove.damage);
            currentMove.user.EndTurn();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        used = false;
        myTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Takes an amount of damage. The more defense unit has, the less damage it takes.
    public void TakeDamage(float dmg)
    {
        health = health - (dmg - (dmg * (defense / 100)));
    }

    public void StartTurn()
    {
        myTurn = true;
        // Debug.Log(this + ": " + this.myTurn);
        for(int i = 0; i < moveSet.Length; i++)
        {
            moveSet[i] = Instantiate(moveSet[i], new Vector3(xPos,yPos+(i*50)), Quaternion.identity);
            moveSet[i].user = this;
        }
    }

    public void EndTurn()
    {
        used = true;
        myTurn = false;
        for(int i = 0; i < moveSet.Length; i++)
        {
            Destroy(moveSet[i]);
        }
    }
}