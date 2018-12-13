using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour 
{
	public GameObject columnPrefab;									//The column game object.
	public int columnPoolSize = 5;									//Amount of columns 
	public float spawnRate = 4f;									//columns spawn.
	public float columnMin = -1f;									//Minimum y value of the column position.
	public float columnMax = 3.5f;									//Maximum y value of the column position.
    private GameObject[] columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		columns = new GameObject[columnPoolSize];
		
		for(int i = 0; i < columnPoolSize; i++)
		{
			//create the individual columns.
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}

    	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(columnMin, columnMax);

			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}