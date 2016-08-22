using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace AlternateDimensionsExample
{
	class ExampleDimensionA : ExampleDimensionBase
	{
		public override bool Autoload(ref string name) => true;

		public override void GenerateDimension(Rectangle area)
		{
			DoXInRange(area, 0, activate); // dirt everywhere

			Action<int, int, int> deactivateModY = (x, y, optional) => { if (y % optional == 0) Main.tile[x, y].active(false); };
			DoXInRange(area, 3, deactivateModY); // dirt everywhere
		}
	}
}

/*
 	public void GenerateBasicArena(Rectangle area)
		{
			int dimensionTilesX = 500;
			int dimensionTilesY = 400;

			Action<int, int> newTile = (x, y) => Main.tile[x + area.X, y + area.Y] = new Tile();
			Action<int, int> defaultFrame = (x, y) => { Main.tile[x + area.X, y + area.Y].frameX = -1; Main.tile[x + area.X, y + area.Y].frameY = -1; };
			Action<int, int> activate = (x, y) => { Main.tile[x + area.X, y + area.Y].active(true); };
			Action<int, int> deactivate = (x, y) => { Main.tile[x + area.X, y + area.Y].active(false); };


			// Reset
			DoXInRange(0, 0, area.Width, area.Height, newTile, defaultFrame, activate);

			// Dungeon walls all.
			DoXInRange(0, 0, dimensionTilesX, dimensionTilesY, (x, y) => { Main.tile[x + area.X, y + area.Y].wall = WallID.BlueDungeonSlab; Main.tile[x + area.X, y + area.Y].type = TileID.GreenDungeonBrick; });

			//300 x 200
			// ____________________
			// |     
			// |
			// |     __      __    |
			// |_____| |____| |____|
			DoXInRange(50, 50, 105, 150, deactivate);
			DoXInRange(110, 50, 190, 150, deactivate);
			DoXInRange(195, 50, 250, 150, deactivate);
			DoXInRange(50, 60, 250, 60, deactivate); // +15 and 20
			DoXInRange(50, 75, 250, 95, deactivate);
			DoXInRange(50, 110, 250, 130, deactivate);
			DoXInRange(50, 145, 250, 145, deactivate);

			Action<int, int> platform = (x, y) =>
			{
				if (!Main.tile[x + area.X, y + area.Y].active())
				{
					activate(x, y);
					Main.tile[x + area.X, y + area.Y].type = TileID.Platforms;
					Main.tile[x + area.X, y + area.Y].frameY = 144;
				}
			};
			foreach (int y in new int[] { 80, 100, 120, 200, 220, 240 })
			{
				DoXInRangeInclusive(25, y, 275, y, platform);
			}

			foreach (int x in new int[] { 0, 25, 50, 75, 100, 125, 150, 175, 200, 225, 250, 275 })
			{
				foreach (int y in new int[] { 0, 25, 50, 75, 100, 125, 150, 175, 200, 225, 250, 275 })
				{
					activate(x, y);
					defaultFrame(x, y);
					Main.tile[x + area.X, y + area.Y].type = TileID.Torches;
				}
			}
		}


*/
