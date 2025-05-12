using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField] private Canvas Canvas;
    [SerializeField] private GameObject CellPrefab;

    private void Awake() {
        CellPrefab = (GameObject)Resources.Load("Cell");
        
    }

    private void Start() {
        GenerateSimpleGrid(16, 7);
        Debug.Log($"Canvas scale factor is: {Canvas.scaleFactor}");
    }

    private void GenerateSimpleGrid(int a, int b) {
        float offset = 0.35f;//cell size
        float startPosZ = -a*offset/2;
        float startPosY = -b*offset/2;

        for (int i = 0; i < a; i++) {
            for (int j = 0; j < b; j++) {
                GameObject temObject = Instantiate(CellPrefab, new Vector3((j*offset+startPosY)*Canvas.scaleFactor, 0, (i*offset+startPosZ)*Canvas.scaleFactor), Quaternion.identity);
            }
        }
    }
}
