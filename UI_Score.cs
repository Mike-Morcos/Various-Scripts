using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = Nectar.nectarCount.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Nectar.nectarCount.ToString();
    }
}
