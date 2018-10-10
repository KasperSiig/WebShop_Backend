using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using WebShop.Core.Entity.Relations;

namespace WebShop.Core.Entity
{
    public class Filter
    {
        public List<Designer> Designers { get; set; }
        public List<Color> Colors { get; set; }
        public List<Tag> Tags { get; set; }


        public bool CompliesWithFilter(Chair chair)
        {

            if (Designers.Count >= 1)
            {
                if (chair.Designer == null)
                {
                    return false;
                }

                if (!DoesContainDesigner(chair.Designer, Designers))
                {
                    return false;
                }
            }

            if (Colors.Count >= 1)
            {
                if (chair.ChairColors == null || chair.ChairColors.Count < 1)
                {
                    return false;
                }

                foreach (var color in Colors)
                {
                    if (!DoesContainColor(color, chair.ChairColors)){
                        return false;
                    }
                }
            }

            if (Tags.Count >= 1)
            {
                if (chair.ChairTags == null || chair.ChairColors.Count < 1)
                {
                    return false;
                }

                foreach (var tag in Tags)
                {
                    if (!DoesContainTag(tag, chair.ChairTags)){
                        return false;
                    }
                }
            }

            return true;
        }

        private bool DoesContainTag(Tag tag, List<ChairTag> tags)
        {
            foreach (var chairTag in tags)
            {
                if (tag.Equals(chairTag.Tag))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoesContainColor(Color color, List<ChairColor> colors)
        {
            foreach (var chairColor in colors)
            {
                if (chairColor.Color.Equals(color))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoesContainDesigner(Designer designer, List<Designer> designers)
        {
            foreach (var filterDesigner in designers)
            {
                if (filterDesigner.Equals(designer))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
