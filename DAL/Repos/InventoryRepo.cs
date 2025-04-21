using WpfMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.DAL.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll()
        {
            return Context.Inventory.OrderBy(x => x.Id).ToList();
        }
    }
}
