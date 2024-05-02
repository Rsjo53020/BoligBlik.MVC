using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.BoardMember.Commands.CreatedBoardMember
{
    public class CreatedBoardMember
    {
        public string CreatedABoardMember()
        {
            string personensNavn = "Ny Bestyrelsesmedlem";
            string rolle = "Bestyrelsesmedlemmets rolle";
            string path = "PO.jpg";

            // Lav HTML-koden for det nye bestyrelsesmedlem
            string nytBestyrelsesmedlemHTML = $@"
            <div class=""rounded team-item"" align=""center"">
                <div class=""team-content"">
                    <div class=""team-img-icon"">
                        <div class=""team-img rounded-circle"">
                            <img src=""/img/{path}"" class=""img-fluid w-50 rounded-circle"" alt=""Billede af den nye Bestyrelsesmedlem"">
                        </div>
                        <div class=""team-name text-center py-3"">
                            <h4 class="""">{personensNavn}</h4>
                            <p class=""m-0"">{rolle}</p>
                        </div>
                    </div>
                </div>
            </div>";

            return nytBestyrelsesmedlemHTML;

        }

    }
}
