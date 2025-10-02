using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewHandler(IRepositor<Review> _repository) : IRequestHandler<UpdateReviewCommand>
    {
        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value=await  _repository.GetByIdAsync(request.ReviewId);
            value.ReviewDate = request.ReviewDate;
            value.CustomerName = request.CustomerName;
            value.CarID = request.CarID;
            //value.CustomerImage = request.CustomerImage;
            value.Comment = request.Comment;
            value.RatıngValue=request.RatıngValue;
            await _repository.UpdateAsync(value);
        }
    }
}
