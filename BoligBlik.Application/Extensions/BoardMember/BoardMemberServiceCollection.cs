using BoligBlik.Application.Features.BoardMember.Commands;
using BoligBlik.Application.Features.BoardMember.Mappers;
using BoligBlik.Application.Features.BoardMember.Queries;
using BoligBlik.Application.Interfaces.BoardMember.Commands;
using BoligBlik.Application.Interfaces.BoardMember.Mappers;
using BoligBlik.Application.Interfaces.BoardMember.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Extensions.BoardMember
{
    public static class BoardMemberServiceCollection
    {
        public static void AddBoardMember(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBoardMemberCommandService, BoardMemberCommandService>();
            services.AddScoped<IBoardMemberQuerieService, BoardMemberQuerieService>();

            //Mappers
            services.AddScoped<IBoardMemberDTOMapper, BoardMemberDTOmapper>();
            services.AddScoped<IBoardMemberMapper, BoardMemberMapper>();
        }
    }
}
