using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRanking : MonoBehaviour
{
    [SerializeField]
    int stageLange;

    Stage stage;
    // Start is called before the first frame update
    void Start()
    {
        stage = StageManager.loadStage(1);
        Debug.Log(stage.rank.records[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
