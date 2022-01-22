
using PassengerApp.BL;
using PassengerApp.Model;

Run();


static async void Run()
{
    Ticket t1 = new Sceniro1();
    Passenger passenger = new();

    await t1.Insert(passenger);
    
    Ticket t2 = new Sceniro2();
    //t2.Insert(passenger);

    Console.Read();
}