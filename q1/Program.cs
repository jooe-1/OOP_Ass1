namespace q1;

class Program
{
    static void Main(string[] args)
    {
        //1)  class is a reference type, stored in heap
        //but struct is a value type,stored in stack
        
        
        MyClass c1 = new MyClass();
        c1.Value = 10;
        MyClass c2 = c1;
        c2.Value = 20;   
        Console.WriteLine($"Class c1: {c1.Value}, c2: {c2.Value}"); 

        MyStruct s1 = new MyStruct();
        s1.Value = 10;
        MyStruct s2 = s1; 
        s2.Value = 20;   
        Console.WriteLine($"Struct s1: {s1.Value}, s2: {s2.Value}"); 
        //----------------------------------------------
        //2)public : I can see it every where
        //  private : I can see it inside class only
        
        

        BankAccount b = new BankAccount();
        b.Name = "joo";
        //b._balance = 1000; // error I Cannot see it
        //---------------------------------------------------------
        //
        //3) //1) open rider
        //   //2) create class Library(project)
        //   //3) add reference to main project
        
        //--------------------------------------------------
        
        //4) project that have classes and methods to use ,not produces exe file
        // why to use it ?
        //1) code reusability
        //2) abstraction
    }
}


class MyClass
{
    public int Value;
}


struct MyStruct
{
    public int Value;
}

class BankAccount
{
    public string? Name ; 
    private double _balance;     

}