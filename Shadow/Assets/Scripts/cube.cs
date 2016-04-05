
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
 
public class cube : MonoBehaviour {
 	int maxSamples=10;
    int index = 0;
    int len = 0;
//	Vector3[] trail;       

    bool isRec = false;
	bool doPlay = false;
	bool playedNoRep = false;
	public Vector3 startPosi;


    Vector3[] vectorArray= new Vector3[1000];
    bool clickedBefore  = false;
    int currentArrayPos = 0;


	void Start () {
		print ("I am a cube"); 
//		trail = new Vector3[maxSamples];
	}

	// Update is called once per frame
	void Update () {
		//sprint (Input.GetAxis ("Horizontal"));
		transform.Translate ( Input.GetAxis ("Horizontal")*2* Time.deltaTime, 0f, 0f);
		transform.Translate (  0f,  Input.GetAxis ("Vertical")*2* Time.deltaTime, 0f);

     if (playedNoRep == true) {
         doPlay = false;
     }
    if(Input.GetMouseButtonDown(0)){
    	isRec=true;
    }

	if( isRec == true){
        print(currentArrayPos);
        currentArrayPos = 0;
        vectorArray[currentArrayPos] = Input.mousePosition;
		print(vectorArray[currentArrayPos]);
        clickedBefore = true;
        currentArrayPos++;
    } 
       if(doPlay == true){
         
         doPlay = false;
         Debug.Log(doPlay);

/*        int i = index % maxSamples;
        trail[i] = Input.mousePosition;
        index++;
        if (len < maxSamples){
        	len++;   */
    }
}

public void Record () {
     if (isRec == true) {
         isRec = false;
         transform.position = startPosi;
         GetComponent<Camera>().enabled = false;
     }
     else if (isRec == false) {
         GetComponent<Camera>().enabled = true;
         startPosi = transform.position;
         isRec = true;
         doPlay = false;
     }
 }
 public void Play () {
     GetComponent<Camera>().enabled = false;
 }


    



}



   
  /*  public int GetLen() {
        return len;
    }
   
    public int GetPos() {
        return index;
    }
   
    public bool IsValid(int stamp) {
        return !((stamp >= index) || (stamp < index - len));
    }
   
    public Vector3 GetHistory(int stamp) {
        if ((stamp >= index) || (stamp < index - len)) {
            throw new Exception("trying to read at offset " + stamp + " but have only " + len + " elements, pos " + index);
        }
        return trail[stamp % maxSamples];
    }*/
