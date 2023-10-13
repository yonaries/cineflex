public class CinemaQueryHandler
{
    private readonly CinemaRepository _cinemaRepository;

    public CinemaQueryHandler(CinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }
    
    public async Task<Cinema> Handle(GetCinemaByIdQuery query)
    {
        return await _cinemaRepository.GetCinemaByIdAsync(query.Id);
    }
    
    public async Task<List<Cinema>> Handle(GetCinemasByIdQuery query)
    {
        return await _cinemaRepository.GetCinemasByIdAsync(query.Id);
    }
}