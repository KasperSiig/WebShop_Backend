using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using WebShop.Core.Entity.Relations;

namespace WebShop.Core.Entity
{
    public class Filter
    {
        public List<Designer> Designers { get; set; }
        public List<Color> Colors { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Maker> Makers { get; set; }


        public bool CompliesWithFilter(Chair chair)
        {
            if (Designers.Any())
                foreach (var designer in Designers)
                    if (designer.FirstName.ToLower().Equals(chair.Designer.FirstName.ToLower()))
                        return true;

            if (Colors.Any())
                foreach (var color in Colors)
                    foreach (var chairColor in chair.ChairColors)
                        if (chairColor.Color.Name.ToLower().Equals(color.Name.ToLower()))
                            return true;

            if (Tags.Any())
                foreach (var tag in Tags)
                foreach (var chairTag in chair.ChairTags)
                    if (chairTag.Tag.Name.ToLower().Equals(tag.Name.ToLower()))
                        return true;

            if (Makers.Any())
                foreach (var maker in Makers)
                    if (maker.Name.ToLower().Equals(chair.Maker.Name.ToLower()))
                        return true;
            
            return false;
        }
    }
}