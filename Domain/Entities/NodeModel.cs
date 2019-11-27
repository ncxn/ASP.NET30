using System;

namespace Domain.Entities
{
    public class NodeModel
    {
        public NodeModel(string id, string title, string content, string url, string tags)
        {
           Id = Guid.NewGuid(); ;
            Title = title;
            Content = content;
            Url = url;
            Tags = tags;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
    }
}
