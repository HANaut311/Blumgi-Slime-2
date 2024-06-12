using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{   
    public static UI instance;

    //public BoardPopup boardPopup;
    [HideInInspector] public Animator anim;
    public GraphicRaycaster m_Raycaster;
    [SerializeField] private Text levelText;
    [SerializeField] private int maxLevel = 150; // Số màn chơi tối đa

    public GameObject board;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private UI_VolumeSlider[] volumeSlider;

    private void Awake()
    {   
        if(instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        for (int i = 0; i < volumeSlider.Length; i++)
        {
            volumeSlider[i].GetComponent<UI_VolumeSlider>().SetupVolumeSlider();
        }
        anim = GameObject.Find("Board").GetComponent<Animator>();
    }

    public bool IsOnUI(){
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        m_Raycaster.Raycast(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void RestartGameButton()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    public void UpdateLevelText(int currentText)
    {
        if(levelText != null)
        {
            levelText.text = "Level " + currentText + " / " + maxLevel;
            if(SceneManager.GetActiveScene().buildIndex == 0)
                levelText.text = "Blumgi Slime";
        }
    }


}
