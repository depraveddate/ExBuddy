﻿
#pragma warning disable 1998

namespace ExBuddy.OrderBotTags.Gather.GatherSpots
{
	using System.ComponentModel;
	using System.Threading.Tasks;

	using Clio.Utilities;
	using Clio.XmlEngine;

	using ExBuddy.Helpers;
	using ExBuddy.Interfaces;

	[XmlElement("GatherSpot")]
	public class GatherSpot : IGatherSpot
	{
		[DefaultValue(true)]
		[XmlAttribute("UseMesh")]
		public bool UseMesh { get; set; }

		#region IGatherSpot Members

		[XmlAttribute("NodeLocation")]
		public Vector3 NodeLocation { get; set; }

		public virtual async Task<bool> MoveFromSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving from " + this;

			return true;
		}

		public virtual async Task<bool> MoveToSpot(ExGatherTag tag)
		{
			tag.StatusText = "Moving to " + this;

			var result =
				await
				Behaviors.MoveTo(
					NodeLocation,
					UseMesh,
					radius: tag.Distance,
					name: tag.Node.EnglishName,
					stopCallback: tag.MovementStopCallback);

			return result;
		}

		#endregion

		public override string ToString()
		{
			return this.DynamicToString();
		}
	}
}