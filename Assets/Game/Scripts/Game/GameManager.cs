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
        [Header("Day")]
        public int CurruntDay = 0;

        private void OnEnable()
        {
            Controllers = GameObject.FindGameObjectsWithTag("Controller");
            foreach (GameObject ct in Controllers)
            {
                ct.TryGetComponent(out SceneController);

                if (SceneController != null)
                    break;
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