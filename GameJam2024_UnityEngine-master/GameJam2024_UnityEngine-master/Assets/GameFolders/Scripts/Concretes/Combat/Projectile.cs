using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] bool isLeftSide = false;

    public float speed = 10;
    float _currentTime = 0;
    float _maxTime = 2f;

    private void Start()
    {
        if (isLeftSide)
        {
            speed = -speed;
        }
    
    }

    void Update()
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        _currentTime += Time.deltaTime;

        if ( _currentTime > _maxTime) 
        { 
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}