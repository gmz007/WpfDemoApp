using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoApp.Views
{
    /// <summary>
    /// Wpf version of dialog content, following specifications from https://learn.microsoft.com/en-us/windows/apps/design/controls/dialogs-and-flyouts/dialogs
    /// </summary>
    public partial class FluentDialog : Window
    {
        public new string? Title
        {
            get => DialogTitle.Text;
            set => DialogTitle.Text = value;
        }

        public new string? Content
        {
            get => DialogContent.Text;
            set => DialogContent.Text = value;
        }

        private readonly DialogButton _primaryButton = new DialogButton(FluentDialogButton.Primary);

        public string? PrimaryButtonText
        {
            get => _primaryButton.Content as string;
            set => _primaryButton.Content = value;
        }

        private readonly DialogButton _secondaryButton = new DialogButton(FluentDialogButton.Secondary);

        public string? SecondaryButtonText
        {
            get => _secondaryButton.Content as string;
            set => _secondaryButton.Content = value;
        }

        private readonly DialogButton _closeButton = new DialogButton(FluentDialogButton.Close);

        public string? CloseButtonText
        {
            get => _closeButton.Content as string;
            set => _closeButton.Content = value;
        }

        public FluentDialogButton? DefaultButton { get; set; } = null;

        public DialogResult Result { get; set; }

        public new DialogResult ShowDialog()
        {
            if (string.IsNullOrWhiteSpace(PrimaryButtonText) &&
                string.IsNullOrWhiteSpace(SecondaryButtonText) &&
                string.IsNullOrWhiteSpace(CloseButtonText))
            {
                throw new Exception(
                    "At least one of PrimaryButtonText, SecondaryButtonText or CloseButtonText must be populated.");
            }

            if (AddButtonToGrid(_primaryButton))
            {
                _primaryButton.Click += (_, _) =>
                {
                    Result = Views.DialogResult.Primary;
                    Close();
                };
            }

            if (AddButtonToGrid(_secondaryButton))
            {
                _secondaryButton.Click += (_, _) =>
                {
                    Result = Views.DialogResult.Secondary;
                    Close();
                };
            }

            if (AddButtonToGrid(_closeButton))
            {
                _closeButton.Click += (_, _) =>
                {
                    Result = Views.DialogResult.Close;
                    Close();
                };
            }

            if (ButtonGrid.Children.Count == 1)
            {
                ButtonGrid.Children.Insert(0, new Border() { Margin = new Thickness(0, 0, 8, 0) });
            }

            base.ShowDialog();

            return Result;
        }

        private bool AddButtonToGrid(DialogButton button)
        {
            if (button.Content is not string)
            {
                return false;
            }

            button.IsDefault = button.ButtonType == DefaultButton;
            button.IsCancel = button.ButtonType == FluentDialogButton.Close;
            button.Margin = ButtonGrid.Children.Count > 0
                ? new Thickness(8, 0, 0, 0)
                : new Thickness(0);
            button.Style = button.IsDefault
                ? Resources["FluentAccentButton"] as Style
                : Resources["FluentButton"] as Style;

            ButtonGrid.Children.Add(button);

            return true;
        }

        public FluentDialog()
        {
            InitializeComponent();
        }

        private void Window_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }

    public class DialogButton : Button
    {
        public FluentDialogButton ButtonType { get; }

        public DialogButton(FluentDialogButton buttonType)
        {
            ButtonType = buttonType;
        }
    }

    public enum FluentDialogButton
    {
        Primary,
        Secondary,
        Close
    }

    public enum DialogResult
    {
        Primary,
        Secondary,
        Close
    }
}
