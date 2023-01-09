public abstract class DataStorage
{
    public abstract int GetSomeValue(string path, int quantity);
    public abstract void SaveSomeValue(int value);
}
public abstract class RemovableDataStorage : DataStorage
{
    public abstract void RemoveSomeValue(int value);
    public DateTime TimeToDelete;

    protected RemovableDataStorage(DateTime timeToDelete)
    {
        TimeToDelete = timeToDelete;
    }
}

public class LocalDataStorage : DataStorage
{
    public override int GetSomeValue(string path, int quantity)
    {
        // Implementation goes here
        return 100;
    }

    public override void SaveSomeValue(int value)
    {
        // Implementation goes here
    }
}

public class WebDataStorage : DataStorage
{
    public override int GetSomeValue(string path, int quantity)
    {
        // Implementation goes here
        return 100;
    }
    public override void SaveSomeValue(int value)
    {
        // Implementation goes here
    }
}

public class LocalRemovableDataStorage : RemovableDataStorage
{
    public override int GetSomeValue(string path, int quantity)
    {
        // Implementation goes here
        return 100;
    }

    public override void SaveSomeValue(int value)
    {
        // Implementation goes here
    }

    public override void RemoveSomeValue(int value)
    {
        // Implementation goes here
    }

    public LocalRemovableDataStorage(DateTime timeToDelete) : base(timeToDelete)
    {
    }
}

public class WebRemovableDataStorage : RemovableDataStorage
{
    public override int GetSomeValue(string path, int quantity)
    {
        // Implementation goes here
        return 100;
    }
    public override void SaveSomeValue(int value)
    {
        // Implementation goes here
    }

    public override void RemoveSomeValue(int value)
    {
        // Implementation goes here
    }

    public WebRemovableDataStorage(DateTime timeToDelete) : base(timeToDelete)
    {
    }
}

public class DataStorageFactory
{
    public DataStorage GetDataStorage(string storageType, DateTime timeToDelete)
    {
        switch (storageType)
        {
            case "Local":
                return new LocalDataStorage();
            case "Web":
                return new WebDataStorage();
            case "LocalRemovable":
                return new LocalRemovableDataStorage(timeToDelete);
            case "WebRemovable":
                return new WebRemovableDataStorage(timeToDelete);
            default:
                throw new ArgumentException("Invalid storage type", nameof(storageType));
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        DataStorageFactory factory = new DataStorageFactory();
        DataStorage storage = factory.GetDataStorage("LocalRemovable", DateTime.Now.AddDays(7));
        storage.SaveSomeValue(100);
        int value = storage.GetSomeValue("path", 10);
        Console.WriteLine(value);
    }
}
