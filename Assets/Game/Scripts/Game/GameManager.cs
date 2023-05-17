using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        private static GameManager instance;
        public static GameManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        #endregion

        public SceneController SceneController;
        public GameObject[] Controllers;
        public AudioSource BGM_Audio;
        [Header("Charater")]
        public string CurrentCharacter = "Miller";
        [Header("Day")]
        public int CurruntDay = 0;
        [SerializeField]
        private int itemCount = 0;

        public int ItemCount //일정 itemcount가 되면 꿈신을 변경
        {
            get
            {
                return itemCount; 
            }
            set
            {
                itemCount = value;
            }
        }


        public void EXITGAME()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}