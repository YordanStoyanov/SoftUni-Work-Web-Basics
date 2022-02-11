namespace MyWebServer.Server.Results
{
    using MyWebServer.Server.HTTP;
    using System.IO;
    using System.Linq;

    public class ViewResult : ActionResult
    {
        private const char Separator = '/';
        public ViewResult(
            HttpResponse response,
            string viewName,
            string controllerName,
            object model)
            : base(response)
        {
            this.StatusCode = HttpStatusCode.OK;
            this.GetHtml(viewName, controllerName, model);
        }

        private void GetHtml(string viewName, string controllerName, object model)
        {

            if (!viewName.Contains(Separator))
            {
                viewName = controllerName + Separator + viewName;
            }
            var viewPath = Path.GetFullPath(viewName + ".cshtml");
            if (!File.Exists(viewPath))
            {
                this.PrepareMissingViewError(viewPath);
            }

            var viewContent = File.ReadAllText(viewPath);
            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }
            this.PrepareContent(viewContent, HttpContentType.Html);
        }
        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessage = $"View {viewPath} not found";
            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model.GetType().GetProperties().Select(pr => new
            {
                Name = pr.Name,
                Value = pr.GetValue(model)
            });

            foreach (var entry in data)
            {
                viewContent = viewContent.Replace($"{{{{{entry.Name}}}}}", entry.Value.ToString());
            }
            return viewContent;
        }
    }
}
