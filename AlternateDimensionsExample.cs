using Terraria.ModLoader;
using Terraria;
using System;
using AlternateDimensions;
using System.IO;

namespace AlternateDimensionsExample
{
	public class AlternateDimensionsExample : Mod
	{
		public AlternateDimensionsExample()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadSounds = true
			};
		}

		public override void PostSetupContent()
		{
			Mod altDimensions = ModLoader.GetMod("AlternateDimensions");
			ExampleDimensionA exampleDimensionA = (ExampleDimensionA)GetModWorld("ExampleDimensionA");
			ExampleDimensionB exampleDimensionB = (ExampleDimensionB)GetModWorld("ExampleDimensionB");
			if (altDimensions != null)
			{
				AlternateDimensionInterface.RegisterDimension(Name, "A Dimension", exampleDimensionA.GenerateDimension);
				AlternateDimensionInterface.RegisterDimension(Name, "B Dimension", exampleDimensionB.GenerateDimension);
			}
			else
			{
				throw new Exception("For some reason, Alternate Dimensions mod was not found.");
			}
		}

		public override void ChatInput(string text)
		{
			if (text[0] != '/')
			{
				return;
			}
			text = text.Substring(1);
			int index = text.IndexOf(' ');
			string command;
			string[] args;
			if (index < 0)
			{
				command = text;
				args = new string[0];
			}
			else
			{
				command = text.Substring(0, index);
				args = text.Substring(index + 1).Split(' ');
			}
			if (command == "npc")
			{
				SaveTiles(args);
			}

		}

		public void SaveTiles(string[] args)
		{
			using (MemoryStream stream = new MemoryStream())
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				float tileX = 0;
				float tileY = 0;
				int size = 0;

				int num4 = (int)tileX;
				int num5 = (int)tileY;
				if (num4 < size)
				{
					num4 = size;
				}
				if (num4 >= Main.maxTilesX + size)
				{
					num4 = Main.maxTilesX - size - 1;
				}
				if (num5 < size)
				{
					num5 = size;
				}
				if (num5 >= Main.maxTilesY + size)
				{
					num5 = Main.maxTilesY - size - 1;
				}
				writer.Write((short)size);
				writer.Write((short)num4);
				writer.Write((short)num5);
				for (int num6 = num4; num6 < num4 + size; num6++)
				{
					for (int num7 = num5; num7 < num5 + size; num7++)
					{
						BitsByte bb11 = 0;
						BitsByte bb12 = 0;
						byte b = 0;
						byte b2 = 0;
						Tile tile = Main.tile[num6, num7];
						bb11[0] = tile.active();
						bb11[2] = (tile.wall > 0);
						bb11[3] = (tile.liquid > 0 && Main.netMode == 2);
						bb11[4] = tile.wire();
						bb11[5] = tile.halfBrick();
						bb11[6] = tile.actuator();
						bb11[7] = tile.inActive();
						bb12[0] = tile.wire2();
						bb12[1] = tile.wire3();
						if (tile.active() && tile.color() > 0)
						{
							bb12[2] = true;
							b = tile.color();
						}
						if (tile.wall > 0 && tile.wallColor() > 0)
						{
							bb12[3] = true;
							b2 = tile.wallColor();
						}
						bb12 += (byte)(tile.slope() << 4);
						bb12[7] = tile.wire4();
						writer.Write(bb11);
						writer.Write(bb12);
						if (b > 0)
						{
							writer.Write(b);
						}
						if (b2 > 0)
						{
							writer.Write(b2);
						}
						if (tile.active())
						{
							writer.Write(tile.type);
							if (Main.tileFrameImportant[(int)tile.type])
							{
								writer.Write(tile.frameX);
								writer.Write(tile.frameY);
							}
						}
						if (tile.wall > 0)
						{
							if (ModNet.AllowVanillaClients)
								writer.Write((byte)tile.wall);
							else
								writer.Write(tile.wall);
						}
						if (tile.liquid > 0 && Main.netMode == 2)
						{
							writer.Write(tile.liquid);
							writer.Write(tile.liquidType());
						}
					}
				}
			}
		}

		public static void DebugText(string message)
		{
			if (Main.dedServ)
			{
				Console.WriteLine(message);
			}
			else
			{
				if (Main.gameMenu)
				{
					ErrorLogger.Log(Main.myPlayer + ": " + message);
				}
				else
				{
					Main.NewText(message);
				}
			}
		}
	}
}
