using System;
using EternalFrost.InGameTypes;
using EternalFrost.Item;
using MonoGame.Extended.Collections;

namespace EternalFrost.Collections
{
	public class Inventory
	{
		public Bag<WorldItem> ItemsList;
		public int Capacity { get; private set; }
		public Inventory(int size)
		{
			Capacity = size;
			ItemsList = new Bag<WorldItem>(size);
		}
		public bool AddItem(WorldItem item)
		{
			for(int i = 0; i < ItemsList.Count; i++) {
				if (!ItemsList[i].Equals(item)) continue;
				ItemsList[i].Count += ItemsList.Count;
				return true;
			}
			if (ItemsList.Count >= Capacity) return false;
			ItemsList.Add(item);
			return true;
		}
		public WorldItem Drop(int index, int count)
		{
			WorldItem item = ItemsList[index];
			if (item == null)
				return new WorldItem(Items.EMPTY,1);
			if (item.Count <= count) {
				ItemsList.Remove(item);
				return item;
			}
			item.Count -= count;
			var newItem = item.Clone();
			newItem.Count = count;
			return newItem;
		}
	}
}

