using System;

public class Reservation
{
    public int Id { get; private set; }
    public int ClientId { get; private set; }
    public string ClientName { get; private set; }
    public string ClientPhone { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public string Comment { get; private set; }
    public Table AssignedTable { get; private set; }
    private Reservation(int id, int clientId, string clientName, string clientPhone, DateTime startTime, DateTime endTime, string comment, Table assignedTable)
    {
        Id = id;
        ClientId = clientId;
        ClientName = clientName;
        ClientPhone = clientPhone;
        StartTime = startTime;
        EndTime = endTime;
        Comment = comment;
        AssignedTable = assignedTable;
    }

    public static Reservation CreateNew(int id, int clientId, string clientName, string clientPhone, DateTime startTime, DateTime endTime, string comment, Table assignedTable)
    {
        var reservation = new Reservation(id, clientId, clientName, clientPhone, startTime, endTime, comment, assignedTable);
        assignedTable.Schedule.Add(reservation);
        return reservation;
    }

    public void ChangeDetails(DateTime newStartTime, DateTime newEndTime, string newComment)
    {
        AssignedTable.Schedule.Remove(this);
        StartTime = newStartTime;
        EndTime = newEndTime;
        Comment = newComment;

        AssignedTable.Schedule.Add(this);

        Console.WriteLine($"Бронирование ID {Id} успешно изменено.");
    }

    public void Cancel()
    {
        AssignedTable.Schedule.Remove(this);
        Console.WriteLine($"Бронирование ID {Id} для стола {AssignedTable.Id} отменено.");
    }
}