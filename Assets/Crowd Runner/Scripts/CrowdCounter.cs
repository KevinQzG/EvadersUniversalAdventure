using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CrowdCounter : MonoBehaviour
{

[Header ("Elements")]
[SerializeField] private TextMeshPro crowdCounterText;
[SerializeField] private Transform runnersParent;
    void Start()
    {
        
    }

    void Update()
    {
        crowdCounterText.text = runnersParent.childCount.ToString();
    }
}
