using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Variables that determine the width and length
    // of cells on the board.
    public int width;
    public int height;
    // Creates an empty 2 dimensional array.
    public GameObject[] dots;
    // Object to be created by the BoardSetUp() function.
    public GameObject tilePrefab; 
    // Variable for the container of all the tiles
    private BackgroundTile[,] allTiles;
    // All the dots in the game
    public GameObject[,] allDots;
    //-------------------------------------------------------------
    void Start()
    {
        // Declaring how big the container will be.
        allTiles = new BackgroundTile[width, height];
        // Declaring how many dots will be on the board
        allDots = new GameObject[width, height];
        // Calls the BoardSetUp() function.
        BoardSetUp();
    }
    //-------------------------------------------------------------
    // This function will instatiate all the background tiles.
    private void BoardSetUp()
    {
        // Nested for loop to instantiate a gameobject within
        // a certain cell location.
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                // creates a tempory position for the game object.
                Vector2 tempPosition = new Vector2(i, j);
                // Having unity create a gameObject (backgroundTile)
                // so that its variables can be manipulated.
                GameObject backgroundTile = Instantiate(tilePrefab, 
                tempPosition, Quaternion.identity) as GameObject;
                // setting the parent of the gameObject to this 
                // board object so all the tiles will be in there.
                backgroundTile.transform.parent = this.transform;
                // Naming the backgroundTile object to vector 
                // space coordinates.
                backgroundTile.name = "( " + i + ", " + j + " )";
                //-------------------------------------------------------------
                // Creating all the dots

                // Gets a random value based on the range of tiles array length.
                int randomTile = Random.Range(0, dots.Length);
                // Grabs a random tile from the array and instantaites it in its world space position.
                GameObject dot = Instantiate(dots[randomTile], tempPosition, Quaternion.identity);
                // The tile will be a child of the background tile it's spawned on.
                dot.transform.parent = this.transform;
                // calling the name of the dots ion certain positions
                dots[i].name = dots[i].name;

                // Adding the dots to the allDots array
                allDots[i, j] = dot;


            }
        }
    }
}
