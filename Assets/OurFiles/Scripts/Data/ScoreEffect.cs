using TMPro;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
	//dlya testirovaniya plavnogo uvelicheniya ochkov
    public TextMeshProUGUI score;

	public float step;
	public float goal;
	public float nachalo;

	private void Update()
	{
		nachalo = Mathf.MoveTowards(nachalo, goal, 10.0f*Time.deltaTime);
	}
}
