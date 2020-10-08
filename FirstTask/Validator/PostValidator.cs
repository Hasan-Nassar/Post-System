using FirstTask.Core.Dtos.Post;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Validator
{
    public class PostValidator:AbstractValidator<CreatePostDtos>
    {
        public PostValidator()
        {
            RuleFor(n => n.PostDescription)
                .MaximumLength(255)
                .NotEmpty();

            RuleFor(n => n.UserId)
                .NotEmpty();

            RuleFor(n => n.PostParentId).NotEmpty();
        }
    }
}

