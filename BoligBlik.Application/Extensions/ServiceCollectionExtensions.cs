using BoligBlik.Application.Extensions.BoardMember;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Add features
            BoardMemberServiceCollection.AddBoardMember(services);
        }
    }
}
