using System;
namespace UberEatsWebApi.Models
{
    public class Products
    {
		public int Id { get; set; }
		public string ItemName { get; set; }
		public double ItemPrice { get; set; }
		public string Description { get; set; }
		public string ItemType { get; set; }
		public int UserID { get; set; }
		public byte[] ItemImage { get; set; }
		public bool Archived { get; set; }

        public Products(int id, string name, double price, byte[] image, string description, string itemType)
		{
            Id = id;
            ItemName = name;
            ItemPrice = price;
            ItemImage = image;
            Description = description;
            ItemType = itemType;
		}
		
    }
}
