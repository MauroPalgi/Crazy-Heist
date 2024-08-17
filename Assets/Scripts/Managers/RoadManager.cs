using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadManager : Singleton<RoadManager>
{
    private List<ScriptableRoad> _roads;
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnOrientation = Quaternion.identity;
    private Dictionary<RoadType, ScriptableRoad> scriptableRoads;
    [SerializeField] private int numberOfRoads = 10;

    void Start()
    {
        scriptableRoads = ResourceSystem.Instance.GetAllRoad();
        _roads = new List<ScriptableRoad>();
        FillRoadListWithRandomValues();
    }

    private void FillRoadListWithRandomValues()
    {
        // Convertir las claves del diccionario en una lista para seleccionar valores aleatorios
        List<RoadType> availableRoads = scriptableRoads.Keys.ToList();

        for (int i = 0; i < numberOfRoads; i++)
        {
            // Elegir un valor aleatorio de la lista de claves
            RoadType randomRoadType = availableRoads[Random.Range(0, availableRoads.Count)];

            // Agregar el ScriptableRoad correspondiente a la lista _roads
            _roads.Add(scriptableRoads[randomRoadType]);

            Debug.Log(randomRoadType.ToString());
        }
    }

    public void SpawnRoads()
    {
        for (int i = 0; i < 2; i++)
        {
            // Aquí puedes implementar la lógica para generar las carreteras en la escena
            ScriptableRoad road = _roads[i];
            Debug.Log(road.PrefabLenght);

            Instantiate(road.Prefab, spawnPosition, spawnOrientation);
            Debug.Log(road);
            spawnPosition = new Vector3(spawnPosition.x + road.PrefabLenght, spawnPosition.y, spawnPosition.z);

            // Instanciar la carretera en la escena utilizando road.Prefab u otra propiedad relevante
        }
    }
}
