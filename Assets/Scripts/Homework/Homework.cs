using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework : MonoBehaviour
{
    public int myNumber;
    public int myOtherNumber;

    private void Start()
    {
        SomeOthermethod();
    }

    public int HomeworkMethod3(int x, int y)
    {

        return x + y;
    }

    public void SomeOthermethod()
    {
        int value = HomeworkMethod3(myNumber, myOtherNumber);
        Debug.Log(value);
    }
}
