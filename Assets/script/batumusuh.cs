using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class batumusuh : MonoBehaviour
{
public Transform firepoint;
public GameObject batuprefab;
void Start(){
        Roulette hasil = gameObject.AddComponent<Roulette>();
        if (hasil.playerResult == "paper" && hasil.enemyResult == "scissors")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            print("Enemy attacks player!");
        }
        else if (hasil.playerResult == "rock" && hasil.enemyResult == "paper")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            print("Enemy attacks player!");
        }
        else if (hasil.playerResult == "scissors" && hasil.enemyResult == "rock")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            print("Enemy attacks player!");
        }
        else
        {
            print("It's a tie!");
        }
}
}
