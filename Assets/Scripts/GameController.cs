using UnityEngine;

public class GameController : MonoBehaviour {
    private Vector3 offset;
    private CarController selectedCar;
    private bool isDraggingCar = false;
    private float fixedY = 0f;

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                if (hit.transform.TryGetComponent(out CarController car)) {
                    selectedCar = car;

                    offset = selectedCar.transform.position - hit.point;
                    offset.y = 0f;
                    isDraggingCar = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            isDraggingCar = false;
            selectedCar = null;
        }

        if (isDraggingCar && selectedCar != null) {
            Plane groundPlane = new Plane(Vector3.up, new Vector3(0, fixedY, 0));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float distance)) {
                Vector3 worldPoint = ray.GetPoint(distance);
                Vector3 newPosition = worldPoint + offset;
                newPosition.y = fixedY;
                selectedCar.transform.position = newPosition;
            }
        }
    }
}
