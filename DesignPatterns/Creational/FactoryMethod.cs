// Factory method design pattern abstract the process of object creation and allows the object to be created at run-time when it required.
using System;

interface IProduct{

}

class ConcreteProductA : IProduct{

}

class ConcreteProductB : IProduct{

}

abstract class Creator{
    public abstract IProduct FactoryMethod(string type);
}

class ConcreteCreator: Creator{
    public override IProduct FactoryMethod(string type){
        switch(type){
            case "A": return new ConcreteProductA();
            case "B": return new ConcreteProductB();
            default: throw new ArgumentException("invalid type", "type");
        }
    }
}

