using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    int a = 10;
    int b = 20;
    float speed = 1.5f;
    bool onGround = false;
    string firstName = "Tung";
    string lastName = "Tran";
    public void MyName()
    {
        string fullName = firstName + " " + lastName;
        Debug.Log("My full name : " + fullName);
        int c = a + b;
        float f = speed * c;
        onGround = true;
        Cat myPet = new Cat();
        myPet.CatMakesSound();
    }
    private void Start()
    {
        this.MyName();
    }
}