using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI _continueText;
    [SerializeField] private GameObject _player;
    private GameObject _introduction;

    private void Awake()
    {
        _introduction = GetComponent<Introduction>().gameObject;
    }

    private void Start()
    {        
        StartCoroutine(ShowContinueText());
    }

    private void Update()
    {
        if(_continueText.gameObject.activeSelf && _introduction.activeSelf && Input.GetKeyDown(KeyCode.Q))
        {
           StartCoroutine(IntroductionScene());
        }
    }

    private IEnumerator ShowContinueText()
    {
        yield return new WaitForSeconds(5);
        _continueText.gameObject.SetActive(true);
    }

    private IEnumerator IntroductionScene()
    {
        SFXManager.instance.PlaySFX("OpenDoor");
        _introduction.SetActive(false);
        _player.SetActive(true);
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }
}
