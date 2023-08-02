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

            return false;
        }

    }
}
