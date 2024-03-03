using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccsess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        //business rules
        //mapping
        Brand brand = new();
        brand.Name = createBrandRequest.Name;
        brand.CreateDate=DateTime.Now;
        _brandDal.Add(brand);

        CreatedBrandResponse createBrandResponse = new CreatedBrandResponse();
        createBrandResponse.Name = createBrandRequest.Name;
        createBrandResponse.Id = 4;
        createBrandResponse.CreateDate = brand.CreateDate;
        return createBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands = _brandDal.GetAll();
        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

        foreach (var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
            getAllBrandResponse.Name = brand.Name;
            getAllBrandResponse.Id=brand.Id;
            getAllBrandResponse.CreateDate = brand.CreateDate;
            getAllBrandResponses.Add(getAllBrandResponse);
        }
        return getAllBrandResponses;
    }
}
