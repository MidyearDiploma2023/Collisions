
using Raylib_cs;
using System.Numerics;

namespace Collisions
{
    internal class GameManager
    {
        public static GameManager instance;
        public PhysicsManager physicsManager;

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public int TargetFPS { get; private set; }

        public float FixedDeltaTime { get; private set; }
        public float DeltaTime { get; private set; }

        public float CurrentFixedCount { get; private set; } = 0.0f;

        List<GameObject> gameObjects = new List<GameObject>();


        public GameManager():this(450, 450, 165)
        {

        }

        public GameManager(int width, int height, int fps)
        {
            if (instance == null)
            {
                instance = this;
            }

            WindowWidth = width;
            WindowHeight = height;
            TargetFPS = fps;
            FixedDeltaTime = 1f / fps;

            physicsManager = new PhysicsManager();

            Raylib.SetTargetFPS(fps);
            Raylib.InitWindow(WindowWidth, WindowHeight, "Collisions");

            Rigidbody rb = new Rigidbody(1, 0.2f, 1);
            CircleCollider circle = new CircleCollider(1, rb, 10);
            rb.collider = circle;

            Rigidbody rb2 = new Rigidbody(1, 0.2f, 0);
            BoxCollider box = new BoxCollider(2, rb2, new Vector2(200, 10));
            rb2.collider = box;




            gameObjects.Add(new GameObject(new Vector2(WindowWidth / 2, 10), new Vector2(10, 0), rb));
            gameObjects.Add(new GameObject(new Vector2(WindowWidth / 2, 70), new Vector2(200, 10), rb2));


        }

        private void Draw()
        {
            Raylib.ClearBackground(Color.BLACK);
            Raylib.BeginDrawing();
            foreach(var go in gameObjects)
            {
                go.Draw();
            }
            //This is where we will draw stuff

            Raylib.EndDrawing();
        }

        private void Update()
        {
            CurrentFixedCount += DeltaTime;
            if(CurrentFixedCount > FixedDeltaTime)
            {
                //this is where we will check collisions and such
                CurrentFixedCount -= FixedDeltaTime;
                physicsManager.FixedUpdate();
            }

            //This is where we will update everything else

        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                Update();

                Draw();

                DeltaTime = Raylib.GetFrameTime();
            }

            End();

        }

        private void End()
        {
            Raylib.CloseWindow();
        }


    }
}
