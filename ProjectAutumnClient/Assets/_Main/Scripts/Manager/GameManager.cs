using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CerenityStudio
{
    public class GameManager : MonoBehaviour
    {
        public void LoadLvl01()
        {
            SceneManager.LoadScene("Level01");
        }
    }
}
