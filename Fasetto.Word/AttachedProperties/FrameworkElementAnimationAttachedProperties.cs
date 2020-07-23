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
        #region Protect Properties

        protected Dictionary<WeakReference, bool> AlreadyLoaded = new Dictionary<WeakReference, bool>();

        protected Dictionary<WeakReference, bool> FirstLoadValue = new Dictionary<WeakReference, bool>();

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element))
                return;

            var alreadyLoadedReference = AlreadyLoaded.FirstOrDefault(f => f.Key.Target == sender);
            var firstLoadReference = FirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);
            if ((bool) sender.GetValue(ValueProperty) == (bool) value && alreadyLoadedReference.Key != null)
                return;

            if (alreadyLoadedReference.Key == null)
            {
                var weakReference = new WeakReference(sender);
                AlreadyLoaded[weakReference] = false;
                element.Visibility = Visibility.Hidden;
                RoutedEventHandler onLoaded = null;
                onLoaded = async (ss, ee) =>
                {
                    element.Loaded -= onLoaded;
                    await Task.Delay(5);
                    firstLoadReference = FirstLoadValue.FirstOrDefault(f => f.Key.Target == sender);
                    DoAnimation(element, firstLoadReference.Key != null ? firstLoadReference.Value : (bool) value, true);
                    AlreadyLoaded[weakReference] = true;
                };
                element.Loaded += onLoaded;
            }
            else if (alreadyLoadedReference.Value == false)
                FirstLoadValue[new WeakReference(sender)] = (bool) value;
            else
                DoAnimation(element, (bool) value, false);
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

    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value, bool firstLoad)
        {
            if (value)
                await element.FadeInAsync(firstLoad, firstLoad ? 0 : 0.3f);
            else
                await element.FadeOutAsync(firstLoad ? 0 : 0.3f);
        }
    }
}
