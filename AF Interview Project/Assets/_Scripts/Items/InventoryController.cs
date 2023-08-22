using System;

namespace AFSInterview.Items
{
	using System.Collections.Generic;
	using UnityEngine;

	public class InventoryController : MonoBehaviour
	{
		[SerializeField] private readonly List<Item> items = new ();
		[SerializeField] private int money;

		public int ItemsCount => items.Count;

		private int Money
		{
			get => money;
			set
			{
				if (value != money)
				{
					money = value;
					OnMoneyChanged?.Invoke(money);
				}
			}
		}

		public event Action<int> OnMoneyChanged;
		
		public void SellAllItemsUpToValue(int maxValue)
		{
			var tempMoney = Money;
			
			for (var i = items.Count - 1; i >= 0; i--)
			{
				var itemValue = items[i].Value;
				if (itemValue > maxValue) 
					continue;
				tempMoney += itemValue;
				items.RemoveAt(i);
			}

			Money = tempMoney;
		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}
	}
}