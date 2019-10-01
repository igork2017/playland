using System;
using System.Collections.Generic;

public static class CommandUsage{
    public static void Run(){
        var user=new User();
        user.Compute('+', 5);
    }
}

abstract class Command{
    public abstract void Execute();
    public abstract void UnExecute();
}

class CalculatorCommand : Command{
    private char _operator;
    private int _operand;
    private Calculator _calculator;
    public CalculatorCommand(Calculator calculator, char @operator, int operand){
        this._calculator=calculator;
        this._operand=operand;
        this._operator=@operator;
    }
    public char Operator{
        set {_operator=value;}
    }
    public int Operand{
        set {_operand=value;}
    }
    public override void Execute(){
        _calculator.Operation(_operator, _operand);
    }
    // Unexecute last command

    public override void UnExecute()
    {
      _calculator.Operation(Undo(_operator), _operand);
    }
 
    // Returns opposite operator for given operator

    private char Undo(char @operator)
    {
      switch (@operator)
      {
        case '+': return '-';
        case '-': return '+';
        case '*': return '/';
        case '/': return '*';
        default: throw new

         ArgumentException("@operator");
      }
    }
}   

public class Calculator{
    private int _curr=0;
    public void Operation(char @operator, int operand)
    {
      switch (@operator)
      {
        case '+': _curr += operand; break;
        case '-': _curr -= operand; break;
        case '*': _curr *= operand; break;
        case '/': _curr /= operand; break;
      }
      Console.WriteLine(
        "Current value = {0,3} (following {1} {2})",
        _curr, @operator, operand);
    }
}
public class User {
  private Calculator _calculator = new Calculator();
  private List<Command> _commands=new List<Command>();
  private int _current=0;
  public void Compute(char @operator, int operand)
    {
      // Create command operation and execute it

      Command command = new CalculatorCommand(
        _calculator, @operator, operand);
      command.Execute();
 
      // Add command to undo list

      _commands.Add(command);
      _current++;
    }
}

