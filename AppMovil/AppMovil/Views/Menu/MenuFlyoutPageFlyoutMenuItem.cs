using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovil.Views.Menu
{
    public class MenuFlyoutPageFlyoutMenuItem
    {
        public MenuFlyoutPageFlyoutMenuItem()
        {
            TargetType = typeof(MenuFlyoutPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}