using System.IO;
using static System.Guid;

namespace TestAPI.Services
{
    
    public class FilesService
    {
                
        public FilesService() {

            

        }

        //UploadFile - upload jednoho souboru
        public void uploadNewFile(Guid fileId, IFormFile file){

            Console.WriteLine("File " + Path.GetFileName(file.FileName) + " has been uploaded.");

        }

        //UploadFiles - upload více souborů
        public void uploadNewFilesList(Guid fileId, List<IFormFile> files){

           foreach(IFormFile file in files){

                Console.WriteLine("File " + Path.GetFileName(file.FileName) + " has been uploaded.");

           }
           
        }

    }

}