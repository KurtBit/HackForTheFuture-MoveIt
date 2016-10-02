using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoveIt.Services
{
    public class FaceRecognitionService
    {
        private IFaceServiceClient _faceServiceClient;

        public FaceRecognitionService()
        {
            this._faceServiceClient = new FaceServiceClient("8696ce6633994af6b7230e57116d7486");
        }

        public async Task<FaceRectangle[]> UploadAndDetectFaces(string imagePath)
        {
            try
            {
                using (Stream imageFileStream = File.OpenRead(imagePath))
                {
                    var faces = (await _faceServiceClient
                        .DetectAsync(imageFileStream, true, true));

                    var faceRects = faces.Select(face => face.FaceRectangle);

                    return faceRects.ToArray();
                }
            }
            catch (Exception)
            {
                return new FaceRectangle[0];
            }
        }
    }
}
