using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_MoveACP : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_MoveACP() : base(typeof(MoveACP)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (MoveACP)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (MoveACP)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_MoveACPArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MoveACPArray() : base(typeof(MoveACP[]), ES3UserType_MoveACP.Instance)
		{
			Instance = this;
		}
	}
}