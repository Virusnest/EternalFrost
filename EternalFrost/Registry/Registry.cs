using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using EternalFrost.Utils.Collections;
using System.Collections.ObjectModel;


namespace EternalFrost.Registry
{
	public class Registry<T> 
	{
		private Dictionary<RegistryItem, T> registry = new Dictionary<RegistryItem, T>();
		public ResourceLocation ID { get; }
		private Dictionary<T, RegistryItem> ValueToItem = new Dictionary<T, RegistryItem>(new IdentityEqualityComparer<T>());
		
		public T Register(ResourceLocation name, T item)
		{
			registry.Add(new RegistryItem(ID,name),item);
			ValueToItem.Add(item, new RegistryItem(ID, name));
			Console.WriteLine(new RegistryItem(ID, name).ToString());
			return item;
		}
		public T GetValue(ResourceLocation location)
		{
			return registry[new RegistryItem(ID,location)];
		}
			
		public RegistryItem GetKey(T item)
		{
			return ValueToItem[item];
		}

		public bool Contains(ResourceLocation location)
		{
			return registry.ContainsKey(new RegistryItem(ID,location));
		}
		public bool Contains(T value)
		{
			return registry.ContainsValue(value);
		}
		public Registry(ResourceLocation ID) {
			this.ID = ID;	 
		}
		public void Remove()
		{

		}
	}
}

