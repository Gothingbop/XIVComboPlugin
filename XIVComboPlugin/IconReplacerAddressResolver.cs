
using Dalamud.Game;
using System;

namespace XIVCombo
{
	class IconReplacerAddressResolver
	{
		public nint GetIcon { get; private set; }
		public nint IsIconReplaceable { get; private set; }

		public IconReplacerAddressResolver(ISigScanner sig)
		{
			IsIconReplaceable = sig.ScanText("40 53 48 83 EC 20 8B D9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 1F");
		}
	}
}
