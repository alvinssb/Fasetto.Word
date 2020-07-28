using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel {Text = "Attach a file...", Type = MenuItemType.Header},
                    new MenuItemViewModel {Text = "From Computer", Icon = IconType.File},
                    new MenuItemViewModel {Text = "From Pictures", Icon = IconType.Picture}
                })
            };
        }
    }
}
