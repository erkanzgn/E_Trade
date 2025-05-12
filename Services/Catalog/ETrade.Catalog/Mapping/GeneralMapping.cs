using AutoMapper;
using ETrade.Catalog.Dtos.AboutDtos;
using ETrade.Catalog.Dtos.BrandDtos;
using ETrade.Catalog.Dtos.CategoryDtos;
using ETrade.Catalog.Dtos.FeatureDtos;
using ETrade.Catalog.Dtos.FeatureSliderDtos;
using ETrade.Catalog.Dtos.OfferDiscountDtos;
using ETrade.Catalog.Dtos.ProductDetailDtos;
using ETrade.Catalog.Dtos.ProductDtos;
using ETrade.Catalog.Dtos.ProductImageDtos;
using ETrade.Catalog.Dtos.SpecialOfferDtos;
using ETrade.Catalog.Entities;

namespace ETrade.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();

            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();

            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage,GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();


            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();


            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();

            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
        }
    }
}
