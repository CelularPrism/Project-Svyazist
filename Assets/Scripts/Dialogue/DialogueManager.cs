using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private Image iconInterlocutor;
    [SerializeField] private GameObject phrasePrefab;

    [Header("Button Close Dialogue")]
    [SerializeField] private GameObject btnClose;

    private static DialogueManager _instance;
    private Story _curentStory;
    private PlayerAction _inputActions;

    public bool _dialogueIsPlaying { get; private set; }
    private const string SPEAKER_TAG = "speaker";

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Found more DialogueManager in the scene");
        }

        _instance = this;
        _inputActions = new PlayerAction();
        _inputActions.Player.Nextphrase.performed += perf => ContinueStory();
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    private void Start()
    {
        _dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!_dialogueIsPlaying)
        {
            return;
        }
    }

    private void ClearContent()
    {
        iconInterlocutor.sprite = null;
        for (int i = contentPanel.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(contentPanel.transform.GetChild(i).gameObject);
        }
    }

    private string HandleTags(List<string> currentTags)
    {
        string value = "";
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');

            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be approptiately parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            if (tagKey == SPEAKER_TAG)
                value = tagValue;
        }
        return value;
    }

    private void ContinueStory()
    {
        if (_curentStory.canContinue)
        {
            GameObject phrase = Instantiate(phrasePrefab, contentPanel.transform);
            TextMeshProUGUI headMesh = phrase.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textMesh = phrase.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            textMesh.text = _curentStory.Continue();
            headMesh.text = HandleTags(_curentStory.currentTags);
        }
        else
        {
            btnClose.SetActive(true);
            //StartCoroutine(ExitDialogueMode());
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, Sprite sprite)
    {
        if (sprite != null)
            iconInterlocutor.sprite = sprite;

        _curentStory = new Story(inkJSON.text);
        _dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Debug.Log(dialoguePanel.activeSelf);
        _inputActions.Enable();
        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        _dialogueIsPlaying = false;

        btnClose.SetActive(false);
        dialoguePanel.SetActive(false);
        _inputActions.Disable();
        ClearContent();
    }
}
