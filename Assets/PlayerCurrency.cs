using UnityEngine;
using System.Collections;

public class PlayerCurrency : MonoBehaviour {

    public float IMoney;

    private float money = 0;
    private float max_money = 5000;

	// Use this for initialization
	void Start () {
        money = IMoney;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateInspectorVars();
	}

    private void UpdateInspectorVars()
    {
        IMoney = money;
    }

    public float AdjustMoney(float delta)
    {
        money = Mathf.Clamp(money += delta, 0, max_money);
        return money;
    }
}
