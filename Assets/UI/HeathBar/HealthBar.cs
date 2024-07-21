using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image FillBar;
    public TextMeshProUGUI ValueText;

    public void UpdateBar(int CurrentValue,int MaxValue)
    {
        FillBar.fillAmount = (float)CurrentValue/ (float)MaxValue;
        ValueText.text = CurrentValue.ToString() + " / " + MaxValue.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
