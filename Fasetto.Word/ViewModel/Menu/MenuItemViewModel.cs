using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class MenuItemViewModel : BaseViewModel
    {
        public string Text { get; set; }

        public IconType Icon { get; set; }

        public MenuItemType Type { get; set; }
    }
}
