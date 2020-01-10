using CocosSharp;
using LooneyInvaders.Model;

namespace LooneyInvaders.Classes
{
    public class CCSpriteTwoStateButton : CCSpriteButton
    {
        public string ImageNameTapped1 { get; set; }
        public string ImageNameUntapped1 { get; set; }
        public string ImageNameTapped2 { get; set; }
        public string ImageNameUntapped2 { get; set; }

        public int State { get; set; }

        public CCSpriteTwoStateButton(string imageNameUntapped1, string imageNameTapped1, string imageNameUntapped2, string imageNameTapped2) : base(imageNameUntapped1, imageNameTapped1)
        {
            ImageNameUntapped1 = imageNameUntapped1;
            ImageNameTapped1 = imageNameTapped1;
            ImageNameUntapped2 = imageNameUntapped2;
            ImageNameTapped2 = imageNameTapped2;
            State = 2;
        }

        public void ChangeState()
        {
            State = State == 1 ? 2 : 1;
        }

        public void SetStateImages(bool refreshImage = false)
        {
            if (State == 1)
            {
                ImageNameUntapped = ImageNameUntapped1;
                ImageNameTapped = ImageNameTapped1;
            }
            else
            {
                ImageNameUntapped = ImageNameUntapped2;
                ImageNameTapped = ImageNameTapped2;
            }

            Texture = new CCTexture2D(ImageNameUntapped);
            BlendFunc = GameEnvironment.BlendFuncDefault;
        }
    }
}
