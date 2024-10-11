using UnityEngine;

public class obstaclemove : MonoBehaviour
{
    public float speed;
    private float leftEdge;
    public int damage = 20;

    private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    public void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="player"){
        charamove mc = gameObject.AddComponent<charamove>();
        mc.berkurang(damage);
        Destroy(gameObject);
        }
    }
}

