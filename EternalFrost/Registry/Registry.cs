using System.Collections.Generic;
using EternalFrost.Utils.Collections;
namespace EternalFrost.Registry
{
	/// <summary>
	/// Class <c>Registry</c>: A Dictionary Like object that stores Objects of a type <c>T</c> and a <c>ResourceLocation</c> Key.
	/// </summary>
	public class Registry<T>
	{
		private Dictionary<RegistryItem, T> ItemToValue = new Dictionary<RegistryItem, T>() { };
		public ResourceLocation ID { get; }
		private Dictionary<T, RegistryItem> ValueToItem = new Dictionary<T, RegistryItem>(new IdentityEqualityComparer<T>());

		
		public T Register(ResourceLocation name, T item)
		{
			ItemToValue.Add(new RegistryItem(ID,name),item);
			ValueToItem.Add(item, new RegistryItem(ID, name));
			Console.WriteLine(new RegistryItem(ID, name).ToString());
			return item;
		}
		public T GetValue(ResourceLocation location)
		{
			return ItemToValue[new RegistryItem(ID,location)];
		}
			
		public RegistryItem GetKey(T item)
		{
			return ValueToItem[item];
		}

		public bool Contains(ResourceLocation location)
		{
			return ItemToValue.ContainsKey(new RegistryItem(ID,location));
		}
		public bool Contains(T value)
		{
			return ItemToValue.ContainsValue(value);
		}
		public Registry(ResourceLocation ID) {
			this.ID = ID;	 
		}
		public Dictionary<RegistryItem,T>.ValueCollection Values()
		{
			return ItemToValue.Values;
		}
		public Dictionary<RegistryItem, T>.KeyCollection Keys()
		{
			return ItemToValue.Keys;
		}
		public int GetLength()
		{
			return ItemToValue.Count;
		}
	}
}

