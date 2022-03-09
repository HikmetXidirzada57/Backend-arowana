using Entities;

namespace MVC.Helper
{
    public static class PictureHelper
    {
        public static string GetCoverPhoto(int? covertId,List<ProductPicture>productPictures) 
        { 
            foreach (var picture in productPictures)
            {
                if(picture.PictureId==covertId)
                {
                    return picture.Picture.Url;
                }
            }
            return "";
        }
    }
}
