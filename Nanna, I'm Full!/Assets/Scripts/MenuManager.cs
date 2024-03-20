using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] mainMenuUI; // Assign all the UI elements of the main menu here
    [SerializeField] private GameObject creditsImage; // Assign your credits image here
    [SerializeField] private GameObject backButton; // Assign your back button here

    // Call this function to show the credits
    private void ShowCredits()
    {
        // Hide the specified main menu objects
        foreach (GameObject obj in mainMenuUI)
        {
            obj.SetActive(false);
        }
        
        // Show the credits and back button
        creditsImage.SetActive(true);
        backButton.SetActive(true);
    }

    // Call this function when the back button is pressed
    private void HideCredits()
    {
        // Hide the credits and back button
        creditsImage.SetActive(false);
        backButton.SetActive(false);

        // Show the specified main menu objects
        foreach (GameObject obj in mainMenuUI)
        {
            obj.SetActive(true);
        }
    }

    // You might need to adjust the event listeners for your buttons to call these methods.
}