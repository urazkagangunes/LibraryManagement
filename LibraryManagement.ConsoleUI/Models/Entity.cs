namespace LibraryManagement.ConsoleUI.Models;

public abstract class Entity<TId>
{
    public TId Id { get; set; }

    protected Entity() 
    {
        
    }
    // :this() boş ctoru da çalıştırıyor
    protected Entity(TId id) : this()
    {
        Id = id;
    }
}

