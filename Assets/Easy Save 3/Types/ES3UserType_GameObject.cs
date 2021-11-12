using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("layer", "isStatic", "tag", "name")]
	public class ES3UserType_GameObject : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_GameObject() : base(typeof(UnityEngine.GameObject)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.GameObject)obj;
			
			writer.WriteProperty("layer", instance.layer, ES3Type_int.Instance);
			writer.WriteProperty("isStatic", instance.isStatic, ES3Type_bool.Instance);
			writer.WriteProperty("tag", instance.tag, ES3Type_string.Instance);
			writer.WriteProperty("name", instance.name, ES3Type_string.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.GameObject)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "layer":
						instance.layer = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "isStatic":
						instance.isStatic = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "tag":
						instance.tag = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "name":
						instance.name = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new UnityEngine.GameObject();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_GameObjectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameObjectArray() : base(typeof(UnityEngine.GameObject[]), ES3UserType_GameObject.Instance)
		{
			Instance = this;
		}
	}
}