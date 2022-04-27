using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarmac.Shared.Models;

namespace Tarmac.Shared.Migrator
{
    public static class ArtistExtension
    {
        public static Artist FromOldArtist(this Artist artist, OldArtist oldArtist)
        {
            var stringLinks = oldArtist.ArtistLink.Split(';');
            var links = new List<string>();
            foreach(var link in stringLinks)
            {
                var linkType = LinkType.Default;
                linkType = linkType switch
                {
                    enum a when link.Contains("soundcloud") => LinkType.Soundcloud,
                    LinkType.Youtube when link.Contains("youtube.com"),
                    LinkType.Instagram when link.Contains("instagram.com"),

                }
                links.Add(new Link() { });
            }
            var a = new Artist()
            {
                Name = oldArtist.Artist,
                Genre = oldArtist.Genre,
                Description = new MultilanguageString()
                {
                    DE = oldArtist.ArtistDetail
                },
                Links = new List<Link>()
                
                
            }
        }
    }
}
