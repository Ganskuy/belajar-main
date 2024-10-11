using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruletgpt : MonoBehaviour
{
    public float RotatePower;
    public float StopPower;

    private Rigidbody2D rbody;
    int inRotate;

    // Stores the result (paper, scissors, rock) for both player and enemy
    public string playerResult;
    public string enemyResult;
    
    // Player's attack setup
    public Transform firepoint;
    public GameObject batuprefab;

    // Enemy's attack setup
    public Transform enemyFirepoint;
    public GameObject enemyBatuprefab;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    float t;
    private void Update()
    {           
        if (rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= StopPower * Time.deltaTime;
            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }

        if (rbody.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                GetReward();
                inRotate = 0;
                t = 0;
            }
        }
    }

    public void Rotate() 
    {
        if (inRotate == 0)
        {
            rbody.AddTorque(RotatePower);
            inRotate = 1;
        }
    }

    public void GetReward()
    {
        float rot = transform.eulerAngles.z;

        // Normalize the angle between 0 and 360
        if (rot >= 0 && rot <= 120)
        {
            playerResult = "paper"; // Player gets paper
        }
        else if (rot > 120 && rot <= 240)
        {
            playerResult = "scissors"; // Player gets scissors
        }
        else if (rot > 240 && rot <= 360)
        {
            playerResult = "rock"; // Player gets rock
        }

        Debug.Log("Player chose: " + playerResult);

        // Set a random enemy result
        SetRandomEnemyResult();

        // After the player result and enemy result are set, check the result
        CheckBattleOutcome();
    }

    public void SetRandomEnemyResult()
    {
        // Simulating the enemy result by picking a random choice
        int randomChoice = Random.Range(0, 3); // Randomly pick a number between 0 and 2
        if (randomChoice == 0)
        {
            enemyResult = "paper";
        }
        else if (randomChoice == 1)
        {
            enemyResult = "scissors";
        }
        else
        {
            enemyResult = "rock";
        }

        Debug.Log("Enemy chose: " + enemyResult);
    }

    public void CheckBattleOutcome()
    {
        if (playerResult == "paper" && enemyResult == "rock")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            Debug.Log("Player attacks enemy!");
        }
        else if (playerResult == "paper" && enemyResult == "scissors")
        {
            Instantiate(enemyBatuprefab, enemyFirepoint.position, enemyFirepoint.rotation);  // Enemy attacks
            Debug.Log("Enemy attacks player!");
        }
        else if (playerResult == "rock" && enemyResult == "scissors")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            Debug.Log("Player attacks enemy!");
        }
        else if (playerResult == "rock" && enemyResult == "paper")
        {
            Instantiate(enemyBatuprefab, enemyFirepoint.position, enemyFirepoint.rotation);  // Enemy attacks
            Debug.Log("Enemy attacks player!");
        }
        else if (playerResult == "scissors" && enemyResult == "paper")
        {
            Instantiate(batuprefab, firepoint.position, firepoint.rotation);
            Debug.Log("Player attacks enemy!");
        }
        else if (playerResult == "scissors" && enemyResult == "rock")
        {
            Instantiate(enemyBatuprefab, enemyFirepoint.position, enemyFirepoint.rotation);  // Enemy attacks
            Debug.Log("Enemy attacks player!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }
    }
}
