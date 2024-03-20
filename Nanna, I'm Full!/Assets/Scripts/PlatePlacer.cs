using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatePlacer : MonoBehaviour
{
    [SerializeField] private GameObject spawnPointFood;
    [SerializeField] private GameObject spawnPointCleanPlate;
    [SerializeField] private GameObject platePrefab;
    [SerializeField] private GameObject cleanPlatePrefab;
    private Vector3 originalCleanPlateSpawnPointPosition;

    
    [SerializeField] private GrandmaController grandmaController; // Add this public variable


    public int numOfPlates { get; set; } = 0;
    public int numOfCleanPlates { get; set; } = 0;

    public float plateHealth { get; set; } = 3;

    [SerializeField] private List<GameObject> plates = new List<GameObject>();
    [SerializeField] private List<GameObject> cleanPlates = new List<GameObject>();
    // Start is called before the first frame update

    private void Start()
    {
        plateHealth = 3;
        originalCleanPlateSpawnPointPosition = spawnPointCleanPlate.transform.position;

    }

    public void PlacePlate()
    {
        numOfPlates++;
        GameObject newPlate = Instantiate(platePrefab, spawnPointFood.transform.position, Quaternion.identity);
        newPlate.transform.parent = transform;
        plates.Add(newPlate);
        spawnPointFood.transform.position += Vector3.up;
        Debug.Log("Number of Plates: " + numOfPlates);

        if (spawnPointFood.transform.position.y >= 5)
        {
            PlateCrashing();
        }
    }
    
    public void PlaceCleanPlate()
    {
        numOfCleanPlates++;
        GameObject newCleanPlate = Instantiate(cleanPlatePrefab, spawnPointCleanPlate.transform.position, Quaternion.identity);
        newCleanPlate.transform.parent = transform;
        cleanPlates.Add(newCleanPlate);
        spawnPointCleanPlate.transform.position += Vector3.up;
        Debug.Log("Number of Plates: " + numOfCleanPlates);
        
        if (numOfCleanPlates >= 5)
        {
            if (grandmaController != null)
            {
                Debug.Log("It works!");
                grandmaController.HandlePlatesState();
                //Invoke("grandmaController.ReturnToOriginalAndHandlePlates", 2); // Wait 2 seconds then call the method
            }
        }
    }

    public void RemovePlate()
    {
        plateHealth = 3;
        numOfPlates--;
        if (plates.Count > 0)
        {
            Destroy(plates[0]);
            plates.RemoveAt(0);
            spawnPointFood.transform.position += Vector3.down;
            foreach (GameObject plate in plates)
            {
                plate.transform.position += Vector3.down; // Move the plate down (adjust the Vector3 as needed)
            }

        }
    }
    
    public void HandleCleanPlates()
    {
        foreach (GameObject cleanPlate in cleanPlates)
        {
            Destroy(cleanPlate); // Remove the clean plate
        }
        cleanPlates.Clear();
        numOfCleanPlates = 0;
        spawnPointCleanPlate.transform.position = originalCleanPlateSpawnPointPosition;
    }
    
    private void PlateCrashing()
    {
        Debug.Log("All the plates are crashing!!!!");
        SceneManager.LoadScene("EndScreen");
    }
}