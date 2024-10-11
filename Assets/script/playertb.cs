using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playertb : MonoBehaviour
{
   public int health = 100;
   public void TakeDamage1(int damage){
    health-=damage;
    if(health<=0){
        Die();
    }
   }
   void Die(){
    SceneManager.LoadScene("2");
   }
}
