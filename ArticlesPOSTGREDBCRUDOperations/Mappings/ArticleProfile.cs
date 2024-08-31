using ArticlesPOSTGREDBCRUDOperations.DTOs;
using ArticlesPOSTGREDBCRUDOperations.Models;
using AutoMapper;
namespace ArticlesPOSTGREDBCRUDOperations.Mappings
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile()        
        {
            CreateMap<Article, ArticleDto>()
              .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
              .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ArticleCategories.Select(ac => ac.Category.CategoryName).ToList()));

            //CreateMap<ArticleDto, Article>()
            //  .ForMember(dest => dest.ArticleCategories, opt => opt.Ignore()); // Ignore ArticleCategories to handle them manually

            CreateMap<ArticleDto, Article>()
               .ForMember(dest => dest.ArticleCategories, opt =>
               opt.MapFrom(src => src.Categories
               .Select(ac => new ArticleCategory
               {
                   Category = new Category
                   {
                       CategoryName = ac
                   }
               }).ToList()));

            CreateMap<string, ArticleCategory>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src));           
        }
    }
}
