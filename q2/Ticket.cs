using System.Data;

namespace q2;

// استخدام الـ Primary Constructor بشكل سليم
public class Ticket(string movie, TicketType type = TicketType.Standard,
    double price = 50, int number = 1, char row = 'A')
{
    public string Movie
    {
        get
        {
            if (string.IsNullOrWhiteSpace(movie))
            {
                throw new Exception("there is no movie with this name");
            }

            return movie;
        }
        set;
    } //= movie;

    public TicketType Type { get; set; } = type;
    
    public Seat Seat { get; set; } = new()
    {
        Row = row,
        Number = number
    };

    // هنا خَزّنا السعر في Field عشان نقدر نعدله لما يحصل خصم
    public double Price
    {
        get
        {
            if (price < 0)
                throw new Exception("not valid price");
            return price;
        }
        set;
    } 

    // حساب الإجمالي بناءً على السعر الحالي في الـ Field
    public double CalcTotal(double taxPercent)
    {
        return Price + (Price * taxPercent / 100);
    }

    // أضفنا الـ ref عشان نعدل المتغير برة وجوة ونصفر الخصم المستهلك
    public void ApplyDiscount(ref double discountAmount)
    {
        // الشرط التمام (أكبر من صفر وأقل من أو يساوي السعر الحالي)
        if (discountAmount > 0 && discountAmount <= Price)
        {
            Price -= discountAmount; // بنعدل السعر المتخزن جوة الكلاس
            discountAmount = 0;       // بنصّفر الخصم لأنه استُهلك
        }
    }

    // دالة الطباعة اللي كانت ناقصة ومظبوطة على الأوت بوت بتاع الشيت
    public void PrintTicket(double discountBefore, double discountAfter)
    {
        Console.WriteLine("\n===== Ticket Info =====");
        Console.WriteLine($"Movie: {Movie}");
        Console.WriteLine($"Type : {Type}");
        Console.WriteLine($"Seat : {Seat.Row}{Seat.Number}");
        Console.WriteLine($"Price: {Price:F2}"); // السعر بعد الخصم
        Console.WriteLine($"Total (14% tax): {CalcTotal(14):F2}");
        Console.WriteLine("===== After Discount =====");
        Console.WriteLine($"Discount Before: {discountBefore:F2}");
        Console.WriteLine($"Discount After: {discountAfter:F2}");
    }

    public static Ticket ReadData()
    {
        Console.Write("Enter Movie Name: ");
        string movie = Console.ReadLine();
    
        Console.Write("Enter Ticket Type ( 0=Standard, 1=VIP, 2=IMAX ): ");
        TicketType type = (TicketType)Convert.ToInt32(Console.ReadLine());
    
        Console.Write("Enter Seat Row (A, B, C...): ");
        char row = Convert.ToChar(Console.ReadLine());
    
        Console.Write("Enter Seat Number: ");
        int num = Convert.ToInt32(Console.ReadLine());
    
        Console.Write("Enter Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Discount Amount: ");
        double discountAmount = Convert.ToDouble(Console.ReadLine());
        double discountBefore = discountAmount; 

        // الـ Parameter الثالث في الـ Primary constructor هو السعر، ثم الرقم، ثم الحرف
        // رتبناهم هنا بناءً على تعريف الكلاس فوق (movie, type, price, number, row)
        Ticket t = new Ticket(movie, type, price, num, row);
    
        // دلوقتي الـ ref هتشتغل تمام لأن التعريف والاستدعاء متطابقين
        t.ApplyDiscount(ref discountAmount); 
    
        t.PrintTicket(discountBefore, discountAmount);

        return t;
    }
}