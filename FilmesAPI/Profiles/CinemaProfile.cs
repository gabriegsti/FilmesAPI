using AutoMapper;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();
    }
}
