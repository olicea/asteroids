using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using asteriods.Spatials;
using Artemis;
using asteriods.Systems;
using asteriods.Components;

namespace asteroids
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private EntityWorld world;

		public Game1()
		{
			this.graphics = new GraphicsDeviceManager(this);
			this.IsMouseVisible = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			this.spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: Add your initialization logic here
			this.world = new EntityWorld();

			this.world.SystemManager.SetSystem(new PlayerShipControlSystem(), ExecutionType.Update);
			this.world.SystemManager.SetSystem(new MovementSystem(this.GraphicsDevice), ExecutionType.Update);
			this.world.SystemManager.SetSystem(new RenderSystem(GraphicsDevice, this.spriteBatch), ExecutionType.Draw);

			this.world.SystemManager.InitializeAll();

			// initialize player
			Entity entity = this.world.CreateEntity();
			entity.AddComponent(new Transform(
				new Vector3(this.GraphicsDevice.Viewport.Width / 2, this.GraphicsDevice.Viewport.Height / 2, 0f)
			));
			entity.AddComponent(new Velocity());
			entity.AddComponent(new SpatialForm(SpatialForms.Player));
			entity.Refresh();

			entity.Tag = "PLAYER";

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// TODO: use this.Content to load your game content here
			PlayerForm.LoadContent(this.GraphicsDevice);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		private DateTime lastTime = DateTime.Now;

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// TODO: Add your update logic here
			TimeSpan elapsed = DateTime.Now - this.lastTime;
			this.lastTime = DateTime.Now;

			this.world.LoopStart();
			this.world.Delta = elapsed.Milliseconds;

			this.world.SystemManager.UpdateSynchronous(ExecutionType.Update);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			this.GraphicsDevice.Clear(Color.Black);

			// TODO: Add your drawing code here
			this.spriteBatch.Begin();

			this.world.SystemManager.UpdateSynchronous(ExecutionType.Draw);

			this.spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}