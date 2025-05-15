using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private GameObject playerPrefab;
    public GameObject backgroundFolder;
    public GameObject playerObject { get; private set; }
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }
        playerObject = Instantiate(playerPrefab);
        DontDestroyOnLoad(playerObject);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }
}