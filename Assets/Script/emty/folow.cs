using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class folow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        distance = 20;
        height1 = 0;

    }
    public Transform target; 
  public static float distance = 7; 
    public  float height = 0f;   
    public static float height1 = 0f; 
    public float heightDamping = 2.0f; 
    public float heightDamping1 = 2.0f; 
    public float rotationDamping = 3.0f;


    float wantedRotationAngle;
    float wantedHeight;
    float wantedHeight1;
    float currentRotationAngle;
    float currentHeight;
    float currentHeight1;
    void Update () {
        // 
 
        if (!target)
            return;
       
              wantedRotationAngle = target.eulerAngles.y;
              wantedHeight = target.position.y + height;
              wantedHeight1 = target.position.x + height1;
              currentRotationAngle = transform.eulerAngles.y;
              currentHeight = transform.position.y;
              currentHeight1 = transform.position.x;

            // độ trễ góc quay theo trục y
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            // độ trễ folow theo trục y
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            // độ trễ folow theo trục x
            currentHeight1 = Mathf.Lerp(currentHeight1, wantedHeight1, heightDamping1 * Time.deltaTime);
            // Convert the angle into a rotation
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            transform.position = new Vector3(currentHeight1, Mathf.Clamp(currentHeight, -1, 7), target.position.z - distance);
        
    }  
}
