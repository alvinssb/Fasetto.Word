using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dna;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public class BasePage : UserControl
    {

        #region Private Member

        private object _viewModel;

        #endregion

        #region Public Properties

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.4f;

        public bool ShouldAnimateOut { get; set; }

        public object ViewModelObject
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;

                OnViewModelChanged();
                DataContext = _viewModel;
            }
        }

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
                await AnimationOutAsync();
            else
                await AnimationInAsync();
        }

        public async Task AnimationInAsync()
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

        public async Task AnimationOutAsync()
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

        protected virtual void OnViewModelChanged() { }
    }

    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        #region Public Properties

        public VM ViewModel
        {
            get => (VM) ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                ViewModel = new VM();
            else
                ViewModel = Framework.Service<VM>() ?? new VM();
        }

        public BasePage(VM specificViewModel = null)
        {
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
            {
                if (DesignerProperties.GetIsInDesignMode(this))
                    ViewModel = new VM();
                else
                    ViewModel = Framework.Service<VM>() ?? new VM();
            }
        }

    }
}
