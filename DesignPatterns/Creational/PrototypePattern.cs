//Prototype design pattern is used to create a duplicate object or clone of the current object to enhance performance.
using System;
using System.Collections.Generic;
public interface IPerson
{
    IPerson Clone();
}

public class PrototypeExample{
public class Tom : IPerson{
    private string name="Tom";
    public IPerson Clone(){
        return new Tom();
    }

    public override string ToString(){
        return this.name;
    }
}

public class Jon : IPerson{
    private string name="Jon";
    public IPerson Clone(){
        return new Jon();   
    }

     public override string ToString(){
        return this.name;
    }
}

public class Factory{
    private Dictionary<string,IPerson> dict=new Dictionary<string, IPerson>();
    public IPerson this[string name]{
        get {return dict[name];}
        set {dict.Add(name,value);}
    }
}


    public void Run(){
        var factory=new Factory();
        factory["Jon"]=new Jon();
        factory["Tom"] = new Tom();
        Console.WriteLine(factory["Jon"].Clone().ToString());   
    }
   
  

}

