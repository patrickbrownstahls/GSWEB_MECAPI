using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StahlsCloud_MEC_InventoryAPI.Models
{
   
    public class Item
    {
        public ItemAttr item_attrs { get; set; }
        public string item_status { get; set; }
        public List<Item> child_items { get; set; }
        public List<Inventory> inventory { get; set; }
        public string quantity_measure { get; set; }
        public List<string> available_measure { get; set; }
    }

        public class ItemAttr
    {
        public string business_unit { get; set; }
        public string business_item_id { get; set; }
        public string business_class_id { get; set; }
        public string business_name { get; set; }
        public string business_description { get; set; }

      
    }

    public class BinInventory
    {
        public string inventory_scheme { get; set; }        //Ex) MEC- MEC uses a distinct BIN schema with intuitive logic, other warehouses may use other logic in the future
        public string inventory_locator { get; set; }       //Bin location: Ex) "0-A-01-B-1"  0 = Location of warehouse; A = Aisle in that location of warehouse; 01 = Section and Side of Aisle; B = Shelf in Section and Side of Aisle; 1 = Bin of the Shelf 
        public int quantity { get; set; }                   //
    }

    public class Inventory
    {
        public string warehouse_id { get; set; }            //Ex) Location Code, CHSTRFLD, DALLAS, ARIZONA
        public int quantity { get; set; }                   //Total Qty for all of location
        public int quantity_allocated { get; set; }         //
        public List<BinInventory> bin_inventory { get; set; }   //
    }
}