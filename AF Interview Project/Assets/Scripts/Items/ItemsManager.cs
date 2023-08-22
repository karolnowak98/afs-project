namespace AFSInterview.Items
{
	using TMPro;
	using UnityEngine;

	public class ItemsManager : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI moneyTMP;
		[SerializeField] private InventoryController inventoryController;
		[SerializeField] private int itemSellMaxValue;
		[SerializeField] private Transform itemSpawnParent;
		[SerializeField] private GameObject itemPrefab;
		[SerializeField] private BoxCollider itemSpawnArea;
		[SerializeField] private float itemSpawnInterval;

		private float nextItemSpawnTime;
		private Camera mainCam;
		private LayerMask itemLayerMask;
		
		private void Awake()
		{
			if (Camera.main != null)
			{
				mainCam = Camera.main;
			}
			
			else
			{
				Debug.LogWarning("There is no main camera on the scene!!");
			}
			
			itemLayerMask = LayerMask.GetMask("Item");
		}
		
		private void OnEnable()
		{
			inventoryController.OnMoneyChanged += UpdateMoneyTMP;
		}

		private void OnDisable()
		{
			inventoryController.OnMoneyChanged -= UpdateMoneyTMP;
		}

		private void Update()
		{
			if (Time.time >= nextItemSpawnTime)
				SpawnNewItem();
			
			if (Input.GetMouseButtonDown(0))
				TryPickUpItem();
			
			if (Input.GetKeyDown(KeyCode.Space))
				inventoryController.SellAllItemsUpToValue(itemSellMaxValue);
		}

		private void UpdateMoneyTMP(int moneyValue)
		{
			moneyTMP.text = "Money: " + moneyValue;
		}

		private void SpawnNewItem()
		{
			nextItemSpawnTime = Time.time + itemSpawnInterval;
    
			var randomPosition = GenerateRandomSpawnPosition();
			Instantiate(itemPrefab, randomPosition, Quaternion.identity, itemSpawnParent);
		}
		
		//One more way to optimize is to create a pre-configured array with random positions (object pooling design pattern), depending on the project design
		private Vector3 GenerateRandomSpawnPosition()
		{
			var spawnAreaBounds = itemSpawnArea.bounds;
			return new Vector3(
				Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x),
				0f,
				Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z)
			);
		}
		
		private void TryPickUpItem()
		{
			var ray = mainCam.ScreenPointToRay(Input.mousePosition);
			
			if (!Physics.Raycast(ray, out var hit, 100f, itemLayerMask)) 
				return;
    
			if (!hit.collider.TryGetComponent<IItemHolder>(out var itemHolder)) 
				return;
			
			var item = itemHolder.GetItem(true);
			inventoryController.AddItem(item);
			
			//If not needed log could be deleted
			Debug.Log($"Picked up {item.Name} with value of {item.Value} and now have {inventoryController.ItemsCount} items");
		}
	}
}