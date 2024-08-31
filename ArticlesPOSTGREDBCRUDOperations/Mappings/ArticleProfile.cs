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
        }
    }
}
