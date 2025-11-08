using System;
using System.Collections.Generic;
using System.Linq;

public enum TableLocation
{
    Window,     
    Aisle,       
    Exit,        
    DeepInside   
}

public class Table
{
    public int Id { get; private set; }
    public TableLocation Location { get; private set; }
    public int Seats { get; private set; }
    public List<Reservation> Schedule { get; private set; }

    private Table(int id, TableLocation location, int seats)
    {
        Id = id;
        Location = location;
        Seats = seats;
        Schedule = new List<Reservation>();
    }

    public static Table CreateNew(int id, TableLocation location, int seats)
    {
        return new Table(id, location, seats);
    }

    public void ChangeInfo(TableLocation newLocation, int newSeats)
    {
        Location = newLocation;
        Seats = newSeats;
        Console.WriteLine($"Информация о столе ID {Id} успешно обновлена.");
    }
    public void DisplayInfo()
    {
        string locationStr = Location switch
        {
            TableLocation.Window => "у окна",
            TableLocation.Aisle => "у прохода",
            TableLocation.Exit => "у выхода",
            TableLocation.DeepInside => "в глубине",
            _ => "неизвестно"
        };

        Console.WriteLine("***************************************************************");
        Console.WriteLine($"ID: -------------------------------------------------------------------------------{Id:D2}.");
        Console.WriteLine($"Расположение:-------------------------------------------------------«{locationStr}».");
        Console.WriteLine($"Количество мест: ------------------------------------------------------------{Seats}");
        Console.WriteLine("Расписание:");

        for (int hour = 9; hour < 21; hour++)
        {
            var slotStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hour, 0, 0);
            var slotEnd = slotStart.AddHours(1);

            var activeReservation = Schedule.FirstOrDefault(r => r.StartTime < slotEnd && r.EndTime > slotStart);

            string line = $"{hour}:00-{hour + 1}:00 ";
            if (activeReservation != null)
            {
                line += $"-------------------ID {activeReservation.Id}, {activeReservation.ClientName}, {activeReservation.ClientPhone}";
            }
            Console.WriteLine(line.PadRight(75, '-'));
        }
        Console.WriteLine("***************************************************************");
    }
    public bool IsAvailable(DateTime startTime, DateTime endTime)
    {
        return !Schedule.Any(r => startTime < r.EndTime && endTime > r.StartTime);
    }
}