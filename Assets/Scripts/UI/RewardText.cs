using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardText : MonoBehaviour {
	public Text rewardText;


	int accumulatedFund = 0;

	IEnumerator updateRewardTextCo = null;

	void Start() {
		rewardText = GameObject.Find("UI/InGameUI/Info/RewardText").GetComponent<Text>();
	}

	public void Show( int fund) {
		if(updateRewardTextCo != null) StopCoroutine(updateRewardTextCo);

	
		accumulatedFund += fund;

		rewardText.text =  "\nFund +" + accumulatedFund + " $";

		updateRewardTextCo = Hide();
		StartCoroutine(updateRewardTextCo);
	}

	IEnumerator Hide() {
		yield return new WaitForSeconds(5f);
		rewardText.text = "";
	
		accumulatedFund = 0;

		yield break;
	}
}
