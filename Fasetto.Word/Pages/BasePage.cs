using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class BasePage : UserControl
    {
        #region Public Properties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.4f;

        public bool ShouldAnimateOut { get; set; }

        #endregion

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_LoadedAsync;
        }

        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimationOut();
            else
                await AnimationIn();
        }

        public async Task AnimationIn()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, SlideSeconds, size: (int) Application.Current.MainWindow.Width);
                    break;
            }
        }

        public async Task AnimationOut()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds);
                    break;
            }
        }
    }

    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Private Members

        private VM _viewMode;

        #endregion

        #region Public Properties

        public VM ViewModel
        {
            get => _viewMode;
            set
            {
                if (_viewMode == value)
                    return;

                _viewMode = value;
                DataContext = _viewMode;
            }
        }

        #endregion

        public BasePage()
        {
            ViewModel = new VM();
        }

        
    }
}
