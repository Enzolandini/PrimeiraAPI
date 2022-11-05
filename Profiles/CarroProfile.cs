using AutoMapper;
using CarroAPI.Model;
using CarrosAPI.DTOs;

namespace CarrosAPI.Profiles
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarroDTO, Carro>();
            CreateMap<Carro, ReadCarroDto>();
            CreateMap<UpdateCarroDTO, Carro>();
        }
    }
}
