// See https://aka.ms/new-console-template for more information
public abstract class Vehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }

    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

    protected Vehicle(int id, string brand, string model, int year)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        IsAvailable = true;
    }

    public abstract void DisplayInfo();

    public abstract void Reserve(string customer);
    public abstract void CancelReservation();
    
}
