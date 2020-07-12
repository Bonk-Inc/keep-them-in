using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject())
            {
                Tile hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile == null)
                    return;

                hitTile.buildObject();
                
            }
        }
    }
}
