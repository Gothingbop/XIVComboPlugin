using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XIVCombo.Interface
{
	public class Changelog
	{
		public static Dictionary<string, string[]> GetChangelog()
		{
			return new Dictionary<string, string[]>()
				{
					{
						"v2.0.2.0",
						[
							"API 13 update.",
						]
					},
					{
						"v2.0.1.1",
						[
							"Fixed DRK's Stalwart Soul combo not working if you were level 40 (thanks esotericist and .necrosis666 for the feedback).",
						]
					},				
					{
						"v2.0.1.0",
						[
							"API 12 update.",
							"Fixed MNK's Coeurl feature not working if you were level 30 (thanks CGRocky for the feedback).",
						]
					},						
					{
						"v2.0.0.6",
						[
							"Fixed MCH's Hypercharge and Spreadshot combos being swapped.",
						]
					},			
					{
						"v2.0.0.5",
						[
							"Fixed DRK's Stalwart Soul not reverting to Unleash when below level 40.",
						]
					},				
					{
						"v2.0.0.4",
						[
							"Fixed RDM's Verstone/Verfire Feature procs overwriting Scorch and Resolution.",
							"Fixed RDM's AoE Combo icons displaying Energy Drain instead of Swiftcast",
							"Fixed an issue with RPR's Communio not turning properly into Perfectio when using the Enshroud Communio Feature."
						]
					},				
					{
						"v2.0.0.3",
						[
							"Fixed PCT's Substractive applying to both Fire in Red and Blizzard in Cyan, only applying to Fire in Red now as it used to."
						]
					},							
					{
						"v2.0.0.2",
						[
							"Fixed MCH's Hypercharge Blaster not replacing the correct action like it used to."
						]
					},					
					{
						"v2.0.0.1",
						[
							"Added back BLM's Flare/Freeze in the Enochian combo line."
						]
					},
					{
						"v2.0.0.0",
						[
							"Initial re-release!",
							"Every job is Dawntrail updated.",
							"XIVCombo is a tool designed for accessibility.",
							"Some new features may be added in the future.",
							"You may run into potential bugs or issue ; if you do, please use the Dalamud Feedback feature.",
						]
					},
				};
		}
	}
}
