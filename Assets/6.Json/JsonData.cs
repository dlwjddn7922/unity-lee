using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData : Singleton<JsonData>
{
    [SerializeField] private TextAsset playerJsonTxt;

    #region Player Data
    [System.Serializable]
    public class PlayerMainData
    {
        public string name;
        public float attdistance;
        public float attdelay;
        public int power;
        public int speed;
    }
    [System.Serializable]
    public class PlayerData
    {
        public List<PlayerMainData> player = new List<PlayerMainData>();
    }

    public PlayerData playerData = new PlayerData();
    #endregion
    // Start is called before the first frame update
    private void Awake()
    {
        playerData = JsonUtility.FromJson<PlayerData>(playerJsonTxt.ToString());
    }
}