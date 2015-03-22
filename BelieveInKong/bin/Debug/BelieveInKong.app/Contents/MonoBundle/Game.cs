using System;
using LudumEngine;

namespace BelieveInKong
{
	public class Game
	{
		/// <summary>
		/// The entry point of the game, where it is decleraded and started.
		/// </summary>
		public void Main()
		{
			/////////////////////////                 
			// Initialization      //
			/////////////////////////

			Ludum.Initialize();

			// Settings
			Ludum.Settings.Fullscreen = false;
			Ludum.Settings.AssetsDirectory = "GameContents";


			/////////////////////////                 
			// Blueprints          //
			/////////////////////////

			// T-Rex
			EntityBlueprint tyrannosaurus = Ludum.Blueprints.CreateEntityBlueprint ("TRex");
			tyrannosaurus.AddComponent<Sprite> ().Set(filename: "trexSprite");
			tyrannosaurus.AddComponent<Body> ().SetPosition(x: 0, y: 50);
			tyrannosaurus.AddComponent<Moveable> ();

			// Ape
			EntityBlueprint greatApe = Ludum.Blueprints.CreateEntityBlueprint ("GreatApe");
			greatApe.AddComponent<Sprite> ().Set(filename: "apeSprite");
			greatApe.AddComponent<Body> ().SetPosition(x: 200, y: 50);

			// Scene Controller
//			EntityBlueprint controller = Ludum.Blueprints.CreateEntityBlueprint ("Controller"); 
//			controller.AddComponent<ChangeScene>().SetScene("arena");
//			controller.AddComponent<Sprite>().Set("logo");
//			controller.AddComponent<Body>().SetPosition(x: 200, y: 50);
			

			/////////////////////////                 
			// Scenes              //
			/////////////////////////

			// Arena
			Scene arena = Ludum.Scenes.CreateScene("arena");
			arena.CreateEntity(greatApe);
			arena.CreateEntity(tyrannosaurus);

			// Startscene
//			Scene startscene = Ludum.Scenes.CreateScene("start");
//			startscene.BackgroundColor = Color.Black;
//			startscene.CreateEntity(controller);


			/////////////////////////                 
			// Start the game      //
			/////////////////////////

			// Start the game
			Ludum.Start(scene: arena);
		}
	}
}