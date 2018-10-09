using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
                if (chair.Colors == null || chair.Colors.Count < 1)
                {
                    return false;
                }

                foreach (var color in Colors)
                {
                    if (!DoesContainColor(color, chair.Colors)){
                        return false;
                    }
                }
            }

            if (Tags.Count >= 1)
            {
                if (chair.Tags == null || chair.Colors.Count < 1)
                {
                    return false;
                }

                foreach (var tag in Tags)
                {
                    if (!DoesContainTag(tag, chair.Tags)){
                        return false;
                    }
                }
            }

            return true;
        }

        private bool DoesContainTag(Tag tag, List<Tag> tags)
        {
            foreach (var chairTag in tags)
            {
                if (tag.Equals(chairTag))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoesContainColor(Color color, List<Color> colors)
        {
            foreach (var chairColor in colors)
            {
                if (chairColor.Equals(color))
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
