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
        public static Event FromOldArtist(this OldArtist oldArtist, List<Stage> stages, List<Collective> collectives, List<Festival> festivals, int year)
        {
            var newEvent = new Event()
            {
                Start = oldArtist.PlayTime,
                Duration = TimeSpan.FromHours(oldArtist.PlayDuration),
                StageId = stages.Where(s => s.Name == oldArtist.StageName).FirstOrDefault()?.Id,
                Stage = stages.Where(s => s.Name == oldArtist.StageName).FirstOrDefault(),
                CollectiveId = collectives.Where(c => c.Name == oldArtist.Collective).FirstOrDefault()?.Id,
                FestivalId = festivals.Where(f => f.Year == year).FirstOrDefault().Id,
                Festival = festivals.Where(f => f.Year == year).FirstOrDefault()
            };
            var stringLinks = oldArtist.ArtistLink.Split(';');
            var links = new List<Link>();
            foreach(string link in stringLinks)
            {
                var linkType = LinkType.Default;
                if (link.Contains("soundcloud.com"))
                {
                    linkType = LinkType.Soundcloud;
                }
                else if (link.Contains("bandcamp"))
                {
                    linkType = LinkType.Bandcamp;
                }
                else if (link.Contains("instagram"))
                {
                    linkType = LinkType.Instagram;
                }
                else if (link.Contains("facebook"))
                {
                    linkType = LinkType.Facebook;
                }
                else if (link.Contains("youtube"))
                {
                    linkType = LinkType.Youtube;
                }
                else if (link.Contains("twitter"))
                {
                    linkType = LinkType.Twitter;
                }
                else
                {
                    linkType = LinkType.Website;
                }

                Link newLink = new Link()
                {
                    LinkType = linkType,
                    
                };
                if (!String.IsNullOrEmpty(link))
                {
                    newLink.Url = new Uri(link);
                }
                links.Add(newLink);

            }
            List<Festival> newFestivals = new List<Festival>();
            newFestivals.Add(newEvent.Festival);
            var newAct = new Act()
            {
                Name = oldArtist.Artist,
                Genre = oldArtist.Genre,
                Description = new MultilanguageString()
                {
                    DE = oldArtist.ArtistDetail
                },
                Links = links,
                ActType = ActType.Default,
                Festivals = newFestivals
            };
            newEvent.Act = newAct;
            return newEvent;
        }
    }
}
