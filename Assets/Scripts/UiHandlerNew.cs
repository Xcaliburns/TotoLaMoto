using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UiHandlerNew : MonoBehaviour
{

    private VisualElement m_HealthBar;
    public static UiHandlerNew Instance { get; private set; }

    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue;
    private float m_TimerDisplay;
    private bool dialogIsOn;
    private VisualElement m_Background;
    private Label m_Text;



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
        m_HealthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1f);
        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialog");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;      
        m_Text = uiDocument.rootVisualElement.Q<Label>("textToDisplay");
        dialogIsOn = false;


    }

    private void Update()
    {
        //if (m_TimerDisplay > 0)
        //{
        //    m_TimerDisplay -= Time.deltaTime;

        //}
        //else
        //{
        //    m_NonPlayerDialogue.style.display = DisplayStyle.None;
        //}


    }

    //public void DisplayDialogue()
    //{
    //    if (m_TimerDisplay < 0)
    //    {

    //        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
    //        m_TimerDisplay = displayTime;
    //    }
    //}


    public void SetHealthValue(float percentage)
    {
        m_HealthBar.style.width = Length.Percent(100 * percentage);
        Debug.Log(percentage.ToString());
    }

    public void SetText(string textToDisplay)
    {
       if(m_Text != null)
           m_Text.text = textToDisplay;
           Debug.Log(textToDisplay);
    }

    public void OpenDialogWindow(bool dialogIsOn)
    {
        Debug.Log(dialogIsOn);
       
        if (dialogIsOn)
        {
            m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        }
        else
        {
            m_NonPlayerDialogue.style.display = DisplayStyle.None;
        }
    }


}
