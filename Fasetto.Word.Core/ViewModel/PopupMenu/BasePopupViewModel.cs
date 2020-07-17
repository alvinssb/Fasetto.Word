using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        public string BubbleBackground { get; set; }

        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        public BaseViewModel Content { get; set; }

        #endregion

        public BasePopupViewModel()
        {
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }
    }
}
