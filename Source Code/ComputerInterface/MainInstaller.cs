using System;
using System.Collections.Generic;
using System.Text;
using ComputerInterface;
using ComputerInterface.Interfaces;
using Zenject;

namespace DevItemInterface
{
	internal class MainInstaller : Installer
	{
		public override void InstallBindings()
		{
			Container.Bind<IComputerModEntry>().To<DevItemInterfaceEntry>().AsSingle();
		}
	}
}
