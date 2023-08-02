using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants;

namespace Collisions
{

    internal class Collider
    {
        public ColliderType Type { get; protected set; }
        public int ID { get; private set;}

        protected List<Collider> overlaps = new List<Collider>();
        public Rigidbody connectedRigidbody;


        public Collider(ColliderType type, int ID, Rigidbody rb)
        {
            Type = type;
            this.ID = ID;
            connectedRigidbody = rb;
        }


        public virtual bool CheckForCollisions(Collider other)
        {
            return false;
        }

        public virtual bool CheckStillColliding(Collider other)
        {
            return false;
        }

        public void Update()
        {
            
        }
        
        public void OnCollisionEnter(string thing)
        {
            Console.WriteLine(thing);
        }

        public void OnCollisionExit()
        {

        }


    }
}
