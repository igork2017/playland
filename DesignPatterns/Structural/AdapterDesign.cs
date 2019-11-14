using System;


public class SquarePeg{
    private double width;
    public SquarePeg(double width){
        this.width=width;
    }

    public double GetWidth(){
        return width;
    }

    public void setWidth(double width){
        this.width=width;
    }
}
public class RoundHole{
    private int radius;

    public RoundHole(int radius){
       this.radius=radius;
    }

    public int GetRadius(){
        return this.radius;
    }
}

