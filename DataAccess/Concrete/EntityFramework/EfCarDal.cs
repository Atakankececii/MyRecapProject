using System.Linq;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,NorthwindContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id into a1
                             from b in a1.DefaultIfEmpty()
                             join co in context.Colors on c.ColorId equals co.Id into b1
                             from co in b1.DefaultIfEmpty()
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();

            }
        }

    }
}
