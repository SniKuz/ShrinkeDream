using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Transition;
using Game;

namespace Game.MainRoom
{
    public class MemoContorller : MonoBehaviour
    {
        [Header("Metadata")]
        [SerializeField]
        GameObject _memoObject;
        [SerializeField]
        Button _showButton;

        public TypeAnimation[] DayMemoText;

        [Header("Setting Values")]
        public float ShowDuration = 1.0f;
        public float TypeDelay = 0.005f;

        private Queue<IEnumerator> _iemBuffer;
        private Coroutine _coroutine;

        [SerializeField]
        private bool isShow = false;
        [SerializeField]
        private float _originMemoY;
        [SerializeField]
        private int curruntDay = 0;

        private void Awake()
        {
            _showButton.onClick.AddListener(() => { Show(); });
            _showButton.onClick.AddListener(() => { Close(); });
            foreach (TypeAnimation tObj in DayMemoText)
            {
                tObj.transform.gameObject.SetActive(false);
                tObj.TypeDelay = TypeDelay;
            }
        }

        #region Ã¢ º¸±â
        public void Show()
        {
            if (isShow) return;

            _showButton.interactable = false;
            _iemBuffer = new Queue<IEnumerator>();
            _coroutine = StartCoroutine(AnimationProcess());

            _originMemoY = _memoObject.transform.localPosition.y;
            _iemBuffer.Enqueue(AnimMoveUp(_memoObject, 0, ShowDuration));

            if (curruntDay < GameManager.Instance.CurruntDay)
            {
                NextDay();
            }
        }

        public void Close()
        {
            if (!isShow) return;

            _showButton.interactable = false;
            _iemBuffer.Enqueue(AnimMoveUp(_memoObject, _originMemoY, ShowDuration));
            _iemBuffer.Enqueue(StopCoroutine());
        }

        IEnumerator StopCoroutine()
        {
            StopCoroutine(_coroutine);
            yield break;
        }

        IEnumerator AnimMoveUp(GameObject obj, float goal, float duration)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(obj.transform.DOLocalMoveY(goal, duration))
                .Play();

            yield return sequence.WaitForCompletion();
            _showButton.interactable = true;
            isShow = !isShow;
        }

        IEnumerator AnimationProcess()
        {
            while (true)
            {
                if (_iemBuffer.Count > 0)
                    yield return _iemBuffer.Dequeue();

                yield return null;
            }
        }
        #endregion

        #region Type
        public void NextDay()
        {
            if (curruntDay >= DayMemoText.Length) return;

            DayMemoText[curruntDay].transform.gameObject.SetActive(true);
            DayMemoText[curruntDay].Type();
            curruntDay++;
        }
        #endregion
    }
}