using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Instance", "saveChildren", "type", "isPrimitive", "isValueType", "isCollection", "isDictionary", "isES3TypeUnityObject", "isReflectedType", "isUnsupported", "priority")]
	public class ES3UserType_ES3Type_GameObject : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ES3Type_GameObject() : base(typeof(ES3Types.ES3Type_GameObject)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (ES3Types.ES3Type_GameObject)obj;
			
			writer.WriteProperty("Instance", ES3Types.ES3Type_GameObject.Instance);
			writer.WriteProperty("saveChildren", instance.saveChildren, ES3Type_bool.Instance);
			writer.WriteProperty("type", instance.type);
			writer.WriteProperty("isPrimitive", instance.isPrimitive, ES3Type_bool.Instance);
			writer.WriteProperty("isValueType", instance.isValueType, ES3Type_bool.Instance);
			writer.WriteProperty("isCollection", instance.isCollection, ES3Type_bool.Instance);
			writer.WriteProperty("isDictionary", instance.isDictionary, ES3Type_bool.Instance);
			writer.WriteProperty("isES3TypeUnityObject", instance.isES3TypeUnityObject, ES3Type_bool.Instance);
			writer.WriteProperty("isReflectedType", instance.isReflectedType, ES3Type_bool.Instance);
			writer.WriteProperty("isUnsupported", instance.isUnsupported, ES3Type_bool.Instance);
			writer.WriteProperty("priority", instance.priority, ES3Type_int.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (ES3Types.ES3Type_GameObject)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Instance":
						ES3Types.ES3Type_GameObject.Instance = reader.Read<ES3Types.ES3Type>();
						break;
					case "saveChildren":
						instance.saveChildren = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "type":
						instance.type = reader.Read<System.Type>();
						break;
					case "isPrimitive":
						instance.isPrimitive = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isValueType":
						instance.isValueType = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isCollection":
						instance.isCollection = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isDictionary":
						instance.isDictionary = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isES3TypeUnityObject":
						instance.isES3TypeUnityObject = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isReflectedType":
						instance.isReflectedType = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isUnsupported":
						instance.isUnsupported = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "priority":
						instance.priority = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new ES3Types.ES3Type_GameObject();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_ES3Type_GameObjectArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ES3Type_GameObjectArray() : base(typeof(ES3Types.ES3Type_GameObject[]), ES3UserType_ES3Type_GameObject.Instance)
		{
			Instance = this;
		}
	}
}