using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("prefabId", "localRefs", "enabled", "name")]
	public class ES3UserType_ES3Prefab : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ES3Prefab() : base(typeof(ES3Internal.ES3Prefab)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ES3Internal.ES3Prefab)obj;
			
			writer.WriteProperty("prefabId", instance.prefabId, ES3Type_long.Instance);
			writer.WriteProperty("localRefs", instance.localRefs);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ES3Internal.ES3Prefab)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "prefabId":
						instance.prefabId = reader.Read<System.Int64>(ES3Type_long.Instance);
						break;
					case "localRefs":
						instance.localRefs = reader.Read<ES3Internal.ES3RefIdDictionary>();
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


	public class ES3UserType_ES3PrefabArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ES3PrefabArray() : base(typeof(ES3Internal.ES3Prefab[]), ES3UserType_ES3Prefab.Instance)
		{
			Instance = this;
		}
	}
}