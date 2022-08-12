namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/resumes/{resumeId}/files")]
    public class FileController: ControllerBase
    {
        private string _wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromRoute] int resumeId, [FromForm] IFormFile form)
        {
            string path = Path.Combine(_wwwroot, resumeId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileInfo info = new FileInfo(form.FileName);
            string fileName = info.Name;
            string fileNameOnDirectory = Path.Combine(path, fileName);
            FileStream stream = new FileStream(fileNameOnDirectory, FileMode.Create);
            await form.CopyToAsync(stream);
            return Ok(new
            {
                FileName = fileName
            });
        }
    }

}
