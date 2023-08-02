using System.Numerics;

namespace Collisions
{
    internal class BoxCollider : Collider
    {
        public Vector2 Scale { get; private set; }

        public BoxCollider(int ID, Rigidbody rb, Vector2 scale) : base(Constants.ColliderType.BOX, ID, rb)
        {
            Scale = scale;
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

            if (other.Type == Constants.ColliderType.CIRCLE)
            {

                var circle = other as CircleCollider;

                Vector2 circleCentre = circle.connectedRigidbody.parent.Position;

                Vector2 boxHalfExtents = new Vector2(Scale.X / 2, Scale.Y / 2);
                Vector2 boxCentre = new Vector2(connectedRigidbody.parent.Position.X + boxHalfExtents.X, connectedRigidbody.parent.Position.Y + boxHalfExtents.Y);

                //Collision Check
                Vector2 difference = circleCentre - boxCentre;
                Vector2 clamped = Vector2.Clamp(difference, -boxHalfExtents, boxHalfExtents);
                Vector2 closest = boxCentre + clamped;

                difference = closest - circleCentre;

                if (difference.LengthSquared() < circle.Radius * circle.Radius)
                {
                    OnCollisionEnter("Circle to box called from box collider");
                    return true;
                }
            }

            else if(other.Type == Constants.ColliderType.BOX)
            {


            }

            return false;
        }

    }
}
