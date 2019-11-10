using System;

public class Pizza{
    private string sauce="";
    private string topping="";
    public void SetSauce(string sauce){
        this.sauce=sauce;
    }
    public void SetTopping(string topping){
        this.topping=topping;
    }
}

public abstract class PizzaBuilder{
    protected Pizza pizza;
    public Pizza GetPizza(){ return pizza;}
    public void CreateNewPizza(){
        pizza=new Pizza();
    }

    public abstract void BuildTopping();
    public abstract void BuildSauce();
}

public class PepperoniPizza: PizzaBuilder{
    public override void BuildTopping(){
        pizza.SetTopping("Pepperoni");
    }

    public override void BuildSauce(){
        pizza.SetSauce("mild");
    }
}

public class Waiter{
    private PizzaBuilder builder;
    public void SetBuilder(PizzaBuilder pizzaBuilder){
        builder=pizzaBuilder;
    }

    public Pizza GetPizza(){
        return builder.GetPizza();
    }

    public void ConstructPizza(){
        builder.CreateNewPizza();
        builder.BuildSauce();    
    }
}
