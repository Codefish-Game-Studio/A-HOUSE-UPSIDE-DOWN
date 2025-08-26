using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    public Texture2D hoverCursor;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit)
        {
            GameObject hitObject = hit.collider.gameObject;
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);

            Debug.Log("Mouse over " + hitObject + ".");

            if (Input.GetMouseButtonDown(0))
            {
                if (hitObject.CompareTag("SelectableObject"))
                {
                    SelectableObjects selectedObject = hitObject.GetComponent<SelectableObjects>();
                    GameManager.Instance.CheckObjectID(selectedObject.id);

                    Debug.Log(selectedObject.id + " selected.");
                }
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
