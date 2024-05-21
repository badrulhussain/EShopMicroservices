﻿using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit>
    {
    }

    public interface ICommand<out IResponse> : IRequest<IResponse>
    {
    }
}
