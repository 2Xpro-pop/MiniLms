namespace MiniLms.Models;

public class AccessBlock
{
    public Guid Id
    {
        get; set;
    }

    public Guid UserId
    {
        get; set;
    }

    public Guid? CategoryId
    {
        get; set;
    }

    public Guid? LessonId
    {
        get; set;
    } 

    public DateTime? BlockedUntil
    {
        get; set;
    }
    
    public AccessBlockType BlockType
    {
        get; set;
    }
}
