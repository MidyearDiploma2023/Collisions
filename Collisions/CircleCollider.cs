using Constants;
using System.Numerics;

namespace Collisions
{
    internal class CircleCollider : Collider
    {
        public float Radius { get; protected set; }

        public CircleCollider(int ID, Rigidbody rb, float radius) : base(Constants.ColliderType.CIRCLE, ID, rb)
        {
            Radius = radius;
        }


        public override bool CheckForCollisions(Collider other)
        {
            for (int i = 0; i < overlaps.Count; i++)
            {
                if (overlaps[i].ID == other.ID)
                {
                    return true;
                }
            }

            if(other.Type == Constants.ColliderType.CIRCLE)
            {
                var circle = other as CircleCollider;

                if(Vector2.DistanceSquared(circle.connectedRigidbody.parent.Position, connectedRigidbody.parent.Position) <= (Radius * Radius) + (circle.Radius * circle.Radius))
                {
                    if (!overlaps.Contains(circle))
                    {
                        overlaps.Add(circle);
                    }

                    OnCollisionEnter("Circle to Circle called from circle collider");
                    return true;
                }
                //Radius added together
                //Check the distance between them
            }

            if(other.Type == Constants.ColliderType.BOX)
            {
                var box = other as BoxCollider;

                Vector2 circleCentre = connectedRigidbody.parent.Position;

                Vector2 boxHalfExtents = new Vector2(box.Scale.X / 2, box.Scale.Y / 2);
                Vector2 boxCentre = new Vector2(box.connectedRigidbody.parent.Position.X + boxHalfExtents.X, box.connectedRigidbody.parent.Position.Y + boxHalfExtents.Y);

                //Collision Check
                Vector2 difference = circleCentre - boxCentre;
                Vector2 clamped = Vector2.Clamp(difference, -boxHalfExtents, boxHalfExtents);
                Vector2 closest = boxCentre + clamped;

                difference = closest - circleCentre;

                if(difference.LengthSquared() < Radius * Radius)
                {
                    OnCollisionEnter("Circle to box called from circle collider");
                    return true;
                }
            }

            return false;
        }

    }
}
