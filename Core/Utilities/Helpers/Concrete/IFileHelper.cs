using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper.Concrete
{
    public interface IFileHelper
    {
        public  IResult Upload(IFormFile file);
        public  IResult Delete(string imagePath);
        public  IResult Update(IFormFile file, string imagePath);
    }
}