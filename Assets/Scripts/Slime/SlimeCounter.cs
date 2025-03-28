using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlimeCounter : MonoBehaviour
{
    public static SlimeCounter Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI slimeCountText;
    private int slimeCount = 0;
    
    public int SlimeCount
    {
        get 
        {
            return slimeCount;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateText()
    {
        if (slimeCountText != null)
        {
            slimeCountText.text = "Slimes: " + slimeCount;
        }
    }

    public void AddSlime()
    {
        slimeCount++;
        UpdateText();
    }
}