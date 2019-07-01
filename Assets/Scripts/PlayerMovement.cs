using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 pos;                                
	public float speed = 4.0f; 

	public GridCreate GridData;
	
	public float LBound, RBound, TBound, BBound;
	
	bool UnBound = true;
     
    void Start () 
	{	
		BBound = -(GridData.GridWidth / 2f + 0.5f);
		TBound =  (GridData.GridWidth / 2f + 0.5f);
		
		RBound =  (GridData.GridLength / 2f + 0.5f);
		LBound = -(GridData.GridLength / 2f + 0.5f);
		
        pos = transform.position;          
    }
	
	void Update()
	{	
		if(UnBound)
		{
			if(transform.position.z >= TBound + 0.1f) MirrorTopDown(BBound);
			if(transform.position.z <= BBound - 0.1f) MirrorTopDown(TBound);
			
			if(transform.position.x >= RBound + 0.1f) MirrorLeftRight(LBound);
			if(transform.position.x <= LBound - 0.1f) MirrorLeftRight(RBound);
		}
	}
	
	void MirrorTopDown(float _z)
	{	
		UnBound = false;
		transform.position = new Vector3(transform.position.x, transform.position.y, _z);
		pos = transform.position;
		
		UnBound = true;
	}
	
	void MirrorLeftRight(float _x)
	{	
		UnBound = false;
		transform.position = new Vector3(_x, transform.position.y, transform.position.z);
		print(_x);
		pos = transform.position;
		
		UnBound = true;
	}

    void FixedUpdate () 
	{	
		//pos += Vector3.forward;
	
         if(Input.GetKey(KeyCode.A) && transform.position == pos) {        // Left
             pos += Vector3.left;
         }
         if(Input.GetKey(KeyCode.D) && transform.position == pos) {        // Right
             pos += Vector3.right;
         }
         if(Input.GetKey(KeyCode.W) && transform.position == pos) {        // Up
             pos += Vector3.forward;
         }
         if(Input.GetKey(KeyCode.S) && transform.position == pos) {        // Down
             pos += Vector3.back;
         }
         
		if(UnBound)
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
     }
}
