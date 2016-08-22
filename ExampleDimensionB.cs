using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlternateDimensionsExample
{
	class ExampleDimensionB : ExampleDimensionBase
	{
		public override bool Autoload(ref string name) => true;

		public override void GenerateDimension(Rectangle area)
		{
			int startX = area.Left;
			int endX = area.Right;
			int startY = area.Top;
			int endY = area.Bottom;
			int width = area.Width;
			int tileArea = area.Width * area.Height;

			DoXInRange(area, 0, activate); // dirt everywhere
			DoXInRange(startX, startY, endX, 70, 0, deactivate); // air top 70
		//	DoXInRange(startX, 70, endX, endY, 0, (x, y, z) => Main.tile[x, y].wall = WallID.DesertFossil); // Change walls.
			//DoXInRange(startX, 70, endX, endY, 0, (x, y, z) =>
			//{
			//	if (Main.rand.Next(40) == 0)
			//		Main.tile[x, y].type = TileID.Torches;
			//});

			//Main.tile[100, 100].type = TileID.Chlorophyte;
			//Main.tile[101, 100].type = TileID.Chlorophyte;
			//Main.tile[100, 101].type = TileID.Chlorophyte;
			//Main.tile[100, 99].type = TileID.Chlorophyte;
			//Main.tile[99, 100].type = TileID.Chlorophyte;




			//	WorldGen.JungleRunner(75, 100);
			for (int k = 0; k < (int)(tileArea * .01f); k++)
			{
//				WorldGen.TileRunner(WorldGen.genRand.Next(startX, endX), WorldGen.genRand.Next(startY, endY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileID.Copper, false, 0f, 0f, false, true);
			}
			for (int l = 0; l < (int)(tileArea * .001f); l++)
			{
//				WorldGen.TileRunner(WorldGen.genRand.Next(startX, endX), WorldGen.genRand.Next(startY, endY), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), TileID.Adamantite, false, 0f, 0f, false, true);
			}
			for (int l = 0; l < (int)(tileArea * .001f); l++)
			{
//				WorldGen.digTunnel(WorldGen.genRand.Next(startX, endX), WorldGen.genRand.Next(startY, endY), (float)(2f * WorldGen.genRand.NextDouble() - 1), (float)(2 * WorldGen.genRand.NextDouble() - 1), WorldGen.genRand.Next(30, 70), WorldGen.genRand.Next(3, 7));
			}
			//for (int m = 0; m < (int)(tileArea* 0.0002); m++)
			//{
			//	WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), copper, false, 0f, 0f, false, true);
			//}
			//for (int n = 0; n < (int)(tileArea* 3E-05); n++)
			//{
			//	WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), iron, false, 0f, 0f, false, true);
			//}
			WorldGen.OreRunner(startX + 200, startY + 180, 5, 5, TileID.Chlorophyte);
//			WorldGen.ChasmRunnerSideways(startX + 150, startY + 100, -1, 30);

			for (int l = 0; l < (int)(tileArea * .01f); l++)
			{
				WorldGen.PlaceTile(WorldGen.genRand.Next(startX, endX), WorldGen.genRand.Next(startY, endY), TileID.Tables, true, true, -1, 5);
			}

			DoXInRange(startX + 250, startY + 250, startX + 253, startY + 252, 0, deactivate);
			WorldGen.PlaceTile(startX + 251, startY + 251, TileID.Tables, true, true, -1, 1);

			DoXInRange(startX + 350, startY + 250, startX + 353, startY + 252, 0, deactivate);
			WorldGen.PlaceTile(startX + 350, startY + 250, TileID.Tables, true, true, -1, 2);

		}
	}
}
