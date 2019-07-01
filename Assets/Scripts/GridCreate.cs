using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour
{	
	public float GridLength;
	public float GridWidth;
	public float GridElementSpacing;
	
	public GameObject GridElement;

    void Start()
    {
		SpawnGridMap();
    }
	
	private void SpawnGridMap()
	{
		for(float i=-GridLength/2; i<=GridLength/2; i++)
		{
			for(float j=-GridWidth/2; j<=GridWidth/2; j++)
			{
				GameObject _grid = Instantiate(GridElement) as GameObject;
				_grid.transform.position = new Vector3(i, -1f, j);
				_grid.SetActive(true);
			}
		}
	}

    
	void Update()
    {
        
    }
}
