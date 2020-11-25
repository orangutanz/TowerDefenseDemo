using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private int _value;


    public int Value { get { return _value; } private set { _value = value; } }
    void Start()
    {
    }
    public void OnMouseDown()
    {
        LevelManager.AddScore(_value);
        AudioManager.Get().PlayCoinSound();
        Destroy(this.gameObject);
    }

    public int Collect()
    {
        return Value;
    }
}
