using OrderDeliverySimulation.Models;

namespace OrderDeliverySimulation.Services;

public class ItemCreator
{
    public readonly ItemValidator _itemValidator;
    
    private int _nextItemId;

    public ItemCreator(ItemValidator itemValidator)
    {
        _itemValidator = itemValidator;
    }
    
    public List<OrderItem> CreateListOfItems()
    {
        List<OrderItem> items = new();
        
        while (true)
        {
            Console.Clear();
            
            Console.WriteLine("=== ADD ITEM ===");
            Console.WriteLine("1. Create Item");
            // Console.WriteLine("2. Update Item");
            // Console.WriteLine("3. Delete Item");
            Console.WriteLine("4. Finish");
            Console.WriteLine("5. Cancel");

            Console.WriteLine($"Quantity of items: {items.Count}");
            
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                var item = CreateItem();
                items.Add(item);
            } else if (choice == "2")
            {
                if (items.Count == 0)
                {
                    Console.WriteLine("No items to update.");
                    continue; 
                }

                // UpdateItem();
            } else if (choice == "4")
            {
                return items;
            }
        }
    }

    private OrderItem CreateItem()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CREATE ITEM ===");

            Console.WriteLine("Enter the name of the item:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter the price of the item:");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price.");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("Enter the quantity of the item:");
            if (!int.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Invalid quantity.");
                Console.ReadKey();
                continue;
            }

            var item = new OrderItem(
                _nextItemId++,
                name,
                price,
                quantity
            );

            if (!_itemValidator.ValidateOrderItem(item))
            {
                Console.WriteLine("Invalid item data.");
                Console.ReadKey();
                continue;
            }

            return item;
        }
    }
}