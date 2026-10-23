using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;
    public float cooldownTime; // Cooldown time in seconds
    private float nextFireTime = 0f; // Time when the player can fire again

    // Start is called before the first frame update
    void Start()
    {
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (fireAction.triggered && Time.time >= nextFireTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextFireTime = Time.time + cooldownTime;
        }
    }

}
