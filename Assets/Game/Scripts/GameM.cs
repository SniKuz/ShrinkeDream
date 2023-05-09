using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.MainRoom;

public class GameM : MonoBehaviour
{
    public DialogueController diC;
    public MemoContorller memoC;

    public void NextMemo()
    {
        memoC.NextDay();
    }
}
