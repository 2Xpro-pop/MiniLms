using MiniLms.Models;

namespace MiniLms.Services;

public class FakerLessonService: ILessonsService
{
    private readonly ICategoryService _categoryService;
    private readonly List<Lesson> _lessons = new();

    private readonly string[] _lessonHeaders = new[]
    {
        "Учимся стратегии с Госпожей Кагуей",
        "Искусство интриг с Кагуей",
        "Школа юмора с Кагуей",
        "Романтические секреты Госпожи Кагуе",
        "Танцы с Кагуей",
        "Уроки манипуляции от Кагуей"
    };

    private readonly string[] _lessonDescriptions = new[]
    {
        "Урок по развитию стратегического мышления и тактическим навыкам.",
        "Научитесь создавать интриги и тайны, чтобы достичь своих целей.",
        "Смех - лучшее лекарство! Уроки юмора и комических искусств.",
        "Секреты романтики и отношений, вдохновленные Госпожей Кагуей.",
        "Погружение в мир танцев с Госпожей Кагуей и компанией.",
        "Манипуляция и психология в уроках от Госпожи Кагуе."
    };

    private readonly string[] _youtubeLinks = new[]
    {
        "https://www.youtube.com/embed/-l4PNRHd_fE?si=rALVdamfepM8c21s",
        "https://www.youtube.com/embed/md8l8RfJDIo?si=BMEG1EQAjr1OzwmR",
    };

    public FakerLessonService(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public Task CreateLesson(Lesson lesson)
    {
        _lessons.Add(lesson);

        return Task.CompletedTask;
    }
    public Task DeleteLesson(Lesson lesson)
    {

        _lessons.Remove(lesson);

        return Task.CompletedTask;
    }
    public async Task<IEnumerable<Lesson>> GetAllLessons()
    {
        if (_lessons.Count == 0)
        {
            await Seed();
        }

        return _lessons;
    }
    public Task<Lesson?> GetLessonById(Guid id) => Task.FromResult(_lessons.FirstOrDefault(x => x.Id == id));
    public async Task<IEnumerable<Lesson>> GetLessonsByCategory(Guid categoryId)
    {
        if (_lessons.Count == 0)
        {
            await Seed();
        }

        return _lessons.Where(l => l.CategoryId == categoryId);
    }
    public Task UpdateLesson(Lesson lesson)
    {
        var foundedLesson = _lessons.FirstOrDefault(l => l.Id == lesson.Id);
        

        if (foundedLesson != null)
        {
            var index = _lessons.IndexOf(foundedLesson);
            _lessons[index] = lesson;
        }

        return Task.CompletedTask;
    }

    private async Task Seed()
    {
        foreach (var category in await _categoryService.GetCategories())
        {
            var numberOfLessons = new Random().Next(1, 6);

            for (var i = 0; i < numberOfLessons; i++)
            {
                var randomHeader = _lessonHeaders[new Random().Next(0, _lessonHeaders.Length)];

                var randomDescription = _lessonDescriptions[new Random().Next(0, _lessonDescriptions.Length)];

                var youtubeLink = _youtubeLinks[new Random().Next(0, _youtubeLinks.Length)];

                var lesson = new Lesson
                {
                    Header = randomHeader,
                    Description = randomDescription,
                    YoutubeUrl = youtubeLink,
                    CategoryId = category.Id
                };

                _lessons.Add(lesson);
            }

        }
    }
}
