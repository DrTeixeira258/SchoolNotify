using AutoMapper;

namespace Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<GenericProfile>();
            });
        }
    }
}
