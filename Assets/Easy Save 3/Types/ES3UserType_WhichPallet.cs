using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_WhichPallet : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WhichPallet() : base(typeof(WhichPallet)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WhichPallet)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WhichPallet)obj;
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


	public class ES3UserType_WhichPalletArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WhichPalletArray() : base(typeof(WhichPallet[]), ES3UserType_WhichPallet.Instance)
		{
			Instance = this;
		}
	}
}