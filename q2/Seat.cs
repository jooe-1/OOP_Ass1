namespace q2;

public struct Seat
{
    public char Row { get; set; }
    public int Number { get; set; }
    public Seat(char row, int number)
    {
        Row = row;
        Number = number;
    }

    public Seat()
    {
        Row = 'A';
        Number = 1;
    }

    public override string ToString()
    {
        return Row+Number.ToString();
    }
}