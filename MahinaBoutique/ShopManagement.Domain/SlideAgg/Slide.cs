using _0_SelfBuildFramwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide : EntityBase
    {
        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public string Heading { get; private set; }

        public string Title { get; private set; }

        public string Text { get; private set; }

        public string ButtonText { get; private set; }

        public bool IsDeleted { get; private set; }

        public string Link { get; private set; }

        public Slide(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string buttonText, string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            ButtonText = buttonText;
            IsDeleted = false;
            Link = link;
        }


        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string buttonText,string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            ButtonText = buttonText;
            IsDeleted = false;
            Link = link;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
