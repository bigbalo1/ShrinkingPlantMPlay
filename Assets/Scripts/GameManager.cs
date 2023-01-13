using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;

	public static bool isGameStarted;

	void Awake ()
	{
		instance = this;
	}

    private void Update()
    {

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
		{
			if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
				return;


			//isGameStarted = true;
			//gamePlayPanel.SetActive(true);
			//startMenuPanel.SetActive(false);
		}
	}
    public void EndGame ()
	{
		gameOverUI.SetActive(true);
	}

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
