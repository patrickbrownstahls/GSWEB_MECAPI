using StahlsCloud_MEC_InventoryAPI.Models;
using System.Web.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;

namespace StahlsCloud_MEC_InventoryAPI.Controllers
{
    public class ItemsController : ApiController
    {   
        
        Item[] items = new Item[]
        {
            //Test Item 1 
            //MC200SPGLT001     ID  MC200GFL001  CAD-CUT   20"    Glitter Flake   Black 
            new Item {

                item_attrs = new ItemAttr
                    {
                        business_unit = "ID",
                        business_item_id = "MC200GFL001",
                        business_name = "CAD-CUT   20    Glitter Flake   White",
                        business_description = "Custitemshorname",
                        business_class_id = "userdef03-userfed05?"
                    },
                item_status = "Stocked", // select itemgedsc from iv00101 where itemnmbr  = 'MC200SPGLT001'
                child_items = new List<Item> { },        //Need to implement child item being returned
                inventory = new List<Inventory> // select * from MEC.dbo.IV00112 where ITEMNMBR = 'MC200SPGLT001'
                    { new Inventory
                        {
                        warehouse_id = "CHSTRFLD",
                        quantity  = 345,
                        quantity_allocated = 45,
                        bin_inventory = new List<BinInventory>
                            {
                                new BinInventory { inventory_scheme = "MEC",inventory_locator = "0-A-25-A-2", quantity = 300 },
                                new BinInventory { inventory_scheme = "MEC", inventory_locator = "7-B-01-D-1", quantity = 45 }
                            }
                        }
                    },
                quantity_measure = "YARD",      //Default unit of measure
                available_measure = new List<string> {"YARD", "01Yd RL", "05Yd RL", "10Yd RL", "25Yd RL"}, //select * From IV40202  where uomschdl ='MC050YARD' ORDER BY UOFM
                }
            ,
            //Test Item 2
            //MC200SPGLT168     ID  MC200GFL002  CAD-CUT   20"    Glitter Flake   Black 
            new Item {

                item_attrs = new ItemAttr {business_unit = "ID", business_item_id = "MC200GFL002", business_name = "CAD-CUT   20    Glitter Flake   Black", business_description = "Custitemshorname", business_class_id = "userdef03-userfed05?" },
                item_status = "Stocked", // select itemgedsc from iv00101 where itemnmbr  = 'MC200SPGLT168'
                child_items = new List<Item> { },        //Need to implement child item being returned
                inventory = new List<Inventory> // select * from MEC.dbo.IV00112 where ITEMNMBR = 'MC200SPGLT168'
                    { new Inventory
                        {
                        warehouse_id = "CHSTRFLD",
                        quantity  = 2500,
                        quantity_allocated = 0,
                        bin_inventory = new List<BinInventory>
                            {
                                new BinInventory { inventory_scheme = "MEC",inventory_locator = "0-A-25-B-2", quantity = 50 },
                                new BinInventory { inventory_scheme = "MEC", inventory_locator = "0-A-25-C-2", quantity = 2450 }
                            }
                        }
                    },
                quantity_measure = "YARD",      //Deafult unit of measure
                available_measure = new List<string> {"YARD", "01Yd RL", "05Yd RL", "10Yd RL", "25Yd RL"}, //select * From IV40202  where uomschdl ='MC050YARD' ORDER BY UOFM
                }


        };
        public IEnumerable<Item> GetAllItems()
        {

            return items;
        }

        //public IEnumerable<Item> GetAllItems()
        //{

        //    return items;
        //}

        public IHttpActionResult GetItem(string itemId)
        {
            var item = items.FirstOrDefault((i) => i.item_attrs.business_item_id == itemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

    };
        

};

