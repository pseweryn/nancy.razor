namespace NancyApplicationRazor
{
    using System.Data.Entity;
    using Nancy;
    using Nancy.ModelBinding;

    public class ScoreEntity : DbContext
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };            
            
            Post["/test"] = _ =>
            {
                var score = this.Bind<ScoreEntity>();
                return "Post was a success, the params that were sent are: Name: " + score.Name + ", Score: " + score.Score;
            };
        }
    }
}