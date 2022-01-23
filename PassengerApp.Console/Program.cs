
using PassengerApp.BL;
using PassengerApp.Model;

await Run();


static async Task Run()
{
    Ticket t1 = new Sceniro1();
    Passenger passenger = new();

    passenger.UniquePassengerId = Guid.NewGuid();
    passenger.Name = "asdsa";
    passenger.Surname = "sdfs";
    passenger.DocumentNo = "324";

    await t1.Insert(passenger);
    
    Ticket t2 = new Sceniro2();
    passenger.UniquePassengerId = Guid.NewGuid();
    await t2.Insert(passenger);

    Console.Read();
}