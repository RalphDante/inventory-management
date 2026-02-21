namespace InventoryApp.Services
{
    public class InventoryService
    {
        private string[,] products;
        private string[] initialStock;

        public InventoryService()
        {
            products = new string[2, 3]
            {
                { "Apples", "Milk", "Bread" },
                { "10", "5", "20" }
            };

            initialStock = new string[] { "10", "5", "20" };
        }

        public string[,] GetInventory()
        {
            return products;
        }

        public int GetProductCount()
        {
            return products.GetLength(1);
        }

        public string GetProductName(int index)
        {
            return products[0, index];
        }

        public string GetStock(int index)
        {
            return products[1, index];
        }

        public void UpdateStock(int index, string newStock)
        {
            products[1, index] = newStock;
        }

        public void ResetInventory()
        {
            for (int i = 0; i < initialStock.Length; i++)
            {
                products[1, i] = initialStock[i];
            }
        }
    }
}
