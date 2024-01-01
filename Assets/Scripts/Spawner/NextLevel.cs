using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Spawner
{
    public class NextLevel : MonoBehaviour
    {
        public void Next()
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerData.Instance.Point = 0;
            SceneManager.LoadScene(0);
        }
    }
}