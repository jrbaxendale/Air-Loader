using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("alpha", "interactable", "blocksRaycasts", "ignoreParentGroups", "enabled", "name")]
	public class ES3UserType_CanvasGroup : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CanvasGroup() : base(typeof(UnityEngine.CanvasGroup)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.CanvasGroup)obj;
			
			writer.WriteProperty("alpha", instance.alpha, ES3Type_float.Instance);
			writer.WriteProperty("interactable", instance.interactable, ES3Type_bool.Instance);
			writer.WriteProperty("blocksRaycasts", instance.blocksRaycasts, ES3Type_bool.Instance);
			writer.WriteProperty("ignoreParentGroups", instance.ignoreParentGroups, ES3Type_bool.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.CanvasGroup)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "alpha":
						instance.alpha = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "interactable":
						instance.interactable = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "blocksRaycasts":
						instance.blocksRaycasts = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "ignoreParentGroups":
						instance.ignoreParentGroups = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CanvasGroupArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CanvasGroupArray() : base(typeof(UnityEngine.CanvasGroup[]), ES3UserType_CanvasGroup.Instance)
		{
			Instance = this;
		}
	}
}