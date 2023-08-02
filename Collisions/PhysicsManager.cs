using System.Numerics;

namespace Collisions
{
    internal class PhysicsManager
    {
        public readonly Vector2 gravity = new Vector2(0, 9.8f);
        List<Rigidbody> rigidbodies = new List<Rigidbody>();


        public void RegisterRigidbody(Rigidbody rb)
        {
            rigidbodies.Add(rb);
        }

        public void FixedUpdate()
        {
            foreach(Rigidbody rb in rigidbodies)
            {
                for(int i = 0; i < rigidbodies.Count; i++)
                {
                    rigidbodies[i].CheckForCollisions(rb);
                }
                rb.FixedUpdate();
            }
        }

    }
}
