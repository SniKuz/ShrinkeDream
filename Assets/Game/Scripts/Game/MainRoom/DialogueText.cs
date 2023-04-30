using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueText
{
    public string Name;
    public Dialogue[] Dialogues;
    public SelectButton[] SelectButtons;
    public int DialogueLength => Dialogues.Length;
    public int DuttonLength => SelectButtons.Length;

    [System.Serializable]
    public struct Dialogue
    {
        public string LeftName;
        public Sprite LeftSprite;
        public string RightName;
        public Sprite RightSprite;
        public string Context;
    }

    [System.Serializable]
    public struct SelectButton
    {
        public string NextDialogueName;
        public string Context;
    }
}
