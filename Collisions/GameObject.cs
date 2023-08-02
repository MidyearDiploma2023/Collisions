using System;
using Raylib_cs;
using System.Numerics;

namespace Collisions
{
    internal class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }

        Rigidbody rb;
      


        public GameObject(Vector2 position, Vector2 scale, Rigidbody rb)
        {
            Position = position;
            Scale = scale;

            this.rb = rb;
            rb.parent = this;
        }

        public void Draw()
        {

            if (rb.collider.Type == Constants.ColliderType.CIRCLE)
            {
                Raylib.DrawCircle((int)Position.X, (int)Position.Y, Scale.X, Color.GOLD);
            }

            if(rb.collider.Type == Constants.ColliderType.BOX)
            {
                Rectangle rect = new Rectangle(Position.X, Position.Y, Scale.X, Scale.Y);
                Raylib.DrawRectanglePro(rect, Vector2.Zero + new Vector2(Scale.X / 2, Scale.Y / 2), 0, Color.LIME);
            }
        }

        public void Update()
        {
           
        }

        public void FixedUpdate()
        {
            if(rb != null)
            {
                rb.FixedUpdate();
            }
        }



    }
}
