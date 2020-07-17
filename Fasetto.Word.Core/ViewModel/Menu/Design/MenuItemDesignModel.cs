using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class MenuItemDesignModel : MenuItemViewModel
    {
        public static MenuItemDesignModel Instance=>new MenuItemDesignModel();

        public MenuItemDesignModel()
        {
            Text = "Hello World";
            Icon = IconType.File;
        }
    }
}
