using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Lecture1 : MonoBehaviour
{

    public float moveSpeed = 0.02f;
    public float rotationSpeed = 1f;

    public MyClass myClassInstance;



    public List<GameObject> myBoxes = new List<GameObject>();

    private void Start()
    {
        myClassInstance = new MyClass();

        if (myBoxes.Count > 2)
        {

            Debug.Log("More than 2 boxes are in the myBoxes List.");

        }
        else
        {
            Debug.Log(" 2 or less boxes are in the myBoxes List.");
        }

    }

    public void Update()
    {
        LoopExample();
    }

    public void LoopExample()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementAmount = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0f);


        for (int i = 0; i < myBoxes.Count; i++)
        {
            if (myBoxes[i] == null) {

                continue;
            }


            MoveTransform(myBoxes[i].transform, movementAmount);
        }
    }
    public void MoveTransform(Transform target, Vector3 movementAmount)
    {

        target.Translate(movementAmount);
    }


}







public class MyClass
{
    public int myWholeNumber;
    public string ClassName;
    private float secretValue;


}

