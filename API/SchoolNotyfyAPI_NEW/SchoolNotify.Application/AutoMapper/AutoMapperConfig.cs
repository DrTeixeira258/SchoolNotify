using AutoMapper;
using SchoolNotify.Application.AutoMapper.CustomProfiles.ModelToViewModel;

namespace SchoolNotify.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                #region Custom Configuration
                x.AddProfile<ColaboradorParaColaboradorPorInstituicaoViewModelCustomProfile>();
                #endregion

                #region Sample Configuration
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
                #endregion
            });
        }
    }
}
