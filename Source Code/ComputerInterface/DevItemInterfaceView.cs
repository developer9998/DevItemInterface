using System;
using System.Collections.Generic;
using System.Text;
using ComputerInterface;
using ComputerInterface.ViewLib;
using GorillaLocomotion;
//using PracticeMod.Patches;

namespace DevItemInterface
{
	public class DevItemInterfaceView : ComputerView
	{
		const string highlightColor = "7F0000ff";

		private readonly UISelectionHandler _selectionHandler;
		public DevItemInterfaceView()
		{
			_selectionHandler = new UISelectionHandler(EKeyboardKey.Up, EKeyboardKey.Down, EKeyboardKey.Enter);
			// the max zero indexed entry (2 entries - 1 since zero indexed)
			_selectionHandler.MaxIdx = 3;
			// when the "selection" key is pressed (we set it to enter above)
			//_selectionHandler.OnSelected += OnEntrySelected;
			// since you quite often want to have an indicator of the selected item
			// I added helper function for that.
			// Basically you specify the prefix and suffix added to the selected item
			// and an prefix and suffix if the item isn't selected
			_selectionHandler.ConfigureSelectionIndicator($"<color=#{highlightColor}>></color> ", "", "  ", "");
		}

		public override void OnShow(object[] args)
		{
			base.OnShow(args);
			// changing the Text property will fire an PropertyChanged event
			// which lets the computer know the text has changed and update it
			UpdateScreen();
		}

		void UpdateScreen()
		{
			// when your text function isn't that complex
			// you can use this method which creates a string builder
			// passes it via the specified callback function and sets the text at the end
			SetText(str =>
			{
				str.BeginCenter();
				str.MakeBar('-', SCREEN_WIDTH, 0, "ffffff50");
				str.AppendClr("ItemInterface", highlightColor).EndColor().AppendLine();
				str.AppendLine("By dev9998");
				str.MakeBar('-', SCREEN_WIDTH, 0, "ffffff50");
				str.EndAlign().AppendLines(1);

				if (!Plugin.infoPage)
                {
					DrawBody(str);
				}
				else
                {
					DrawHelpPage(str);
                }
			});
		}
		void DrawBody(StringBuilder str)
		{
			str.BeginCenter();
			str.AppendLine();
			str.BeginColor(highlightColor);
			str.AppendLine("Press Option 3 for help");
			str.EndColor();
			str.AppendLine();
			str.AppendLine($"Cosmetic Particles: {(!Plugin.disableParticles)}");
			str.AppendLine();
			str.AppendLine($"Instrument Volume: {(Plugin.instrumentVolume):F2}");
			str.EndAlign();
		}

		void DrawHelpPage(StringBuilder str)
        {
			str.BeginCenter();
			str.AppendLine();
			str.BeginColor(highlightColor);
			str.AppendLine("Press Option 3 to go back");
			str.EndColor();
			str.AppendLine();
			str.AppendLine("Press Option 1/2 to set if cosmetic particles should be enabled/disabled.");
			str.AppendLine();
			str.AppendLine("Press 0-9 to set the volume of the instruments.");
			str.EndAlign();
		}

		public override void OnKeyPressed(EKeyboardKey key)
		{
			if (!Plugin.infoPage)
			{
				if (key == EKeyboardKey.Option3)
				{
					Plugin.infoPage = true;
					UpdateScreen();
				}
				if (key == EKeyboardKey.Back)
				{
					ReturnView();
				}
				if (key == EKeyboardKey.NUM0)
				{
					Plugin.SetVolume(0);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM1)
				{
					Plugin.SetVolume(1);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM2)
				{
					Plugin.SetVolume(2);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM3)
				{
					Plugin.SetVolume(3);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM4)
				{
					Plugin.SetVolume(4);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM5)
				{
					Plugin.SetVolume(5);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM6)
				{
					Plugin.SetVolume(6);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM7)
				{
					Plugin.SetVolume(7);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM8)
				{
					Plugin.SetVolume(8);
					UpdateScreen();
				}
				if (key == EKeyboardKey.NUM9)
				{
					Plugin.SetVolume(9);
					UpdateScreen();
				}
				if (key == EKeyboardKey.Option1)
                {
					Plugin.SetParticles(false, "FALSE");
					UpdateScreen();
				}
				if (key == EKeyboardKey.Option2)
				{
					Plugin.SetParticles(true, "TRUE");
					UpdateScreen();
				}
			}
			else
            {
				if (key == EKeyboardKey.Option3)
				{
					Plugin.infoPage = false;
					UpdateScreen();
				}
			}

		}
	}
}
