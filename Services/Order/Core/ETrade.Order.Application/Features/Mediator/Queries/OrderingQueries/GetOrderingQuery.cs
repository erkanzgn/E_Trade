﻿using ETrade.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {

    }
}
