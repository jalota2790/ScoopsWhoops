using UnityEngine;

public static class Utils
{
    //Converts screen position to world position
    public static Vector3 GetWorldPosition(Vector3 inputPosition)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(inputPosition);
        position.z = 0;
        return position;
    }

    //Clamp vector value to min and max
    public static Vector3 ClampVector3(Vector3 input, Vector3 min, Vector3 max)
    {
        input.x = Mathf.Clamp(input.x, min.x, max.x);
        input.y = Mathf.Clamp(input.y, min.y, max.y);
        input.z = Mathf.Clamp(input.z, min.z, max.z);

        return input;
    }

    //Translates tranform object clamped
    public static void TranslateClamped(this Transform transform, Vector3 translation, Vector3 minPosition, Vector3 maxPosition)
    {
        transform.Translate(translation);
        transform.position = Utils.ClampVector3(transform.position, minPosition, maxPosition);
    }
}
