using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

	public static void reset()
    {
        SceneManager.LoadScene(Game.current);
    }
}
