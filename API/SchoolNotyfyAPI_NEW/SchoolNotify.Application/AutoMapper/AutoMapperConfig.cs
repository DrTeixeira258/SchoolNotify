using AutoMapper;

namespace SchoolNotify.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                #region Custom Configuration

                #endregion

                #region Sample Configuration
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                #endregion
            });
        }
    }
}
