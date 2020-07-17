using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public static class IconTypeExtensions
    {
        public static string ToFontAwesom(this IconType type)
        {
            switch (type)
            {
                case IconType.File:
                    return "\uf0f6";
                case IconType.Picture:
                    return "\uf1c5";
                default:
                    return null;
            }
        }
    }
}
