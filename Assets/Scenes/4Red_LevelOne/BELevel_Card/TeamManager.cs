using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TeamManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject popInfoCN;
    public GameObject popInfoEN;
    public GameObject popLine;
    public GameObject confirm;
    public bool onlyOnce = false;
    public int num;
    public void Start()
    {
        AudioManager.Instance.PlaySFX(SoundEffect.Beep);
        confirm.SetActive(false);
        popInfoCN.SetActive(false);
        popInfoEN.SetActive(false);
        popLine.SetActive(false);
    }
    public void Update()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (onlyOnce)
        {
            confirm.SetActive(true);
        }
        else
        {
            AudioManager.Instance.PlaySFX(SoundEffect.PopUp);
            if (LanguageManager.Instance.currentLanguage == LanguageOption.Chinese)
            {
                popInfoCN.SetActive(true);
            }
            else
            {
                popInfoEN.SetActive(true);
            }
            popLine.SetActive(true);
            onlyOnce = !onlyOnce;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySFX(SoundEffect.PopUp);
        if(LanguageManager.Instance.currentLanguage == LanguageOption.Chinese)
        {
            popInfoCN.SetActive(true);
        }
        else
        {
            popInfoEN.SetActive(true);
        }
        popLine.SetActive(true);
        onlyOnce = !onlyOnce;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (LanguageManager.Instance.currentLanguage == LanguageOption.Chinese)
        {
            popInfoCN.SetActive(false);
        }
        else
        {
            popInfoEN.SetActive(false);
        }
        popLine.SetActive(false);
        onlyOnce = false;
    }
    public void PlayUISelect()
    {
        AudioManager.Instance.PlaySFX(SoundEffect.UISelect);
    }
    public void Rethink()
    {
        confirm.SetActive(false);
        onlyOnce = false;
    }
    public void PlayUIConfirm(int num)
    {
        AudioManager.Instance.PlaySFX(SoundEffect.UISelect);
        SaveManager.Instance.SetTeam(num);
        SaveManager.Instance.SaveLevel();
        SaveManager.Instance.LoadLevel();
    }
}

