using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musuhtb : MonoBehaviour
{
   public int health = 100;
   public void TakeDamage(int damage){
    health-=damage;
    if(health<=0){
        Die();
    }
   }
   void Die(){
    SceneManager.LoadScene("2");
   }
}
