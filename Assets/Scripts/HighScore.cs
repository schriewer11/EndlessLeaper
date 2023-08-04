using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI highScore = GetComponent<TextMeshProUGUI>();
        highScore.text = StateNameController.Score;
    }
}
