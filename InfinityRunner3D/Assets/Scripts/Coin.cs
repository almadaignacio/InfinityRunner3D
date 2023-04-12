using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    public Text CoinText;
    public int coinCounter;

    public float turnSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }

        Destroy(gameObject);
        //coinCounter++;
       // CoinText.text = coinCounter.ToString("0");

        GameManager.inst.incrementScore();
    }

    
}
