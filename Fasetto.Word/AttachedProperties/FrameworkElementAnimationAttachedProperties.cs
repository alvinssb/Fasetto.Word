using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties

        public bool FirstLoad { get; set; } = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;

            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            if (FirstLoad)
            {
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    element.Loaded -= onLoaded;
                    DoAnimation(element, (bool) value, true);
                    FirstLoad = false;
                };
                element.Loaded += onLoaded;
            }
            else
            {
                DoAnimation(element, (bool) value, false);
            }
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
        }
    }

    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, false);
            else
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, firstLoad ? 0 : 0.3f, false);
        }
    }

    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, false);
            else
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f, false);
        }
    }

    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f);
            else
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Right, firstLoad ? 0 : 0.3f);
        }
    }

    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, false);
            else
                await element.SlideAndFadeOutAsync(AnimationSlideInDirection.Bottom, firstLoad ? 0 : 0.3f, false);
        }
    }

    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value ? 0 : 0.3f, false);
        }
    }
}
