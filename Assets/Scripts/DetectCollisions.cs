using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public int animalScore;
    private SpawnManager manager;
    public Slider hungerSlider;
    public int hungerValue;
    private int foodRecieved = 0;

    private void Start()
    {
        manager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        hungerSlider.maxValue = hungerValue;
        hungerSlider.value = hungerValue;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) 
        {
            FeedAnimal();
            Destroy(other.gameObject);
        }
    }

    void FeedAnimal()
    {
        foodRecieved += 1;
        manager.UpdateScore(animalScore);
        Debug.Log("Score:" + manager.GetScore());
        if (foodRecieved != hungerValue)
        {
            hungerSlider.value = hungerValue - foodRecieved;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
