using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Transition;

public class DialogueController : MonoBehaviour
{
    [Header("Metadata")]
    public GameObject RayBlocker;
    [SerializeField]
    TextMeshProUGUI _dialogueText;
    [SerializeField]
    Button _nextButton;
    [SerializeField]
    TextMeshProUGUI _leftNameText;
    [SerializeField]
    TextMeshProUGUI _rightNameText;
    [SerializeField]
    Image _leftStandImage;
    [SerializeField]
    Image _rightStandImage;
    [SerializeField]
    Button _selectButtonPrefab;
    [Header("Dialogues")]
    public DialogueText[] dialogueTexts;
    public string currentDialogueName;
    public int currentDialogueIndex;

    [HideInInspector] public bool isEndDialogue = false;

    private Dictionary<string, DialogueText> _dialogueDic = new();
    [HideInInspector] public List<Button> sebuttons = new();

    #region Base
    public void Init()
    {
        isEndDialogue = false;

        foreach (DialogueText diaText in dialogueTexts)
        {
            _dialogueDic[diaText.Name] = diaText;
        }

        _nextButton.interactable = true;
        RayBlocker.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Show()
    {
        Init();
        NextDialogueText();
        RayBlocker.SetActive(true);
        gameObject.SetActive(true);
    }

    public void Close()
    {
        isEndDialogue = true;
        Debug.Log("asdad" + isEndDialogue);
        RayBlocker.SetActive(false);
        gameObject.SetActive(false);
    }
    #endregion

    public void NextDialogueText()
    {
        if (currentDialogueName == "END") { Close(); return; }

        DialogueText dialogueT = _dialogueDic[currentDialogueName];
        if (currentDialogueIndex >= dialogueT.DialogueLength)
        {
            if (dialogueT.DuttonLength < 1)
            {
                Close();
                return;
            }

            // 버튼생성
            _nextButton.interactable = false;
            foreach (DialogueText.SelectButton selectButton in dialogueT.SelectButtons)
            {
                SetButton(selectButton.NextDialogueName, selectButton.Context);
            }
        }
        else
        {
            _nextButton.interactable = true;
            SetDialogue(dialogueT.Dialogues[currentDialogueIndex++]);
        }
    }

    private void SetButton(string nextDialogueName, string context)
    {
        Button btn = Instantiate(_selectButtonPrefab, _selectButtonPrefab.transform.parent);
        TextMeshProUGUI btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
        if (btnText != null) btnText.text = context;
        btn.onClick.AddListener(() =>
        {
            currentDialogueName = nextDialogueName;
            currentDialogueIndex = 0;
            DestroyButton();
            NextDialogueText();
        });
        sebuttons.Add(btn);
        btn.gameObject.SetActive(true);
    }

    private void DestroyButton()
    {
        foreach(Button btn in sebuttons)
        {
            Destroy(btn.gameObject);
        }
        sebuttons.Clear();
    }

    private void SetDialogue(DialogueText.Dialogue dialogue)
    {
        BlackMirror(dialogue.isRight);

        _dialogueText.text = dialogue.Context;
        _leftNameText.text = dialogue.LeftName;
        if (dialogue.LeftSprite == null)
            _leftStandImage.gameObject.SetActive(false);
        else
        {
            _leftStandImage.sprite = dialogue.LeftSprite;
            _leftStandImage.gameObject.SetActive(true);
        }
        _rightNameText.text = dialogue.RightName;
        if (dialogue.RightSprite == null)
            _rightStandImage.gameObject.SetActive(false);
        else
        {
            _rightStandImage.sprite = dialogue.RightSprite;
            _rightStandImage.gameObject.SetActive(true);
        }
    }

    private void BlackMirror(bool isRight)
    {
        if (isRight)
        {
            Color lc = _leftStandImage.color;
            lc.a = 0.7f;
            _leftStandImage.color = lc;
            Color rc = _rightStandImage.color;
            rc.a = 1.0f;
            _rightStandImage.color = rc;
        } else
        {
            Color rc = _rightStandImage.color;
            rc.a = 0.7f;
            _rightStandImage.color = rc;
            Color lc = _leftStandImage.color;
            lc.a = 1.0f;
            _leftStandImage.color = lc;
        }
    }
}
