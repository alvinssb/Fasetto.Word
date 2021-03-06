﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class ChatPage:BasePage<ChatMessageListViewModel>
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        protected override void OnViewModelChanged()
        {
            if (ChatMessageList == null)
                return;

            var sb = new Storyboard();
            sb.AddFadeIn(1);
            sb.Begin(ChatMessageList);
            MessageText.Focus();
        }

        private void MessageText_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    var index = textBox.CaretIndex;
                    textBox.Text = textBox.Text.Insert(index, Environment.NewLine);
                    textBox.CaretIndex = index + Environment.NewLine.Length;
                }
                else
                {
                    ViewModel.Send();
                }
                e.Handled = true;
            }
            
        }
    }
}
