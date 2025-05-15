using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    private float distance;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (target)
        {
            distance = (gameObject.transform.position - target.transform.position).magnitude;
            if (distance < 4)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position + new Vector3(0, 0, gameObject.transform.position.z), Time.deltaTime / 3);
            }
            else
            {
                print("cannot reach");
            }
        }
        else
        {
            target = GameObject.Find("Player(Clone)");
        }
    }
}