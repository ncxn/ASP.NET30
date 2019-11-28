using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Node.NodeCreate
{
    public class NodeCreateValidation : AbstractValidator<NodeCreateCommand>
    {
        public NodeCreateValidation()
        {
            RuleFor(Node => Node.Id).NotEmpty().WithMessage("Có Id nha ba ba");
            RuleFor(Node => Node.Title).NotEmpty().WithMessage("Có tiêu đề nha ");

            RuleFor(Node => Node.Content).NotEmpty().WithMessage("Phải có nội dung");
            RuleFor(Node => Node.Url).NotEmpty().WithMessage("Url?");

            RuleFor(Node => Node.Tags).NotEmpty().WithMessage("Gắn thẻ");
        }
    }
}
