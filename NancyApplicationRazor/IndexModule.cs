

namespace NancyApplicationRazor
{
    using System.Data.Entity;
    using Nancy;
    using Nancy.ModelBinding;
    using Microsoft.Security.Application;

    public class ScoreContext : DbContext
    {
        public ScoreContext(): base("DefaultConnection")
        {
            
        }

        public DbSet<Score> Scores { get; set; }
    }
    
    public class Score: DbContext
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public class IndexModule : NancyModule
    {
        ScoreContext _db = new ScoreContext();
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };            
            
            Post["/test"] = _ =>
            {
                var score = this.Bind<Score>();
                _db.Scores.Add(score);
                return "Post was a success, the params that were sent are: Name: " + Encoder.HtmlEncode(score.Name) + ", Score: " + score.Points;
            };
        }
    }
}