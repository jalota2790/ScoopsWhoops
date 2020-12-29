using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    //If object is currently being dragged
    public bool IsDragging { get; internal set; }

    //Offset between mouse position and object pivot
    private Vector3 offset;

    public bool useBounds;
    public Vector3 minScreenBounds;
    public Vector3 maxScreenBounds;

    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(0)) MouseDown();
        else if (Input.GetMouseButtonUp(0)) MouseUp();
        if (IsDragging) MouseDrag();
    }

    private void MouseDown()
    {
        //Begin drag
        if (!IsDragging)
        {
            IsDragging = true;
            OnBeginDrag();
        }

        //Calculate offset on mouse down
        offset = Utils.GetWorldPosition(Input.mousePosition) - transform.position;
    }

    private void MouseDrag()
    {
        if (useBounds)
        {
            transform.position = Utils.ClampVector3(Utils.GetWorldPosition(Input.mousePosition) - offset, minScreenBounds, maxScreenBounds);
        }
        else
        {
            transform.position = Utils.GetWorldPosition(Input.mousePosition) - offset;
        }

        offset = Utils.GetWorldPosition(Input.mousePosition) - transform.position;
    }

    private void MouseUp()
    {
        //End drag
        if (IsDragging)
        {
            IsDragging = false;
            OnEndDrag();
        }
    }

    //Virtual functions to implement in child classes
    public virtual void OnBeginDrag() { }
    public virtual void OnEndDrag() { }
}
