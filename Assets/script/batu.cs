using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batu : MonoBehaviour
{
public Transform firepoint;
public GameObject batuprefab;
void Start(){
        Roulette hasil = gameObject.AddComponent<Roulette>();
        if (hasil.playerResult == "paper" && hasil.enemyResult == "rock")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            print("Player attacks enemy!");
        }
        else if (hasil.playerResult == "rock" && hasil.enemyResult == "scissors")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            print("Player attacks enemy!");
        }
        else if (hasil.playerResult == "scissors" && hasil.enemyResult == "paper")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            print("Player attacks enemy!");
        }
        else
        {
            print("It's a tie!");
        }
}
}

