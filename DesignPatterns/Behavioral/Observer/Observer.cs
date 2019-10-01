using System;
using System.Collections.Generic;
public static class Observer{
    public static void Run(){
        var ibm =new IBM("Microsoft", 100);
        var investor= new Investor("Igor");
        ibm.Attach(investor);       
        ibm.Price=300;
        ibm.Price = 200;
    }
}
public abstract class Stock{
    private readonly string _symbol;
    private decimal _price;
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

    public string Symbol => _symbol;

    private void Notify(){
        foreach(var inv in _investors){
            inv.Update(this);
        }
    }
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
        Console.WriteLine($"Notification for {this._name} Price of {stock.Symbol} has been changed  to {stock.Price}");
    }
}