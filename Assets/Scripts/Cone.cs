using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cone : DraggableObject
{
    public struct PositionedScoop
    {
        public Scoop scoop;
        public Vector3 position;
    }

    public Transform catchPosition;
    public float minimumCatchDistance;

    public List<PositionedScoop> scoops = new List<PositionedScoop>();

    public float scoopSize;

    public BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public override void Update()
    {
        base.Update();
        AdaptPosition();
    }

    int i = 0;
    void AdaptPosition()
    {
        for (i = 0; i < scoops.Count; i++)
        {
            scoops[i].scoop.transform.position = Vector3.Lerp(scoops[i].scoop.transform.position,
                transform.position + scoops[i].position, 1f / (i + 1));
        }
    }

    public int GetScoopsCount()
    {
        return scoops.Count;
    }

    public Vector3 GetLastScoopPosition()
    {
        return new Vector3(0, transform.position.y + scoops.Last().position.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!GameController.instance.isRunning) return;

        Scoop scoop = collision.GetComponent<Scoop>();

        if (scoop && Vector3.Distance(scoop.transform.position, catchPosition.position) < minimumCatchDistance)
        {
            scoops.Add(new PositionedScoop()
            {
                scoop = scoop,
                position = Vector3.up * scoopSize * (scoops.Count + 1)
            });

            scoop.isFalling = false;
            catchPosition.Translate(Vector3.up * scoopSize);
            boxCollider.offset += Vector2.up * scoopSize;

            GameController.instance.AddedScoop();
        }
    }
}
