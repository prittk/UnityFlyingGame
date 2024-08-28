using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] int rotationSpeed = 100;
    

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb =  GetComponent<Rigidbody>();
;    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();

    }

//control the thrust of the object
    void ProcessThrust()
    {

        if(Input.GetKey("space"))
        {
            Debug.Log("pressed Space");
            rb.AddRelativeForce(new Vector3(0,1,0) *mainThrust *  Time.deltaTime) ;
            //transform.Translate(Vector3.up * speed *Time.deltaTime);
        }
    }

    void ProcessRotate()
    {
        
        if(Input.GetKey("a"))
        {
            Debug.Log("pressed a");
            ApplyRotation(Vector3.left);
        }


        else if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("pressed d");
            ApplyRotation(Vector3.right);
            //transform.Rotate(Vector3.right*rotationSpeed* Time.deltaTime);
        }

    }

    public void ApplyRotation(Vector3 rotateCordinate)
    {
        rb.freezeRotation = true; //freeze rotation so we can manually rotate
        transform.Rotate(rotateCordinate * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false; //unfrerze rotation    
    }
}
