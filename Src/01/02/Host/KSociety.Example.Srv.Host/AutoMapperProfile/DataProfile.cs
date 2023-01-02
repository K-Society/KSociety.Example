using AutoMapper;

namespace KSociety.Example.Srv.Host.AutoMapperProfile;

public class DataProfile : Profile
{
    public DataProfile()
    {
        //Domain
        CreateMap<Domain.Entity.Book, Srv.Dto.Book>();

        //Add 
        CreateMap<App.Dto.Req.Add.Book, Domain.Entity.Book>();

        //Update
        CreateMap<App.Dto.Req.Update.Book, Domain.Entity.Book>();

        //Copy
        CreateMap<App.Dto.Req.Copy.Book, Domain.Entity.Book>();
    }
}