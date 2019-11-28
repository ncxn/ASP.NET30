using Domain.Commands;

namespace Application.Node.NodeCreate
{
    public class NodeCreateCommand: Command
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new NodeCreateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
