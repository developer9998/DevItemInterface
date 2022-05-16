using System;
using System.Collections.Generic;
using System.Text;
using ComputerInterface;
using ComputerInterface.Interfaces;

namespace DevItemInterface
{
	public class DevItemInterfaceEntry : IComputerModEntry
	{
		public string EntryName => "ItemInterface";

		public Type EntryViewType => typeof(DevItemInterfaceView);
	}
}
