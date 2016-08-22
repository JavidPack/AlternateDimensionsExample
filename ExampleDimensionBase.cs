using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace AlternateDimensionsExample
{
	class ExampleDimensionBase : ModWorld
	{
		public override bool Autoload(ref string name) => false;

		public virtual void GenerateDimension(Rectangle area) { }

		//Action<int, int> newTile = (x, y) => Main.tile[x, y] = new Tile();
		internal Action<int, int, int> defaultFrame = (x, y, optional) => 
		{
			Main.tile[x, y].frameX = -1;
			Main.tile[x, y].frameY = -1;
		};
		internal Action<int, int, int> activate = (x, y, optional) => { Main.tile[x, y].active(true); };
		internal Action<int, int, int> deactivate = (x, y, optional) => { Main.tile[x, y].active(false); };

		internal void DoXInRangeInclusive(int x1, int y1, int x2, int y2, int optional,  params Action<int, int, int>[] actions)
		{
			DoXInRange(x1, y1, x2 + 1, y2 + 1, optional, actions);
		}

		internal void DoXInRangeRelative(Rectangle area, int optional, params Action<int, int, int>[] actions)
		{
			DoXInRange(area.Left, area.Top, area.Right, area.Bottom, optional, actions);
		}

		internal void DoXInRange(Rectangle area, int optional, params Action<int, int, int>[] actions)
		{
			DoXInRange(area.Left, area.Top, area.Right, area.Bottom, optional, actions);
		}

		internal void DoXInRange(int x1, int y1, int x2, int y2, int optional, params Action<int, int, int>[] actions)
		{
			try
			{
				for (int i = x1; i < x2; i++)
				{
					for (int j = y1; j < y2; j++)
					{
						foreach (var action in actions)
						{
							action(i, j, optional);
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorLogger.Log(e.Message);
			}
		}
	}
}
