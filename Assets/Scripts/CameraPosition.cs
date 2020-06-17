using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public bool MaintainWidth = true;
    [Range(-1, 1)]
    public int AdaptPosition;

    private float defaultWidth;
    private float defaultHeight;
    private Vector3 cameraPos;



    // Start is called before the first frame update
    void Start()
    {
        cameraPos = Camera.main.transform.position;

        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Debug.Log($"Height: {defaultHeight}, Width: {defaultWidth}");
    }

    // Update is called once per frame
    void Update()
    {
        if (MaintainWidth)
        {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
            Camera.main.transform.position = new Vector3(
                cameraPos.x,
                AdaptPosition * (defaultWidth - Camera.main.orthographicSize),
                cameraPos.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(
                AdaptPosition * (defaultWidth - Camera.main.orthographicSize),
                cameraPos.y,
                cameraPos.z);
        }
    }
}
