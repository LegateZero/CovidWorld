using System;

namespace WpfApp11.Infrastructure.Commands.Base;

public class LambdaCommand : Command
{
    private Action<object> _Execute;
    private Func<object, bool>? _CanExecute;
    public override void Execute(object? parameter)
    {
        _Execute?.Invoke(parameter);
    }

    public override bool CanExecute(object parameter) => _CanExecute is null ? true:  _CanExecute(parameter);

    public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _Execute = execute;
        _CanExecute = canExecute;
    }
}