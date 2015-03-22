using System;

// Project task list:

namespace LudumEngine
{
	public static class Ludum
	{
		// Global managers
		public static RenderManager RenderManager { get; private set; }
		public static AudioManager AudioManager { get; private set; }
		public static ErrorHandler Error  { get; private set; }
		public static GameManager Game { get; private set; }
		public static ResourceManager ResourceManager { get; private set; }
		public static BlueprintManager Blueprints  { get; private set; }
		public static SceneManager  Scenes { get; private set; }
		public static PhysicsManager Physics { get; private set; }
		public static SettingsManager Settings  { get; private set; }
		public static InputHandler  GlobalInputs { get; private set; }

		public static void Initialize()
		{
			// Create the SettingsManager first
			Settings = new SettingsManager();

			// Create the ErrorHandler and GameManager
			Error = new ErrorHandler ();
			Game = new GameManager ();

			// Create all other systems
			ResourceManager = new ResourceManager ();
			RenderManager = new RenderManager (Game);
			AudioManager = new AudioManager();
			Blueprints = new BlueprintManager ();
			Scenes = new SceneManager();
			Physics = new PhysicsManager();
			GlobalInputs = new InputHandler();
		}

		static void Main (string[] args)
		{
			// This line exists so that the project will compile correctly.
			Console.WriteLine("The Ludum engine is currently not designed to be runnable.");
		}
			
		public static void Start(Scene scene)
		{
            Scenes.GoTo(scene);
			Game.Start();
		}
	}
}