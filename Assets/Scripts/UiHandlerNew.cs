using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiHandlerNew : MonoBehaviour
{

    private VisualElement m_HealthBar;
    public static UiHandlerNew Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Plus d'une instance de UiHandlerNew trouvée!");
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        try
        {
           
           
            m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        }
        catch (Exception e)
        {
            Debug.LogError("Erreur lors de la récupération de HealthBar: " + e.Message);
        }

        SetHealthValue(1f);
    }



    public void SetHealthValue(float percentage)
    {
       m_HealthBar.style.width = Length.Percent(100 * percentage);
       Debug.Log(percentage.ToString());
    }


}
