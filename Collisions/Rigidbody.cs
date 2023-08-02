using System.Numerics;

namespace Collisions
{
    internal class Rigidbody
    {
        public float Mass { get; private set; }
        public Vector2 Velocity { get; private set; }
        public Vector2 Acceleration { get; private set; }
        public float Drag { get; private set; }

        public float GravityScale { get; private set; }

        public GameObject? parent;
        public Collider collider;


        public Rigidbody(float mass, float drag, float gravityScale)
        {
            Mass = mass;
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Drag = drag;
            GravityScale = gravityScale;
            parent = null;
            collider = null;
            GameManager.instance.physicsManager.RegisterRigidbody(this);
        }

        public Rigidbody(float mass, float drag, float gravityScale, Collider collider)
        {
            Mass = mass;
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            Drag = drag;
            GravityScale = gravityScale;
            parent = null;
            this.collider = collider;

            GameManager.instance.physicsManager.RegisterRigidbody(this);
        }


        public void FixedUpdate()
        {
            if (parent == null) return;

            Acceleration = GameManager.instance.physicsManager.gravity * GravityScale;

            if(Velocity.Length() != 0)
            {
                Velocity -= Vector2.Normalize(Velocity) * Drag;
            }


            Velocity += Acceleration;

            
            parent.Position += Velocity * GameManager.instance.FixedDeltaTime;


           
            //Move an object around
        }

        public void CheckForCollisions(Rigidbody other)
        {
            if(other == this || collider == null || other.collider == null)
            {
                return;
            }

            collider.CheckForCollisions(other.collider);
        }
    }
}
