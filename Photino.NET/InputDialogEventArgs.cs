namespace Photino.NET;

public class InputDialogEventArgs : EventArgs
{
    internal InputDialogEventArgs(PhotinoWindow window, string message)
    {
        Window = window;
        Message = message ?? string.Empty;
    }

    public PhotinoWindow Window { get; }

    public string Message { get; }

    public bool Handled { get; private set; }

    internal bool Dismissed { get; private set; }

    public void DismissDialog()
    {
        Handled = true;
        Dismissed = true;
    }

    protected void MarkHandled()
    {
        Handled = true;
        Dismissed = false;
    }
}

public sealed class ConfirmInputDialogEventArgs : InputDialogEventArgs
{
    internal ConfirmInputDialogEventArgs(PhotinoWindow window, string message)
        : base(window, message)
    {
    }

    internal bool Confirmation { get; private set; }

    public void SetDialogConfirmation(bool confirmation)
    {
        Confirmation = confirmation;
        MarkHandled();
    }
}

public sealed class PromptInputDialogEventArgs : InputDialogEventArgs
{
    internal PromptInputDialogEventArgs(PhotinoWindow window, string message, string defaultInput)
        : base(window, message)
    {
        DefaultInput = defaultInput ?? string.Empty;
    }

    public string DefaultInput { get; }

    internal string Input { get; private set; }

    public void SetDialogInput(string input)
    {
        Input = input ?? string.Empty;
        MarkHandled();
    }
}
