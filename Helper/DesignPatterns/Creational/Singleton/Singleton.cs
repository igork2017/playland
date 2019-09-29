using System;

public class Singleton{
    private static Singleton instance  = null;
    private Singleton(){}
    private static object syncLock = new object();
    public static Singleton GetInstance{
        get
        { 
            lock(syncLock){
             if(instance==null)
                 instance=new Singleton();
                 return instance;
            }
        }
    }
}