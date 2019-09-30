using System;
using System.Collections.Generic;
public static class Observer{
    public static void Run(){
        var ibm =new IBM("Microsoft", 100);
        ibm.Attach(new Investor("Igor"));
        ibm.Price=300;
    }
}
public abstract class Stock{
    private readonly string _symbol;
    private readonly decimal _price;
    private List<IInvestor> _investors= new List<IInvestor>();
    public Stock (string symbol, decimal price){
        _symbol=symbol;
        _price=price;
    }
    
    public void Attach(IInvestor investor){
        _investors.Add(investor);
    }

    public void Remove(IInvestor investor){
        _investors.Remove(investor);
    }
    public decimal Price{
        set { 
            if(_price!=value){
              _price=value;
              Notify();  
            }
        }
        get { return _price;}
    }

    private void Notify(){
        foreach(var investor in _investors){
            inverstor.Update(this);
        }
    }

    public string Symbol {get {return _symbol;}}
}


public class IBM : Stock{
    public IBM(string symbol, decimal price): base(symbol, price){}
}
public interface IInvestor{
    public void Update(Stock stock);
}

public class Investor:IInvestor{
    private string _name;
    private Stock _stock;
    public Investor(string name){
        _name=name;
    }

    public Stock Stock{
        set{_stock=value; }
        get{ return _stock;}
    }

    public void Update(Stock stock){
        Console.WriteLine($"Price has been changed from {_stock.Price} to {stock.Price}");
        this.Stock=stock;
    }
}